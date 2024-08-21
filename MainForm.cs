using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using NetMQ;
using NetMQ.Sockets;

namespace ChatClientApp
{
    public partial class MainForm : XtraForm
    {
        private DealerSocket clientSocket;
        private string username;
        private string serverAddress = "tcp://localhost:5555";
        private Dictionary<string, bool> onlineUsers = new Dictionary<string, bool>();
<<<<<<< HEAD
=======

>>>>>>> 0d44d1bea6ab0d1c5034fdfa436e905c9b6b0a2c
        private ImageList statusImageList;

        public MainForm()
        {
            InitializeComponent();
            InitializeStatusImageList();
        }

        private void InitializeStatusImageList()
        {
            statusImageList = new ImageList();
            string basePath = AppDomain.CurrentDomain.BaseDirectory;
            string onlineImagePath = Path.Combine(basePath, "images/green_dot.png");
            string offlineImagePath = Path.Combine(basePath, "images/red_dot.png");

            statusImageList.Images.Add("online", Image.FromFile(onlineImagePath));
            statusImageList.Images.Add("offline", Image.FromFile(offlineImagePath));

            onlineUsersListBox.DrawItem += OnlineUsersListBox_DrawItem;
            onlineUsersListBox.ItemHeight = statusImageList.ImageSize.Height + 2; // Adjust item height based on image size
        }

        private void OnlineUsersListBox_DrawItem(object sender, ListBoxDrawItemEventArgs e)
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

        private void MainForm_Load(object sender, EventArgs e)
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

            clientSocket = new DealerSocket();
            clientSocket.Options.Identity = System.Text.Encoding.UTF8.GetBytes(username);
            clientSocket.Connect(serverAddress);

            var poller = new NetMQPoller { clientSocket };
            clientSocket.ReceiveReady += ClientSocket_ReceiveReady;
            poller.RunAsync();

            SendMessage("CONNECT", username);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SendMessage("DISCONNECT", username);
            clientSocket.Disconnect(serverAddress);
            clientSocket.Close();
        }

        private void sendButton_Click(object sender, EventArgs e)
        {
            string recipient = recipientTextBox.Text;
            string message = messageTextBox.Text;

            if (string.IsNullOrWhiteSpace(recipient) || string.IsNullOrWhiteSpace(message))
            {
                MessageBox.Show("Recipient and message cannot be empty.");
                return;
            }

            SendMessage("MESSAGE", $"{recipient}:{message}");
            AppendChatMessage(username, message); // Show the sender's name before the message
            messageTextBox.Text = string.Empty;
        }

        private void SendMessage(string messageType, string message)
        {
            clientSocket.SendMoreFrame(messageType).SendFrame(message);
        }

        private void ClientSocket_ReceiveReady(object sender, NetMQSocketEventArgs e)
        {
            var messageType = e.Socket.ReceiveFrameString();
            var message = e.Socket.ReceiveFrameString();

            if (messageType == "MESSAGE")
            {
                var parts = message.Split(new[] { ':' }, 2);
                if (parts.Length == 2)
                {
                    var senderUsername = parts[0];
                    var chatMessage = parts[1];
                    AppendChatMessage(senderUsername, chatMessage);
                }
            }
            else if (messageType == "ONLINE_USERS")
            {
                var users = message.Split(',');
                UpdateOnlineUsers(users);
            }
        }

        private void AppendChatMessage(string senderUsername, string message)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => AppendChatMessage(senderUsername, message)));
                return;
            }

            chatMemoEdit.Text += $"{senderUsername}: {message}{Environment.NewLine}";
        }

        private void UpdateOnlineUsers(string[] users)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => UpdateOnlineUsers(users)));
                return;
            }

            foreach (var key in onlineUsers.Keys.ToList())
            {
                onlineUsers[key] = false;
            }

            foreach (var user in users)
            {
                onlineUsers[user] = true;
            }

            onlineUsersListBox.Items.Clear();
            foreach (var user in onlineUsers.Keys)
            {
                onlineUsersListBox.Items.Add(user);
            }
        }
    } }