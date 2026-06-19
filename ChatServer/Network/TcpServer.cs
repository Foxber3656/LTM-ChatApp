<<<<<<< HEAD
﻿using ChatApp_Shared.Enums;
using ChatApp_Shared.DTOs;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
=======
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
>>>>>>> c9586379bdf71fa3ea0837fe1bad7b2ba3c4486d

namespace ChatServer.Network
{
    public class TCPServer
    {
<<<<<<< HEAD
        #region fields
        private Socket? sckServer;
        private readonly List<Socket> sckClients = new();
        private readonly Dictionary<string, Socket> onlineUsers = new(); //quản lý online user
        private readonly Dictionary<string, List<string>> groups = new(); //quản lý group
        private readonly Dictionary<string, string>groupOwners = new();
        private readonly Dictionary<string,List<MessagePacket>>offlineMessages = new();
        #endregion

        #region Events
        //gui thong bao
        public Action<string>? Onlog;
        public Action? OnUserListChanged;
        public Action? OnGroupListChanged;
        #endregion

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
                        OnGroupListChanged?.Invoke();
                        Onlog?.Invoke($"{username} logged out.");
                    }
                    client.Close();
                    Onlog?.Invoke($"Client disconnected");
                    return;
                }
                string json = Encoding.UTF8.GetString(state.Buffer, 0, size);
                MessagePacket? packet = JsonSerializer.Deserialize<MessagePacket>(json);

                if (packet != null)
                {
                    ProcessPacket(packet, client);
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
=======
        private Socket sckServer;
        private readonly List<Socket> sckClients = new();
        private readonly byte[] rcvBuffer = new byte[4096]; // ReceiveCallback

        //gui thong bao
        public Action<string>? Onlog;

>>>>>>> c9586379bdf71fa3ea0837fe1bad7b2ba3c4486d
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
<<<<<<< HEAD
=======

        //accept va luu client vao list
        private void AcceptCallback(IAsyncResult result)
        {
            try
            {
                Socket client = sckServer.EndAccept(result);
                sckClients.Add(client);

                Onlog?.Invoke($"Client connected: {client.RemoteEndPoint}");
                sckServer.BeginAccept(new AsyncCallback(AcceptCallback), null);
            }
            catch (Exception ex)
            {
                Onlog?.Invoke(ex.Message);
            }
        }
        //dem onl user
        public int OnlineCount
        {
            get
            {
                return sckClients.Count;
            }
        }
>>>>>>> c9586379bdf71fa3ea0837fe1bad7b2ba3c4486d
        //dong server
        public void StopServer()
        {
            foreach (Socket client in sckClients)
            {
<<<<<<< HEAD
                client.Close();
            }
            sckClients.Clear();
            onlineUsers.Clear();
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
                    HandleRegister(packet);
                    break;
                case MessageType.FileTransfer:
                    HandleFileTransfer(packet);
                    break;
            }
        }
        #endregion

        #region user
        private void HandleLogin(MessagePacket packet, Socket client)
        {
            if (!onlineUsers.ContainsKey(packet.Sender))
            {
                onlineUsers.Add(packet.Sender,client);
                if (offlineMessages.ContainsKey(packet.Sender))
                {
                    foreach (MessagePacket msg in offlineMessages[packet.Sender])
                    {
                        string json = JsonSerializer.Serialize(msg);
                        byte[] data = Encoding.UTF8.GetBytes(json);
                        client.Send(data);
                    }
                    Onlog?.Invoke($"{offlineMessages[packet.Sender].Count} offline messages delivered.");
                    offlineMessages.Remove(packet.Sender);
                }
                OnUserListChanged?.Invoke();
                Onlog?.Invoke($"{packet.Sender} logged in.");
            }
        }
        private void HandleLogout(MessagePacket packet)
        {
            if (!onlineUsers.ContainsKey(packet.Sender))
                return;
            Socket client = onlineUsers[packet.Sender];
            sckClients.Remove(client);
            client.Close();
            onlineUsers.Remove(packet.Sender);

            OnUserListChanged?.Invoke();
            OnGroupListChanged?.Invoke();
            Onlog?.Invoke($"{packet.Sender} logged out.");
        }
        private void HandlePrivateMessage(MessagePacket packet)
        {
            if (!onlineUsers.ContainsKey(packet.Receiver))
            {
                if (!offlineMessages.ContainsKey(packet.Receiver))
                {
                    offlineMessages.Add(
                        packet.Receiver,
                        new List<MessagePacket>());
                }
                offlineMessages[packet.Receiver].Add(packet);
                Onlog?.Invoke($"Offline message saved for {packet.Receiver}");
                return;
            }
            Socket receiver = onlineUsers[packet.Receiver];
            string json = JsonSerializer.Serialize(packet);
            byte[] data = Encoding.UTF8.GetBytes(json);
            receiver.Send(data);
            Onlog?.Invoke($"{packet.Sender} -> {packet.Receiver}");
        }
        private void HandleRegister(MessagePacket packet)
        {
            Onlog?.Invoke($"Register request: {packet.Sender}");
        }
        private void HandleFileTransfer(MessagePacket packet)
        {
            Onlog?.Invoke(
                $"File transfer: {packet.Sender}");
        }
        public void BroadcastMessage(string message)
        {
            MessagePacket packet = new MessagePacket()
            {
                Type = MessageType.BroadcastMessage,
                Sender = "ADMIN",
                Receiver = "ALL",
                Content = message
            };

            string json = JsonSerializer.Serialize(packet);
            byte[] data = Encoding.UTF8.GetBytes(json);

            foreach (Socket client in sckClients)
            {
                try
                {
                    client.Send(data);
                }
                catch
                {
                }
            }

            Onlog?.Invoke($"[BROADCAST] {message}");
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
            catch
            {
            }

            onlineUsers.Remove(username);
            sckClients.Remove(client);

            OnUserListChanged?.Invoke();

            Onlog?.Invoke($"[KICK] {username}");
        }
        #endregion

        #region group
        private void HandleGroupMessage(MessagePacket packet)
        {
            if (!groups.ContainsKey(packet.Receiver))
                return;

            List<string> members =
                groups[packet.Receiver];

            string json =
                JsonSerializer.Serialize(packet);

            byte[] data =
                Encoding.UTF8.GetBytes(json);

            foreach (string username in members)
            {
                if (username == packet.Sender)
                    continue;

                if (!onlineUsers.ContainsKey(username))
                {
                    if (!offlineMessages.ContainsKey(username))
                    {
                        offlineMessages.Add(username,new List<MessagePacket>());
                    }
                    offlineMessages[username].Add(packet);
                    continue;
                }                 
                onlineUsers[username].Send(data);
            }
            Onlog?.Invoke($"Group message -> {packet.Receiver}");
        }
        private void HandleCreateGroup(MessagePacket packet)
        {
            if (groups.ContainsKey(packet.Receiver))
                return;
            groupOwners[packet.Receiver] = packet.Sender;
            groups.Add(packet.Receiver, new List<string>()
                {
                packet.Sender
                });
            OnGroupListChanged?.Invoke();

            Onlog?.Invoke(
                $"Group created: {packet.Receiver}");
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
                Onlog?.Invoke(
                    $"{packet.Content} added to {packet.Receiver}");
            }
        }
        private void HandleRemoveMember(MessagePacket packet)
        {
            if (!groups.ContainsKey(packet.Receiver))
                return;

            groups[packet.Receiver].Remove(packet.Content);
            OnGroupListChanged?.Invoke();

            Onlog?.Invoke(
                $"{packet.Content} removed from {packet.Receiver}");
        }
        #endregion

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
            get { return sckServer != null; }
=======
                sckServer?.Close();
                sckServer = null;
            }
            sckClients.Clear();
            sckServer?.Close();
            Onlog?.Invoke("Server stopped.");
        }
        public bool IsRunning
        {
            get
            {
                return sckServer != null;
            }
>>>>>>> c9586379bdf71fa3ea0837fe1bad7b2ba3c4486d
        }
    }
}