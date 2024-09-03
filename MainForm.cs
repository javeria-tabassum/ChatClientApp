using DevExpress.XtraEditors;
using NetMQ;
using NetMQ.Sockets;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatClientApp
{
    public partial class MainForm : XtraForm
    {
        private string username;
        private string serverAddress = "tcp://localhost:5555";
        private string currentRecipient;
        private Timer heartbeatTimer;
        private Timer serverCheckTimer;
        private DealerSocket clientSocket;
        private HashSet<string> allUsers = new HashSet<string>();
        private HashSet<string> offlineUsers = new HashSet<string>();
        private Dictionary<string, bool> onlineUsers = new Dictionary<string, bool>();
        private bool serverIsConnected;
        private DateTime lastServerResponseTime;
        private ImageList statusImageList;

        public MainForm()
        {
            InitializeComponent();
            InitializeStatusImageList();
            InitializeHeartbeatTimer();
            InitializeServerCheckTimer();
        }

        private void InitializeStatusImageList()
        {
            statusImageList = new ImageList();
            string basePath = AppDomain.CurrentDomain.BaseDirectory;
            string onlineImagePath = Path.Combine(basePath, "images/green_dot.png");
            string offlineImagePath = Path.Combine(basePath, "images/red_dot.png");
            statusImageList.Images.Add("online", Image.FromFile(onlineImagePath));
            statusImageList.Images.Add("offline", Image.FromFile(offlineImagePath));
            UsersListBox.DrawItem += UsersListBox_DrawItem;
            UsersListBox.ItemHeight = statusImageList.ImageSize.Height + 2;
        }

        private void InitializeHeartbeatTimer()
        {
            heartbeatTimer = new Timer();
            heartbeatTimer.Interval = 1000;
            heartbeatTimer.Tick += (sender, e) => HeartbeatTimer_Tick();
            heartbeatTimer.Start();
        }

        private void InitializeServerCheckTimer()
        {
            serverCheckTimer = new Timer();
            serverCheckTimer.Interval = 2000;
            serverCheckTimer.Tick += (sender, e) => ServerCheckTimer_Tick();
            serverCheckTimer.Start();
        }

        private void HeartbeatTimer_Tick()
        {
                SendMessage("PING", username);
        }

        private void ServerCheckTimer_Tick()
        {
            if (serverIsConnected)
            {
                TimeSpan timeSinceLastResponse = DateTime.Now - lastServerResponseTime;
                if (timeSinceLastResponse.TotalMilliseconds > 3000)
                {
                    serverIsConnected = false;
                    MarkAllUsersOffline();
                    Console.WriteLine("Server is considered disconnected.");
                    SendMessage("RECONNECT", username);
                }
            }
            else
            {
                MarkAllUsersOffline();
                Console.WriteLine("Server is still disconnected.");
            }
        }

        private void UsersListBox_DrawItem(object sender, ListBoxDrawItemEventArgs e)
        {
            e.Appearance.DrawBackground(e.Cache, e.Bounds);
            if (e.Index < 0) return;

            string user = e.Item.ToString();
            bool isOnline = onlineUsers.ContainsKey(user) && onlineUsers[user];
            Image statusImage = isOnline ? statusImageList.Images["online"] : statusImageList.Images["offline"];
            e.Cache.Graphics.DrawImage(statusImage, e.Bounds.Location);
            Rectangle textRect = new Rectangle(e.Bounds.X + statusImage.Width + 2, e.Bounds.Y, e.Bounds.Width - statusImage.Width - 2, e.Bounds.Height);
            e.Appearance.DrawString(e.Cache, user, textRect);
            e.Handled = true;
        }

        private async void MainForm_Load(object sender, EventArgs e)
        {
            DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle("The Bezier");
            username = XtraInputBox.Show("Enter your username:", "Username", "");
            if (string.IsNullOrWhiteSpace(username))
            {
                MessageBox.Show("Username cannot be empty.");
                this.Close();
                return;
            }

            this.Text = "ChatBox" + " - " + username;
            allUsers.Add(username);
            onlineUsers[username] = true;
            clientSocket = new DealerSocket();
            clientSocket.Options.Identity = System.Text.Encoding.UTF8.GetBytes(username);
            clientSocket.Connect(serverAddress);
            var poller = new NetMQPoller { clientSocket };
            clientSocket.ReceiveReady += ClientSocket_ReceiveReady;
            poller.RunAsync();
            SendMessage("CONNECT", username);
            UpdateOnlineUsers(allUsers.ToArray());
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SendMessage("DISCONNECT", username);
            onlineUsers[username] = false;
            clientSocket.Disconnect(serverAddress);
            clientSocket.Close();
            RefreshUserList();
        }

        private void sendButton_Click(object sender, EventArgs e)
        {
            string message = messageTextBox.Text;
            if (string.IsNullOrWhiteSpace(currentRecipient) || string.IsNullOrWhiteSpace(message))
            {
                MessageBox.Show("Recipient and message cannot be empty.");
                return;
            }

            if (currentRecipient == username)
            {
                MessageBox.Show("You cannot send a message to yourself.");
            }
            else if (onlineUsers.ContainsKey(currentRecipient) && onlineUsers[currentRecipient])
            {
                SendMessage("MESSAGE", $"{currentRecipient}:{message}");
                AppendChatMessage(currentRecipient, username, message);
                messageTextBox.Text = string.Empty;
            }
            else
            {
                MessageBox.Show($"{currentRecipient} is offline.");
            }
        }

        private void ClientSocket_ReceiveReady(object sender, NetMQSocketEventArgs e)
        {
            var messageType = e.Socket.ReceiveFrameString();
            var message = e.Socket.ReceiveFrameString();
            HandleReceivedMessage(messageType, message);
        }

        private void HandleReceivedMessage(string messageType, string message)
        {
            if (messageType == "MESSAGE")
            {
                var parts = message.Split(new[] { ':' }, 2);
                if (parts.Length == 2)
                {
                    var senderUsername = parts[0];
                    var chatMessage = parts[1];
                    AppendChatMessage(senderUsername, senderUsername, chatMessage);
                }
            }
            else if (messageType == "ONLINE_USERS")
            {
                var users = message.Split(',');
                UpdateOnlineUsers(users);
                serverIsConnected = true;
                lastServerResponseTime = DateTime.Now;
                Console.WriteLine("Server response received: ONLINE_USERS");
            }
            else if (messageType == "PONG")
            {
                serverIsConnected = true;
                lastServerResponseTime = DateTime.Now;
                Console.WriteLine("Server response received: PONG");
            }
        }

        private void AddChatTab(string recipient)
        {
            var existingTab = chatTabControl.TabPages.FirstOrDefault(tp => tp.Text == recipient);
            if (existingTab != null)
            {
                chatTabControl.SelectedTabPage = existingTab;
                return;
            }

            var newTab = new DevExpress.XtraTab.XtraTabPage { Text = recipient, Name = $"tab_{recipient}", Size = new Size(486, 255) };
            var chatMemo = new DevExpress.XtraEditors.MemoEdit { Dock = DockStyle.Fill, ReadOnly = true, Name = $"memo_{recipient}" };
            newTab.Controls.Add(chatMemo);
            chatTabControl.TabPages.Add(newTab);
            chatTabControl.SelectedTabPage = newTab;
        }

        private void AppendChatMessage(string recipient, string senderUsername, string message)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => AppendChatMessage(recipient, senderUsername, message)));
                return;
            }

            var tab = chatTabControl.TabPages.FirstOrDefault(tp => tp.Text == recipient);
            if (tab != null)
            {
                var chatMemo = tab.Controls.OfType<MemoEdit>().FirstOrDefault();
                chatMemo?.AppendText($"{senderUsername}: {message}{Environment.NewLine}");
            }
            else
            {
                AddChatTab(recipient);
                AppendChatMessage(recipient, senderUsername, message);
            }
        }

        private void SendMessage(string messageType, string message)
        {
            if (clientSocket != null)
            {
                clientSocket.SendMoreFrame(messageType).SendFrame(message);
            }
        }

        private void RefreshUserList()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(RefreshUserList));
                return;
            }
            var selectedItem = UsersListBox.SelectedItem;
            var currentItems = new List<string>(UsersListBox.Items.Cast<string>());
            UsersListBox.Items.Clear();
            foreach (var user in allUsers)
            {
                if (!UsersListBox.Items.Contains(user))
                    UsersListBox.Items.Add(user);
            }
            if (selectedItem != null && UsersListBox.Items.Contains(selectedItem))
                UsersListBox.SelectedItem = selectedItem;
        }

        private void UpdateOnlineUsers(string[] users)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => UpdateOnlineUsers(users)));
            }
            var updatedUsers = new HashSet<string>(users);
            foreach (var user in onlineUsers.Keys.ToList())
            {
                if (!updatedUsers.Contains(user))
                    onlineUsers[user] = false;
            }
            foreach (var user in updatedUsers)
            {
                onlineUsers[user] = true;
                if (!allUsers.Contains(user))
                    allUsers.Add(user);
            }

            RefreshUserList();
        }

        private void UpdateOfflineUsers(string[] users)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => UpdateOfflineUsers(users)));
            }
            var updatedUsers = new HashSet<string>(users);
            foreach (var user in onlineUsers.Keys.ToList())
            {
                if (!updatedUsers.Contains(user))
                    onlineUsers[user] = false;
            }
            foreach (var user in updatedUsers)
            {
                onlineUsers[user] = true;
                if (!allUsers.Contains(user))
                    allUsers.Add(user);
            }

            RefreshUserList();
        }

        private void MarkAllUsersOffline()
        {
            foreach (var user in onlineUsers.Keys.ToList())
            {
                onlineUsers[user] = false;
            }
            RefreshUserList();
        }

        private void UsersListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (UsersListBox.SelectedItem != null)
                currentRecipient = UsersListBox.SelectedItem.ToString();
            var tabToSelect = chatTabControl.TabPages.FirstOrDefault(tp => tp.Text == currentRecipient);
            if (tabToSelect != null)
                chatTabControl.SelectedTabPage = tabToSelect;
        }

        private void chatTabControl_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            if (e.Page != null)
                currentRecipient = e.Page.Text;
            UsersListBox.SelectedItem = currentRecipient;
        }
    }
}