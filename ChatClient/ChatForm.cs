using ChatApp_Shared.DTOs;
using ChatApp_Shared.Enums;
using ChatClient.Models;
using ChatClient.Network;
using ChatShared.Models;
using System.Data;
using System.Diagnostics;
using System.Text.Json;

namespace ChatClient
{
    public partial class ChatForm : Form
    {
        #region fileds
        private readonly TCPClient client;
        private readonly string username;
        private readonly List<string> friends = new();
        private readonly List<Group> groups = new();
        private readonly System.Windows.Forms.Timer timerClock = new();
        private readonly Dictionary<string, List<MessagePacket>> conversations = new();
        private readonly Dictionary<string, List<MessagePacket>> groupConversations = new();

        private readonly Dictionary<string, int> unreadGroups = new();
        private readonly Dictionary<string, int> unreadMessages = new();

        private readonly Dictionary<Guid, BufferFile> receivingFiles = new();
        private readonly Dictionary<Guid, string> pendingFiles = new();
        private const int FILE_BUFFER_SIZE = 64 * 1024;
        private readonly Dictionary<Guid, FileMessage> incomingFiles = new();
        private string? currentReceiver;
        private readonly List<ChatFileItem> fileHistory = new();

        private readonly Dictionary<Guid, BufferFile> receivingImages = new();
        private readonly Dictionary<Guid, FileMessage> incomingImages = new();

        private List<MessagePacket> currentSearch = new();
        private int currentIndex = -1;
        #endregion
        public ChatForm(TCPClient client, string username)
        {
            InitializeComponent();
            this.client = client;
            this.username = username;

            client.OnLog += AddLog;
            client.OnPacketReceived += ProcessPacket;
            client.OnDisconnected += ClientDisconnected;
            tvContacts.AfterSelect += TvContacts_AfterSelect;

            rtbChat.MouseDoubleClick += rtbChat_MouseDoubleClick;

            timerClock.Interval = 1000;
            timerClock.Tick += (s, e) =>
            {
                tsTime.Text = DateTime.Now.ToString("HH:mm:ss");
            };

            timerClock.Start();
        }
        #region packet
        private void ProcessPacket(MessagePacket packet)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<MessagePacket>(ProcessPacket), packet);
                return;
            }
            switch (packet.Type)
            {
                case MessageType.UserList:
                    List<string>? users = JsonSerializer.Deserialize<List<string>>(packet.Content);
                    if (users != null)
                    {
                        friends.Clear();
                        friends.AddRange(users);
                        RefreshFriends();
                    }
                    break;

                case MessageType.GroupList:
                    List<Group>? groupList = JsonSerializer.Deserialize<List<Group>>(packet.Content);
                    if (groupList != null)
                    {
                        groups.Clear();
                        groups.AddRange(groupList);
                        RefreshGroups();
                    }
                    break;

                case MessageType.PrivateMessage:
                    if (packet.Sender == "SERVER")
                    {
                        AppendMessage("SERVER", packet.Content, packet.TimeStamp);
                        break;
                    }
                    SaveMessage(packet.Sender, packet);

                    if (currentReceiver == packet.Sender)
                    {
                        AppendMessage(packet.Sender, packet.Content, packet.TimeStamp);
                        tslTyping.Text = "";
                    }
                    else
                    {
                        IncreaseUnread(packet.Sender);
                        RefreshFriends();
                    }
                    break;

                case MessageType.BroadcastMessage:
                    AppendMessage("SERVER", packet.Content, packet.TimeStamp);
                    break;

                case MessageType.GroupMessage:
                    SaveGroupMessage(packet.Receiver, packet);
                    if (currentReceiver == packet.Receiver)
                    {
                        AppendMessage(packet.Sender, packet.Content, packet.TimeStamp);
                        LoadGroupInfo(packet.Receiver);
                    }
                    else
                    {
                        IncreaseUnreadGroup(packet.Receiver);
                        RefreshGroups();
                    }
                    break;
                case MessageType.FileStart:
                    ReceiveFileStart(packet);
                    break;

                case MessageType.FileChunk:
                    ReceiveFileChunk(packet);
                    break;

                case MessageType.FileEnd:
                    ReceiveFileEnd(packet);
                    break;
                case MessageType.FileAccept:
                    ReceiveFileAccept(packet);
                    break;

                case MessageType.FileReject:
                    ReceiveFileReject(packet);
                    break;
                case MessageType.ImageTransfer:
                    ReceiveImageStart(packet);
                    break;

                case MessageType.ImageAccept:
                    ReceiveImageAccept(packet);
                    break;

                case MessageType.ImageReject:
                    ReceiveImageReject(packet);
                    break;

                case MessageType.ImageChunk:
                    ReceiveImageChunk(packet);
                    break;

                case MessageType.ImageEnd:
                    ReceiveImageEnd(packet);
                    break;
                case MessageType.RecallMessage:
                    ReceiveRecall(packet);
                    break;
                case MessageType.Typing:
                    ReceiveTyping(packet);
                    break;
            }
        }
        #endregion
        #region Methods
        private void AddLog(string message)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<string>(AddLog), message);
                return;
            }
            tsStatus.Text = message;
        }

        private void ClientDisconnected()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(ClientDisconnected));
                return;
            }
            MessageBox.Show("Disconnected.");
            Close();
        }
        private void InitTreeView()
        {
            tvContacts.Nodes.Clear();
            TreeNode friendsNode = new TreeNode("Friends")
            {
                Name = "Friends"
            };

            TreeNode groupsNode = new TreeNode("Groups")
            {
                Name = "Groups"
            };

            tvContacts.Nodes.Add(friendsNode);
            tvContacts.Nodes.Add(groupsNode);
            tvContacts.ExpandAll();
        }
        private void RefreshFriends()
        {
            TreeNode? friendsRoot = tvContacts.Nodes["Friends"];

            if (friendsRoot == null)
                return;

            friendsRoot.Nodes.Clear();
            foreach (string user in friends)
            {
                if (user == username)
                    continue;
                string text = user;

                if (unreadMessages.ContainsKey(user))
                {
                    text += $" ({unreadMessages[user]})";
                }

                TreeNode node = new(text)
                {
                    Name = user
                };

                friendsRoot.Nodes.Add(node);
            }
            friendsRoot.Text = $"Friends ({friends.Count - 1})";
            friendsRoot.Expand();
        }
        private void RefreshGroups()
        {
            TreeNode? groupRoot = tvContacts.Nodes["Groups"];

            if (groupRoot == null)
                return;

            groupRoot.Nodes.Clear();
            foreach (Group group in groups)
            {
                string text = group.GroupName;

                if (unreadGroups.ContainsKey(group.GroupName))
                {
                    text += $" ({unreadGroups[group.GroupName]})";
                }

                TreeNode node = new(text)
                {
                    Name = group.GroupName
                };
                groupRoot.Nodes.Add(node);
            }
            groupRoot.Text = $"Groups ({groups.Count})";
            groupRoot.Expand();
        }
        private void TvContacts_AfterSelect(object? sender, TreeViewEventArgs e)
        {
            if (e.Node.Parent == null)
                return;
            switch (e.Node.Parent.Name)
            {
                case "Friends":
                    currentReceiver = e.Node.Name;
                    tslTyping.Text = "";
                    ClearUnread(currentReceiver);
                    RefreshFriends();
                    LoadConversation(currentReceiver);
                    LoadFriendInfo(currentReceiver);

                    tsStatus.Text = $"Chatting with {currentReceiver}";
                    break;
                case "Groups":
                    currentReceiver = e.Node.Name;
                    tslTyping.Text = "";
                    ClearUnreadGroup(currentReceiver);
                    RefreshGroups();
                    LoadGroupConversation(currentReceiver);
                    LoadGroupInfo(currentReceiver);
                    tsStatus.Text = $"Group: {currentReceiver}";
                    break;
            }
        }
        private void AppendMessage(string sender, string message, DateTime time)
        {
            bool isMine = sender == "You" || sender == username;

            rtbChat.SelectionStart = rtbChat.TextLength;
            rtbChat.SelectionLength = 0;

            if (isMine)
            {
                // Tên
                rtbChat.SelectionFont = new Font("Segoe UI", 9, FontStyle.Bold);
                rtbChat.SelectionColor = Color.DodgerBlue;
                rtbChat.AppendText(RightAlign("You") + Environment.NewLine);

                // Nội dung
                rtbChat.SelectionFont = new Font("Segoe UI", 10);
                rtbChat.SelectionColor = Color.Black;
                rtbChat.AppendText(RightAlign(message) + Environment.NewLine);

                // Thời gian
                rtbChat.SelectionFont = new Font("Segoe UI", 8, FontStyle.Italic);
                rtbChat.SelectionColor = Color.Gray;
                rtbChat.AppendText(RightAlign(time.ToString("HH:mm")));
            }
            else
            {
                rtbChat.SelectionFont = new Font("Segoe UI", 9, FontStyle.Bold);
                rtbChat.SelectionColor = Color.ForestGreen;
                rtbChat.AppendText(sender + Environment.NewLine);

                rtbChat.SelectionFont = new Font("Segoe UI", 10);
                rtbChat.SelectionColor = Color.Black;
                rtbChat.AppendText(message + Environment.NewLine);

                rtbChat.SelectionFont = new Font("Segoe UI", 8, FontStyle.Italic);
                rtbChat.SelectionColor = Color.Gray;
                rtbChat.AppendText(time.ToString("HH:mm"));
            }

            rtbChat.AppendText(Environment.NewLine);
            rtbChat.AppendText(Environment.NewLine);

            rtbChat.SelectionStart = rtbChat.TextLength;
            rtbChat.ScrollToCaret();
        }
        private void IncreaseUnread(string username)
        {
            if (unreadMessages.ContainsKey(username))
            {
                unreadMessages[username]++;
            }
            else
            {
                unreadMessages[username] = 1;
            }
        }
        private void IncreaseUnreadGroup(string group)
        {
            if (unreadGroups.ContainsKey(group))
            {
                unreadGroups[group]++;
            }
            else
            {
                unreadGroups[group] = 1;
            }
        }

        private void ClearUnreadGroup(string group)
        {
            unreadGroups.Remove(group);
        }
        private void ClearUnread(string username)
        {
            if (unreadMessages.ContainsKey(username))
            {
                unreadMessages.Remove(username);
            }
        }
        #endregion

        #region load
        private void ChatForm_Load(object sender, EventArgs e)
        {
            tsUser.Text = $"User : {username}";
            tsStatus.Text = "Connected";
            tsTime.Text = DateTime.Now.ToString("HH:mm:ss");

            rtbChat.Font = new Font("Segoe UI", 10);
            rtbChat.BackColor = Color.WhiteSmoke;
            rtbChat.ReadOnly = true;
            rtbChat.BorderStyle = BorderStyle.None;

            if (client.ClientSocket != null)
            {
                tsServer.Text = $"Server : {client.ClientSocket.RemoteEndPoint}";
            }
            InitTreeView();
        }
        private void LoadConversation(string user)
        {
            tslTyping.Text = "";
            rtbChat.Clear();

            rtbChat.SelectionFont =
                new Font("Segoe UI", 9, FontStyle.Bold);

            rtbChat.SelectionColor = Color.Gray;

            rtbChat.AppendText(
                $"──────── {user} ────────\n\n");

            if (!conversations.ContainsKey(user))
                return;

            foreach (MessagePacket packet in conversations[user])
            {
                string sender =
                    packet.Sender == username
                        ? "You"
                        : packet.Sender;

                AppendMessage(
                    sender,
                    packet.Content,
                    packet.TimeStamp);
            }
        }
        private void LoadFriendInfo(string friend)
        {
            lblUsername.Text = friend;
            lblStatus.Text = "● Online";
            lblType.Text = "Friend";
            lblIP.Text = "-";
            lblPort.Text = "-";
            lblLastSeen.Text = "Online";

            int total = conversations.ContainsKey(friend)
                ? conversations[friend].Count : 0;
            lblTotalMessages.Text = total.ToString();

            int unread = unreadMessages.ContainsKey(friend)
                ? unreadMessages[friend] : 0;
            lblUnread.Text = unread.ToString();
        }
        private void LoadGroupInfo(string groupName)
        {
            Group? group = groups.FirstOrDefault(x => x.GroupName == groupName);
            if (group == null)
                return;

            lblUsername.Text = group.GroupName;
            lblStatus.Text = "● Active";
            lblType.Text = "Group";
            lblIP.Text = group.Owner;
            lblPort.Text = group.MemberCount.ToString();
            lblLastSeen.Text = string.Join(", ", group.Members);

            int total = groupConversations.ContainsKey(groupName)
                ? groupConversations[groupName].Count : 0;

            lblTotalMessages.Text = total.ToString();
            lblUnread.Text = "0";
        }
        private void LoadGroupConversation(string group)
        {
            rtbChat.Clear();
            if (!groupConversations.ContainsKey(group))
                return;
            foreach (MessagePacket packet in groupConversations[group])
            {
                string sender = packet.Sender == username ? "You" : packet.Sender;
                AppendMessage(sender, packet.Content, packet.TimeStamp);
            }
        }
        #endregion

        #region save
        private void SaveMessage(string user, MessagePacket packet)
        {
            if (!conversations.ContainsKey(user))
            {
                conversations[user] = new List<MessagePacket>();
            }

            conversations[user].Add(packet);
        }
        private void SaveGroupMessage(string group, MessagePacket packet)
        {
            if (!groupConversations.ContainsKey(group))
            {
                groupConversations[group] = new();
            }

            groupConversations[group].Add(packet);
        }
        #endregion

        #region click
        private void btnSend_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(currentReceiver))
            {
                MessageBox.Show("Please select a friend.");
                return;
            }

            string message = txbMessage.Text.Trim();

            if (string.IsNullOrWhiteSpace(message))
                return;
            MessageType type = groups.Any(g => g.GroupName == currentReceiver)
                ? MessageType.GroupMessage : MessageType.PrivateMessage;

            MessagePacket packet = new()
            {
                Type = type,
                Sender = username,
                Receiver = currentReceiver,
                Content = message
            };
            client.SendPacket(packet);
            tslTyping.Text = "";

            if (type == MessageType.GroupMessage)
            {
                SaveGroupMessage(currentReceiver!, packet);
                LoadGroupConversation(currentReceiver!);
                LoadGroupInfo(currentReceiver!);
            }
            else
            {
                SaveMessage(currentReceiver!, packet);
                LoadConversation(currentReceiver!);
                LoadFriendInfo(currentReceiver!);
            }

            txbMessage.Clear();
            txbMessage.Focus();
        }
        private void btnMenu_Click(object sender, EventArgs e)
        {
            cmsMenu.Show(btnMenu, 0, btnMenu.Height);
        }
        private void btnEmoji_Click(object sender, EventArgs e)
        {
            using EmojiForm frm = new();

            if (frm.ShowDialog() != DialogResult.OK)
                return;

            txbMessage.Text += frm.SelectedEmoji;
            txbMessage.SelectionStart = txbMessage.Text.Length;
            txbMessage.Focus();
        }
        private void btnFile_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(currentReceiver))
            {
                MessageBox.Show("Please select receiver.");
                return;
            }

            using OpenFileDialog dialog = new();

            dialog.Filter =
                "All Files|*.*|" +
                "PDF|*.pdf|" +
                "Word|*.doc;*.docx|" +
                "Zip|*.zip|" +
                "Images|*.jpg;*.png";

            if (dialog.ShowDialog() != DialogResult.OK)
                return;

            SendFile(dialog.FileName);
        }
        private void btnPicture_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(currentReceiver))
            {
                MessageBox.Show("Please select receiver.");
                return;
            }

            using OpenFileDialog dialog = new();

            dialog.Filter =
                "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif;*.webp";

            if (dialog.ShowDialog() != DialogResult.OK)
                return;

            SendImage(dialog.FileName);
        }
        private void lstFiles_DoubleClick(object sender, EventArgs e)
        {
            if (lstFiles.SelectedIndex < 0)
                return;

            ChatFileItem file = fileHistory[lstFiles.SelectedIndex];
            if (!File.Exists(file.FilePath))
            {
                MessageBox.Show("File not found.");
                return;
            }
            string ext = Path.GetExtension(file.FilePath).ToLower();

            switch (ext)
            {
                case ".jpg":
                case ".jpeg":
                case ".png":
                case ".bmp":
                case ".gif":
                    ImageViewerForm frm = new ImageViewerForm(file.FilePath);
                    frm.ShowDialog();
                    break;

                default:
                    Process.Start(new ProcessStartInfo()
                    {
                        FileName = file.FilePath,
                        UseShellExecute = true
                    });
                    break;
            }
        }
        private void rtbChat_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int index = rtbChat.GetCharIndexFromPosition(e.Location);
            int line = rtbChat.GetLineFromCharIndex(index);

            if (line < 0 || line >= rtbChat.Lines.Length)
                return;

            string text = rtbChat.Lines[line];

            if (!text.Contains("📎") &&
                !text.Contains("🖼"))
                return;

            foreach (ChatFileItem file in fileHistory)
            {
                if (!text.Contains(file.FileName))
                    continue;

                string ext = Path.GetExtension(file.FilePath).ToLower();

                if (ext == ".jpg" ||
                    ext == ".jpeg" ||
                    ext == ".png" ||
                    ext == ".bmp" ||
                    ext == ".gif")
                {
                    ImageViewerForm frm =
                        new ImageViewerForm(file.FilePath);

                    frm.ShowDialog();
                }
                else
                {
                    Process.Start(new ProcessStartInfo()
                    {
                        FileName = file.FilePath,
                        UseShellExecute = true
                    });
                }

                break;
            }
        }
        private void createGroupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateGroupForm frm = new CreateGroupForm(client, username, friends);

            frm.ShowDialog();
        }
        private void btnSreach_Click(object sender, EventArgs e)
        {
            SearchMessages(txbSreach.Text.Trim());
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            txbSreach.Clear();
            currentSearch.Clear();
            currentIndex = -1;

            LoadConversation(currentReceiver);

            tslTyping.Text = "";
        }
        private void btnNext_Click(object sender, EventArgs e)
        {
            if (currentSearch.Count == 0)
                return;

            currentIndex++;

            if (currentIndex >= currentSearch.Count)
                currentIndex = 0;

            ShowSearchResult();
        }
        private void btnPrev_Click(object sender, EventArgs e)
        {
            if (currentSearch.Count == 0)
                return;

            currentIndex--;

            if (currentIndex < 0)
                currentIndex = currentSearch.Count - 1;

            ShowSearchResult();
        }
        #endregion

        #region File packet
        private void ReceiveFileStart(MessagePacket packet)
        {
            FileMessage? file = JsonSerializer.Deserialize<FileMessage>(packet.Content);
            if (file == null)
                return;

            DialogResult result = MessageBox.Show(
                    $"{file.Sender} wants to send\n\n" +
                    $"{file.FileName}\n" +
                    $"{file.FileSize / 1024} KB\n\n" +
                    "Accept?",
                    "Incoming File",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                incomingFiles[file.FileId] = file;
                MessagePacket response = new()
                {
                    Type = MessageType.FileAccept,
                    Sender = username,
                    Receiver = file.Sender,
                    Content = file.FileId.ToString()
                };
                receivingFiles[file.FileId] = new BufferFile()
                {
                    FileId = file.FileId,
                    FileName = file.FileName,
                    Extension = file.Extension,
                    FileSize = file.FileSize
                };
                AddLog($"Receiving '{file.FileName}'...");
                client.SendPacket(response);
            }
            else
            {
                MessagePacket response = new()
                {
                    Type = MessageType.FileReject,
                    Sender = username,
                    Receiver = file.Sender,
                    Content = file.FileId.ToString()
                };

                client.SendPacket(response);
            }
        }
        private void ReceiveFileChunk(MessagePacket packet)
        {
            BufferFile? chunk = JsonSerializer.Deserialize<BufferFile>(packet.Content);
            if (chunk == null)
                return;
            if (!receivingFiles.TryGetValue(chunk.FileId, out BufferFile? file))
                return;
            file.Stream.Write(chunk.Buffer, 0, chunk.Buffer.Length);
        }
        private void ReceiveFileEnd(MessagePacket packet)
        {
            Guid fileId = Guid.Parse(packet.Content);

            if (!receivingFiles.TryGetValue(fileId, out BufferFile? buffer))
                return;

            if (!incomingFiles.TryGetValue(fileId, out FileMessage? info))
                return;

            if (buffer.Stream.Length != info.FileSize)
            {
                MessageBox.Show("File transfer incomplete.");
                return;
            }
            using SaveFileDialog dialog = new();
            dialog.FileName = info.FileName;

            if (dialog.ShowDialog() != DialogResult.OK)
                return;

            File.WriteAllBytes(dialog.FileName, buffer.Stream.ToArray());

            ChatFileItem item = new()
            {
                User = info.Sender,
                FileName = info.FileName,
                FilePath = dialog.FileName,
                FileSize = info.FileSize
            };

            fileHistory.Add(item);
            lstFiles.Items.Add($"↓ {item.FileName}");
            MessagePacket filePacket = new()
            {
                Type = MessageType.FileTransfer,
                Sender = info.Sender,
                Receiver = username,
                Content = $"📎 {info.FileName}\n"
                + $"Size: {info.FileSize / 1024} KB\n"
                + $"(Double click to open)",
                TimeStamp = DateTime.Now
            };

            SaveMessage(info.Sender, filePacket);

            if (currentReceiver == info.Sender)
            {
                LoadConversation(info.Sender);
                LoadFriendInfo(info.Sender);
                rtbChat.SelectionStart = rtbChat.TextLength;
                rtbChat.ScrollToCaret();
            }
            AddLog($"File '{info.FileName}' received successfully.");
            buffer.Stream.Dispose();
            receivingFiles.Remove(fileId);
            incomingFiles.Remove(fileId);
        }
        private void SendFile(string path)
        {
            FileInfo info = new(path);
            FileMessage file = new()
            {
                FileId = Guid.NewGuid(),
                Sender = username,
                Receiver = currentReceiver!,
                FileName = info.Name,
                FileSize = info.Length,
                Extension = info.Extension
            };
            pendingFiles[file.FileId] = path;
            MessagePacket packet = new()
            {
                Type = MessageType.FileStart,
                Sender = username,
                Receiver = currentReceiver!,
                Content = JsonSerializer.Serialize(file)
            };
            client.SendPacket(packet);
        }
        private void StartSendFile(Guid fileId, string path, string receiver)
        {
            FileInfo info = new(path);
            using FileStream fs = new(path, FileMode.Open, FileAccess.Read);
            int totalChunks = (int)Math.Ceiling((double)info.Length / FILE_BUFFER_SIZE);
            byte[] buffer = new byte[FILE_BUFFER_SIZE];
            int index = 0;
            int read;

            AddLog($"Sending {info.Name}...");
            while ((read = fs.Read(buffer, 0, buffer.Length)) > 0)
            {
                byte[] chunk = new byte[read];
                Array.Copy(buffer, chunk, read);
                BufferFile file = new()
                {
                    FileId = fileId,
                    Sender = username,
                    Receiver = receiver,
                    FileName = info.Name,
                    Extension = info.Extension,
                    FileSize = info.Length,
                    ChunkIndex = index,
                    TotalChunks = totalChunks,
                    Buffer = chunk,
                };
                MessagePacket packet = new()
                {
                    Type = MessageType.FileChunk,
                    Sender = username,
                    Receiver = receiver,
                    Content = JsonSerializer.Serialize(file)
                };
                client.SendPacket(packet);
                index++;
            }
            MessagePacket endPacket = new()
            {
                Type = MessageType.FileEnd,
                Sender = username,
                Receiver = receiver,
                Content = fileId.ToString()
            };
            client.SendPacket(endPacket);
            pendingFiles.Remove(fileId);
            AddLog($"File '{info.Name}' sent successfully.");

            ChatFileItem item = new()
            {
                User = username,
                FileName = info.Name,
                FilePath = path,
                FileSize = info.Length
            };

            fileHistory.Add(item);
            lstFiles.Items.Add($"↑ {item.FileName}");
            MessagePacket filePacket = new()
            {
                Type = MessageType.FileTransfer,
                Sender = username,
                Receiver = receiver,
                Content = $"📎 {info.Name}\n" + $"Size: {info.Length / 1024} KB\n" + "(Double click to open)",
                TimeStamp = DateTime.Now
            };

            SaveMessage(receiver, filePacket);
            if (currentReceiver == receiver)
            {
                LoadConversation(receiver);
                LoadFriendInfo(receiver);
                rtbChat.SelectionStart = rtbChat.TextLength;
                rtbChat.ScrollToCaret();
            }
        }
        private void ReceiveFileAccept(MessagePacket packet)
        {
            Guid fileId = Guid.Parse(packet.Content);
            if (!pendingFiles.TryGetValue(fileId, out string? path))
            {
                AddLog("Pending file not found.");
                return;
            }
            AddLog($"{packet.Sender} accepted the file.");
            StartSendFile(fileId, path, packet.Sender);
        }
        private void ReceiveFileReject(MessagePacket packet)
        {
            Guid fileId = Guid.Parse(packet.Content);
            pendingFiles.Remove(fileId);
            AddLog($"{packet.Sender} rejected the file.");

            MessagePacket filePacket = new()
            {
                Type = MessageType.FileTransfer,
                Sender = packet.Sender,
                Receiver = username,
                Content = "File transfer cancelled.",
                TimeStamp = DateTime.Now
            };

            SaveMessage(packet.Sender, filePacket);

            if (currentReceiver == packet.Sender)
            {
                LoadConversation(packet.Sender);
                LoadFriendInfo(packet.Sender);
            }
        }
        #endregion

        #region pic packet
        private void SendImage(string path)
        {
            FileInfo info = new(path);

            FileMessage image = new()
            {
                FileId = Guid.NewGuid(),
                Sender = username,
                Receiver = currentReceiver!,
                FileName = info.Name,
                FileSize = info.Length,
                Extension = info.Extension
            };

            pendingFiles[image.FileId] = path;

            MessagePacket packet = new()
            {
                Type = MessageType.ImageTransfer,
                Sender = username,
                Receiver = currentReceiver!,
                Content = JsonSerializer.Serialize(image)
            };

            client.SendPacket(packet);
        }
        private void ReceiveImageStart(MessagePacket packet)
        {
            FileMessage? file = JsonSerializer.Deserialize<FileMessage>(packet.Content);
            if (file == null)
                return;

            DialogResult result = MessageBox.Show(
                    $"{file.Sender} wants to send\n\n" +
                    $"{file.FileName}\n" +
                    $"{file.FileSize / 1024} KB\n\n" +
                    "Accept?",
                    "Incoming Picture",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                incomingImages[file.FileId] = file;
                MessagePacket response = new()
                {
                    Type = MessageType.ImageAccept,
                    Sender = username,
                    Receiver = file.Sender,
                    Content = file.FileId.ToString()
                };
                receivingImages[file.FileId] = new BufferFile()
                {
                    FileId = file.FileId,
                    FileName = file.FileName,
                    Extension = file.Extension,
                    FileSize = file.FileSize
                };
                AddLog($"Receiving '{file.FileName}'...");
                client.SendPacket(response);
            }
            else
            {
                MessagePacket response = new()
                {
                    Type = MessageType.ImageReject,
                    Sender = username,
                    Receiver = file.Sender,
                    Content = file.FileId.ToString()
                };

                client.SendPacket(response);
            }
        }
        private void ReceiveImageAccept(MessagePacket packet)
        {
            Guid fileId = Guid.Parse(packet.Content);
            if (!pendingFiles.TryGetValue(fileId, out string? path))
            {
                AddLog("Pending file not found.");
                return;
            }
            AddLog($"{packet.Sender} accepted the image.");
            StartSendImage(fileId, path, packet.Sender);
        }
        private void ReceiveImageReject(MessagePacket packet)
        {
            Guid fileId = Guid.Parse(packet.Content);
            pendingFiles.Remove(fileId);
            AddLog($"{packet.Sender} rejected the image.");
        }
        private void StartSendImage(Guid fileId, string path, string receiver)
        {
            FileInfo info = new(path);
            using FileStream fs = new(path, FileMode.Open, FileAccess.Read);
            int totalChunks = (int)Math.Ceiling((double)info.Length / FILE_BUFFER_SIZE);
            byte[] buffer = new byte[FILE_BUFFER_SIZE];
            int index = 0;
            int read;

            AddLog($"Sending {info.Name}...");
            while ((read = fs.Read(buffer, 0, buffer.Length)) > 0)
            {
                byte[] chunk = new byte[read];
                Array.Copy(buffer, chunk, read);
                BufferFile file = new()
                {
                    FileId = fileId,
                    Sender = username,
                    Receiver = receiver,
                    FileName = info.Name,
                    Extension = info.Extension,
                    FileSize = info.Length,
                    ChunkIndex = index,
                    TotalChunks = totalChunks,
                    Buffer = chunk,
                };
                MessagePacket packet = new()
                {
                    Type = MessageType.ImageChunk,
                    Sender = username,
                    Receiver = receiver,
                    Content = JsonSerializer.Serialize(file)
                };
                client.SendPacket(packet);
                index++;
            }
            MessagePacket endPacket = new()
            {
                Type = MessageType.ImageEnd,
                Sender = username,
                Receiver = receiver,
                Content = fileId.ToString()
            };
            client.SendPacket(endPacket);
            pendingFiles.Remove(fileId);
            AddLog($"Image '{info.Name}' sent successfully.");

            ChatFileItem item = new()
            {
                User = username,
                FileName = info.Name,
                FilePath = path,
                FileSize = info.Length
            };

            fileHistory.Add(item);
            lstFiles.Items.Add($"🖼 ↑ {item.FileName}");
            MessagePacket imagePacket = new()
            {
                Type = MessageType.ImageTransfer,
                Sender = username,
                Receiver = receiver,
                Content = $"🖼 {info.Name}\n" + $"Size: {info.Length / 1024} KB\n" + "(Double click to view)",
                TimeStamp = DateTime.Now
            };

            SaveMessage(receiver, imagePacket);
            if (currentReceiver == receiver)
            {
                LoadConversation(receiver);
                LoadFriendInfo(receiver);
                rtbChat.SelectionStart = rtbChat.TextLength;
                rtbChat.ScrollToCaret();
            }
        }
        private void ReceiveImageChunk(MessagePacket packet)
        {
            BufferFile? chunk = JsonSerializer.Deserialize<BufferFile>(packet.Content);
            if (chunk == null)
                return;
            if (!receivingImages.TryGetValue(chunk.FileId, out BufferFile? file))
                return;
            file.Stream.Write(chunk.Buffer, 0, chunk.Buffer.Length);
        }
        private void ReceiveImageEnd(MessagePacket packet)
        {
            Guid fileId = Guid.Parse(packet.Content);
            if (!receivingImages.TryGetValue(fileId, out BufferFile? buffer))
                return;
            if (!incomingImages.TryGetValue(fileId, out FileMessage? info))
                return;
            if (buffer.Stream.Length != info.FileSize)
            {
                MessageBox.Show("Image transfer incomplete.");
                return;
            }
            using SaveFileDialog dialog = new();
            dialog.FileName = info.FileName;

            if (dialog.ShowDialog() != DialogResult.OK)
                return;
            File.WriteAllBytes(dialog.FileName, buffer.Stream.ToArray());

            ChatFileItem item = new()
            {
                User = info.Sender,
                FileName = info.FileName,
                FilePath = dialog.FileName,
                FileSize = info.FileSize
            };

            fileHistory.Add(item);
            lstFiles.Items.Add($"🖼 ↓ {item.FileName}");
            MessagePacket imagePacket = new()
            {
                Type = MessageType.ImageTransfer,
                Sender = info.Sender,
                Receiver = username,
                Content = $"🖼 {info.FileName}\n"
                + $"Size: {info.FileSize / 1024} KB\n"
                + $"(Double click to view)",
                TimeStamp = DateTime.Now
            };

            SaveMessage(info.Sender, imagePacket);

            if (currentReceiver == info.Sender)
            {
                LoadConversation(info.Sender);
                LoadFriendInfo(info.Sender);
                rtbChat.SelectionStart = rtbChat.TextLength;
                rtbChat.ScrollToCaret();
            }
            AddLog($"Image '{info.FileName}' received successfully.");
            buffer.Stream.Dispose();
            receivingImages.Remove(fileId);
            incomingImages.Remove(fileId);
        }
        #endregion

        #region Recall

        private void recallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(currentReceiver))
                return;

            if (!conversations.ContainsKey(currentReceiver))
                return;

            MessagePacket? last =
                conversations[currentReceiver]
                .LastOrDefault(x => x.Sender == username);

            if (last == null)
                return;

            RecallPacket recall = new()
            {
                MessageId = last.MessageId,
                Sender = username,
                Receiver = currentReceiver
            };

            MessagePacket packet = new()
            {
                Type = MessageType.RecallMessage,
                Sender = username,
                Receiver = currentReceiver,
                Content = JsonSerializer.Serialize(recall)
            };

            client.SendPacket(packet);
        }
        private void ReceiveRecall(MessagePacket packet)
        {
            RecallPacket? recall =
                JsonSerializer.Deserialize<RecallPacket>(packet.Content);

            if (recall == null)
                return;

            string key = recall.Sender == username
                    ? recall.Receiver : recall.Sender;

            if (!conversations.TryGetValue(key, out var list))
                return;

            MessagePacket? message =
                list.FirstOrDefault(x => x.MessageId == recall.MessageId);

            if (message == null)
                return;

            message.Content = "This message has been recalled.";

            if (currentReceiver == key)
            {
                LoadConversation(key);
                LoadFriendInfo(key);
            }
        }
        #endregion

        private void lstFiles_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void rtbChat_TextChanged(object sender, EventArgs e)
        {

        }
        private void txbMessage_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(currentReceiver))
                return;

            if (string.IsNullOrWhiteSpace(txbMessage.Text))
                return;

            MessagePacket packet = new()
            {
                Type = MessageType.Typing,
                Sender = username,
                Receiver = currentReceiver,
                Content = ""
            };

            client.SendPacket(packet);
        }
        private void ReceiveTyping(MessagePacket packet)
        {
            if (currentReceiver != packet.Sender)
                return;

            tslTyping.Text = $"{packet.Sender} is typing...";
        }
        #region chat
        private string RightAlign(string text)
        {
            const int width = 140;

            if (text.Length >= width)
                return text;

            return new string(' ', width - text.Length) + text;
        }
        private void SearchMessages(string keyword)
        {
            currentSearch.Clear();
            currentIndex = -1;

            if (string.IsNullOrWhiteSpace(keyword))
                return;

            if (!conversations.ContainsKey(currentReceiver))
                return;

            currentSearch = conversations[currentReceiver]
                .Where(x =>
                    x.Content.Contains(
                        keyword,
                        StringComparison.OrdinalIgnoreCase))
                .ToList();

            if (currentSearch.Count == 0)
            {
                MessageBox.Show("No messages found.");
                return;
            }

            currentIndex = 0;

            ShowSearchResult();
        }
        private void ShowSearchResult()
        {
            if (currentIndex < 0)
                return;

            MessagePacket msg =
                currentSearch[currentIndex];

            LoadConversation(currentReceiver);

            string text =
                msg.Content;

            int start =
                rtbChat.Text.IndexOf(
                    text,
                    StringComparison.OrdinalIgnoreCase);

            if (start >= 0)
            {
                rtbChat.SelectionStart = start;
                rtbChat.SelectionLength = text.Length;
                rtbChat.ScrollToCaret();
                rtbChat.Focus();
            }

            tslTyping.Text =
                $"Result {currentIndex + 1}/{currentSearch.Count}";
        }
        #endregion
    }
}
