using ChatApp_Shared.DTOs;
using ChatApp_Shared.Enums;
using ChatApp_Shared.Packet;
using ChatShared.Models;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using ChatServer.Storage;
using static System.Windows.Forms.AxHost;

namespace ChatServer.Network
{
    public class TCPServer
    {
        #region fields
        private Socket? sckServer;
        private readonly List<Socket> sckClients = new();
        private readonly Dictionary<string, Socket> onlineUsers = new(); //quản lý online user
        private readonly Dictionary<string, List<string>> groups = new(); //quản lý group
        private readonly Dictionary<string, string> groupOwners = new();

        private readonly AccountRepository accountRepository = new();
        private readonly GroupRepository groupRepository = new();
        private readonly MessageRepository messageRepository = new();
        #endregion

        #region Events
        //gui thong bao
        public Action<string>? Onlog;
        public Action? OnUserListChanged;
        public Action? OnGroupListChanged;
        #endregion

        public TCPServer()
        {
            foreach (Group group in groupRepository.GetAll())
            {
                groups[group.GroupName] = new List<string>(group.Members);

                groupOwners[group.GroupName] = group.Owner;
            }
        }

        #region socket Callback
        //accept va luu client vao list
        private void AcceptCallback(IAsyncResult result)
        {
            try
            {
                if (sckServer == null)
                    return;
                Socket client = sckServer.EndAccept(result);
                sckClients.Add(client);

                ClientState state = new ClientState()
                {
                    ClientSocket = client
                };

                Onlog?.Invoke($"Client connected: {client.RemoteEndPoint}");
                sckServer.BeginAccept(new AsyncCallback(AcceptCallback), null);

                client.BeginReceive(state.Buffer, 0, state.Buffer.Length, SocketFlags.None,
                    new AsyncCallback(ReceiveCallback), state);
            }
            catch (Exception ex)
            {
                Onlog?.Invoke(ex.Message);
            }
        }
        private void ReceiveCallback(IAsyncResult result)
        {
            try
            {
                ClientState state = (ClientState)result.AsyncState!;
                Socket client = state.ClientSocket;
                int size = client.EndReceive(result);

                if (size <= 0)
                {
                    sckClients.Remove(client);
                    string? username = onlineUsers.FirstOrDefault(x => x.Value == client).Key;

                    if (!string.IsNullOrEmpty(username))
                    {
                        onlineUsers.Remove(username);
                        OnUserListChanged?.Invoke();
                        SendUserList();
                        OnGroupListChanged?.Invoke();
                        Onlog?.Invoke($"{username} logged out.");
                    }
                    try
                    {
                        client.Shutdown(SocketShutdown.Both);
                    }
                    catch
                    {
                    }
                    client.Close();
                    Onlog?.Invoke($"Client disconnected");
                    return;
                }

                // Ghi dữ liệu mới vào Stream
                state.Stream.Position = state.Stream.Length;
                state.Stream.Write(state.Buffer, 0, size);

                MessagePacket? packet;

                while (PacketSerializer.TryReadPacket(state.Stream, out packet))
                {
                    if (packet != null)
                    {
                        ProcessPacket(packet, client);
                    }
                }

                client.BeginReceive(state.Buffer, 0, state.Buffer.Length, SocketFlags.None,
                    new AsyncCallback(ReceiveCallback), state);
            }
            catch (Exception ex)
            {
                Onlog?.Invoke(ex.Message);
            }
        }
        #endregion

        #region server
        // Socket -> Bind -> Listen -> Accept
        public void StartServer(int port)
        {
            try
            {
                //tao sck
                sckServer = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                //gan ket noi
                IPEndPoint serverEP = new IPEndPoint(IPAddress.Any, port);
                sckServer.Bind(serverEP);

                //tao hang doi
                sckServer.Listen(10);

                //Ghi log 
                Onlog?.Invoke($"Server started at port {port}");

                //Cho ket noi
                sckServer.BeginAccept(new AsyncCallback(AcceptCallback), null);
            }
            catch (Exception ex)
            {
                Onlog?.Invoke(ex.Message);
            }
        }
        public void StopServer()
        {
            foreach (Socket client in sckClients)
            {
                try
                {
                    client.Shutdown(SocketShutdown.Both);
                }
                catch {}
                client.Close();
            }
            sckClients.Clear();
            onlineUsers.Clear();
            groups.Clear();
            groupOwners.Clear();

            sckServer?.Close();
            sckServer = null;
            OnUserListChanged?.Invoke();
            OnGroupListChanged?.Invoke();
            Onlog?.Invoke("Server stopped.");
        }
        #endregion

        #region packet
        private void ProcessPacket(MessagePacket packet, Socket client)
        {
            switch (packet.Type)
            {
                case MessageType.Login:
                    HandleLogin(packet, client);
                    break;
                case MessageType.PrivateMessage:
                    HandlePrivateMessage(packet);
                    break;

                case MessageType.GroupMessage:
                    HandleGroupMessage(packet);
                    break;
                case MessageType.BroadcastMessage:
                    BroadcastMessage(packet.Content);
                    break;
                case MessageType.CreateGroup:
                    HandleCreateGroup(packet);
                    break;
                case MessageType.AddMember:
                    HandleAddMember(packet);
                    break;
                case MessageType.RemoveMember:
                    HandleRemoveMember(packet);
                    break;
                case MessageType.Logout:
                    HandleLogout(packet);
                    break;
                case MessageType.Register:
                    HandleRegister(packet, client);
                    break;
                case MessageType.FileStart:
                    HandleFileStart(packet);
                    break;

                case MessageType.FileChunk:
                    HandleFileChunk(packet);
                    break;

                case MessageType.FileEnd:
                    HandleFileEnd(packet);
                    break;
                case MessageType.FileAccept:
                    ForwardPacket(packet);
                    break;

                case MessageType.FileReject:
                    ForwardPacket(packet);
                    break;
                case MessageType.RecallMessage:

                    ForwardPacket(packet);
                    if (onlineUsers.TryGetValue(packet.Sender, out Socket? sender))
                    {
                        SendPacket(sender, packet);
                    }
                    break;
                case MessageType.Typing:
                    ForwardPacket(packet);
                    break;
            }
        }
        #endregion

        #region user
        private void HandleLogin(MessagePacket packet, Socket client)
        {
            Account? account = accountRepository.Find(packet.Sender);

            if (account == null)
            {
                SendPacket(client, new MessagePacket()
                {
                    Type = MessageType.Login,
                    Sender = "SERVER",
                    Receiver = packet.Sender,
                    Content = "USERNAME_NOT_FOUND"
                });
                return;
            }

            if (account.PasswordHash != packet.Content)
            {
                SendPacket(client, new MessagePacket()
                {
                    Type = MessageType.Login,
                    Sender = "SERVER",
                    Receiver = packet.Sender,
                    Content = "INVALID_PASSWORD"
                });
                return;
            }

            if (onlineUsers.ContainsKey(packet.Sender))
            {
                SendPacket(client, new MessagePacket()
                {
                    Type = MessageType.Login,
                    Sender = "SERVER",
                    Receiver = packet.Sender,
                    Content = "USERNAME_ALREADY_ONLINE"
                });
                return;
            }

            onlineUsers.Add(packet.Sender, client);

            SendPacket(client, new MessagePacket()
            {
                Type = MessageType.Login,
                Sender = "SERVER",
                Receiver = packet.Sender,
                Content = "LOGIN_SUCCESS"
            });

            OnUserListChanged?.Invoke();
            SendUserList();
            SendGroupList();

            Onlog?.Invoke($"{packet.Sender} logged in.");
        }
        private void HandleRegister(MessagePacket packet, Socket client)
        {
            Onlog?.Invoke("HandleRegister called");
            try
            {
                Onlog?.Invoke("1");

                if (accountRepository.Exists(packet.Sender))
                {
                    Onlog?.Invoke("2");

                    SendPacket(client, new MessagePacket()
                    {
                        Type = MessageType.Register,
                        Sender = "SERVER",
                        Receiver = packet.Sender,
                        Content = "USERNAME_EXISTS"
                    });

                    return;
                }

                Onlog?.Invoke("3");

                Account account = new()
                {
                    UserName = packet.Sender,
                    PasswordHash = packet.Content
                };

                Onlog?.Invoke("4");

                accountRepository.Add(account);

                Onlog?.Invoke("5");

                SendPacket(client, new MessagePacket()
                {
                    Type = MessageType.Register,
                    Sender = "SERVER",
                    Receiver = packet.Sender,
                    Content = "REGISTER_SUCCESS"
                });

                Onlog?.Invoke("6");
            }
            catch (Exception ex)
            {
                Onlog?.Invoke(ex.ToString());
            }
        }
        private void HandleLogout(MessagePacket packet)
        {
            if (!onlineUsers.ContainsKey(packet.Sender))
                return;
            Socket client = onlineUsers[packet.Sender];
            sckClients.Remove(client);
            try
            {
                client.Shutdown(SocketShutdown.Both);
            }
            catch {}
            client.Close();
            onlineUsers.Remove(packet.Sender);

            OnUserListChanged?.Invoke();
            OnGroupListChanged?.Invoke();
            SendUserList();
            Onlog?.Invoke($"{packet.Sender} logged out.");
        }
        private void HandleFileStart(MessagePacket packet)
        {
            ForwardPacket(packet);
            Onlog?.Invoke($"[FILE START] {packet.Sender} -> {packet.Receiver}");
        }

        private void HandleFileChunk(MessagePacket packet)
        {
            ForwardPacket(packet);
        }

        private void HandleFileEnd(MessagePacket packet)
        {
            ForwardPacket(packet);
            Onlog?.Invoke($"[FILE END] {packet.Sender}");
        }
        public void KickUser(string username)
        {
            if (!onlineUsers.ContainsKey(username))
                return;

            Socket client = onlineUsers[username];

            try
            {
                client.Shutdown(SocketShutdown.Both);
                client.Close();
            }
            catch {}
            onlineUsers.Remove(username);
            sckClients.Remove(client);

            OnUserListChanged?.Invoke();
            SendUserList();
            SendGroupList();
            Onlog?.Invoke($"[KICK] {username}");
        }
        #endregion

        #region msg
        private void HandlePrivateMessage(MessagePacket packet)
        {
            messageRepository.Add(packet);
            ForwardPacket(packet);
            Onlog?.Invoke($"[PRIVATE] {packet.Sender} -> {packet.Receiver}");
        }
        private void HandleGroupMessage(MessagePacket packet)
        {
            messageRepository.Add(packet);
            if (!groups.ContainsKey(packet.Receiver))
                return;

            List<string> members = groups[packet.Receiver];
            foreach (string username in members)
            {
                if (username == packet.Sender)
                    continue;
                if (!onlineUsers.ContainsKey(username))
                    continue;
                try
                {
                    SendPacket(onlineUsers[username], packet);
                }
                catch { }
            }
            Onlog?.Invoke($"[GROUP] {packet.Sender} -> {packet.Receiver}");
        }
        public void BroadcastMessage(string message)
        {
            MessagePacket packet = new MessagePacket()
            {
                Type = MessageType.BroadcastMessage,
                Sender = "SERVER",
                Receiver = "ALL",
                Content = message
            };
            messageRepository.Add(packet);
            foreach (Socket client in onlineUsers.Values)
            {
                try
                {
                    SendPacket(client, packet);
                }
                catch (Exception ex)
                {
                    Onlog?.Invoke(ex.Message);
                }
            }
            Onlog?.Invoke($"[BROADCAST] {message}");
        }
        #endregion

        #region group
        private void HandleCreateGroup(MessagePacket packet)
        {
            if (groups.ContainsKey(packet.Receiver))
                return;
            List<string>? members = JsonSerializer.Deserialize<List<string>>(packet.Content);
            if (members == null)
                return;

            groupOwners[packet.Receiver] = packet.Sender;
            groups.Add(packet.Receiver, members);

            groupRepository.Add(new Group()
            {
                GroupName = packet.Receiver,
                Owner = packet.Sender,
                Members = new List<string>(members)
            });
            OnGroupListChanged?.Invoke();
            SendGroupList();
            Onlog?.Invoke($"Group created: {packet.Receiver}");
        }
        private void HandleAddMember(MessagePacket packet)
        {
            if (!groups.ContainsKey(packet.Receiver))
                return;

            if (!groups[packet.Receiver]
                .Contains(packet.Content))
            {
                groups[packet.Receiver].Add(packet.Content);
                OnGroupListChanged?.Invoke();

                Group? group = groupRepository.Find(packet.Receiver);

                if (group != null)
                {
                    group.Members.Add(packet.Content);
                    groupRepository.Save();
                }
                SendGroupList();
                Onlog?.Invoke(
                    $"{packet.Content} added to {packet.Receiver}");
            }
        }
        private void HandleRemoveMember(MessagePacket packet)
        {
            if (!groups.ContainsKey(packet.Receiver))
                return;
            groups[packet.Receiver].Remove(packet.Content);

            Group? group = groupRepository.Find(packet.Receiver);

            if (group != null)
            {
                group.Members.Remove(packet.Content);

                if (group.Members.Count == 0)
                {
                    groupRepository.Delete(packet.Receiver);
                }
                else
                {
                    groupRepository.Save();
                }
            }

            if (groups[packet.Receiver].Count == 0)
            {
                groups.Remove(packet.Receiver);
                groupOwners.Remove(packet.Receiver);
            }
            OnGroupListChanged?.Invoke();
            SendGroupList();
            Onlog?.Invoke($"{packet.Content} removed from {packet.Receiver}");
        }
        #endregion

        #region send
        private void SendPacket(Socket client, MessagePacket packet)
        {
            byte[] data = PacketSerializer.Serialize(packet);
            client.Send(data);
        }
        private void SendUserList()
        {
            MessagePacket packet = new MessagePacket()
            {
                Type = MessageType.UserList,
                Sender = "SERVER",
                Content = JsonSerializer.Serialize(OnlineUsers)
            };
            foreach (Socket client in onlineUsers.Values)
            {
                try
                {
                    SendPacket(client, packet);
                }
                catch {}
            }
        }
        private void SendGroupList()
        {
            List<Group> list = new();

            foreach (string groupName in groups.Keys)
            {
                Group info = new()
                {
                    GroupName = groupName,
                    Owner = groupOwners[groupName],
                    Members = new List<string>(groups[groupName])
                };

                list.Add(info);
            }

            MessagePacket packet = new()
            {
                Type = MessageType.GroupList,
                Sender = "SERVER",
                Content = JsonSerializer.Serialize(list)
            };

            foreach (Socket client in onlineUsers.Values)
            {
                try
                {
                    SendPacket(client, packet);
                }
                catch {}
            }
        }
        public void SendPrivateMessage(string receiver, string message)
        {
            MessagePacket packet = new()
            {
                Type = MessageType.PrivateMessage,
                Sender = "SERVER",
                Receiver = receiver,
                Content = message
            };
            try
            {
                SendPacket(onlineUsers[receiver], packet);
                Onlog?.Invoke($"[SERVER -> {receiver}] {message}");
            }
            catch (Exception ex)
            {
                Onlog?.Invoke(ex.Message);
            }
        }
        public void SendGroupMessage(string groupName, string message)
        {
            if (!groups.ContainsKey(groupName))
            {
                Onlog?.Invoke($"Group {groupName} not found.");
                return;
            }
            MessagePacket packet = new()
            {
                Type = MessageType.GroupMessage,
                Sender = "SERVER",
                Receiver = groupName,
                Content = message
            };

            foreach (string username in groups[groupName])
            {
                try
                {
                    SendPacket(onlineUsers[username], packet);
                }
                catch (Exception ex)
                {
                    Onlog?.Invoke(ex.Message);
                }
            }
            Onlog?.Invoke($"[SERVER -> GROUP {groupName}] {message}");
        }
        #endregion

        #region methods
        private void ForwardPacket(MessagePacket packet)
        {
            if (onlineUsers.TryGetValue(packet.Receiver, out Socket? socket))
            {
                SendPacket(socket, packet);
            }
        }
        #endregion

        #region fill
        public List<string> OnlineUsers
        {
            get{return onlineUsers.Keys.ToList();}
        }
        public List<string> GroupNames
        {
            get{return groups.Keys.ToList();}
        }
        public Dictionary<string, List<string>> Groups
        {
            get{return groups;}
        }
        public Dictionary<string, string> GroupOwners
        {
            get { return groupOwners; }
        }
        //dem onl user
        public int OnlineCount
        {
            get { return onlineUsers.Count; }
        }
        public int GroupCount
        {
            get { return groups.Count; }
        }
        public bool IsRunning
        {
            get
            {
                return sckServer != null;
            }
        }
        #endregion
    }
}