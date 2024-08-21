using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using NetMQ;
using NetMQ.Sockets;

namespace ChatClientApp
{
    public partial class MainForm : XtraForm
    {
        private DealerSocket clientSocket;
        private string username;
        private string serverAddress = "tcp://localhost:5555";
        private Dictionary<string, string> onlineUsers = new Dictionary<string, string>();

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            username = XtraInputBox.Show("Enter your username:", "Username", "");

            if (string.IsNullOrWhiteSpace(username))
            {
                MessageBox.Show("Username cannot be empty.");
                this.Close();
                return;
            }

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

            onlineUsersListBox.Items.Clear();
            onlineUsersListBox.Items.AddRange(users);
        }
    }
}