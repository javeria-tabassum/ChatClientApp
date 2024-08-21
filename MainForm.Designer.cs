namespace ChatClientApp
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private DevExpress.XtraEditors.ListBoxControl onlineUsersListBox;
        private DevExpress.XtraEditors.TextEdit recipientTextBox;
        private DevExpress.XtraEditors.TextEdit messageTextBox;
        private DevExpress.XtraEditors.SimpleButton sendButton;
        private DevExpress.XtraEditors.MemoEdit chatMemoEdit;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.onlineUsersListBox = new DevExpress.XtraEditors.ListBoxControl();
            this.recipientTextBox = new DevExpress.XtraEditors.TextEdit();
            this.messageTextBox = new DevExpress.XtraEditors.TextEdit();
            this.sendButton = new DevExpress.XtraEditors.SimpleButton();
            this.chatMemoEdit = new DevExpress.XtraEditors.MemoEdit();
            ((System.ComponentModel.ISupportInitialize)(this.onlineUsersListBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.recipientTextBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.messageTextBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chatMemoEdit.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // onlineUsersListBox
            // 
            this.onlineUsersListBox.Location = new System.Drawing.Point(12, 12);
            this.onlineUsersListBox.Name = "onlineUsersListBox";
            this.onlineUsersListBox.Size = new System.Drawing.Size(200, 290);
            this.onlineUsersListBox.TabIndex = 0;
            // 
            // recipientTextBox
            // 
            this.recipientTextBox.Location = new System.Drawing.Point(220, 12);
            this.recipientTextBox.Name = "recipientTextBox";
            this.recipientTextBox.Size = new System.Drawing.Size(200, 20);
            this.recipientTextBox.TabIndex = 1;
            this.recipientTextBox.Properties.NullValuePrompt = "Recipient";
            // 
            // messageTextBox
            // 
            this.messageTextBox.Location = new System.Drawing.Point(220, 38);
            this.messageTextBox.Name = "messageTextBox";
            this.messageTextBox.Size = new System.Drawing.Size(200, 20);
            this.messageTextBox.TabIndex = 2;
            this.messageTextBox.Properties.NullValuePrompt = "Message";
            // 
            // sendButton
            // 
            this.sendButton.Location = new System.Drawing.Point(220, 64);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(200, 23);
            this.sendButton.TabIndex = 3;
            this.sendButton.Text = "Send";
            this.sendButton.Click += new System.EventHandler(this.sendButton_Click);
            // 
            // chatMemoEdit
            // 
            this.chatMemoEdit.Location = new System.Drawing.Point(220, 93);
            this.chatMemoEdit.Name = "chatMemoEdit";
            this.chatMemoEdit.Size = new System.Drawing.Size(200, 209);
            this.chatMemoEdit.TabIndex = 4;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 311);
            this.Controls.Add(this.chatMemoEdit);
            this.Controls.Add(this.sendButton);
            this.Controls.Add(this.messageTextBox);
            this.Controls.Add(this.recipientTextBox);
            this.Controls.Add(this.onlineUsersListBox);
            this.Name = "MainForm";
            this.Text = "Chat Client";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.onlineUsersListBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.recipientTextBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.messageTextBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chatMemoEdit.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}