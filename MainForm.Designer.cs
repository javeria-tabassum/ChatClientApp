namespace ChatClientApp
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private DevExpress.XtraEditors.MemoEdit chatMemoEdit;
        private DevExpress.XtraEditors.SimpleButton sendButton;
        private DevExpress.XtraEditors.MemoEdit messageTextBox;
        private DevExpress.XtraEditors.ListBoxControl onlineUsersListBox;
        private DevExpress.XtraEditors.ComboBoxEdit recipientComboBox;
        private DevExpress.XtraEditors.LabelControl onlineUsersLabel;
        private DevExpress.XtraEditors.LabelControl label1;
        private DevExpress.XtraEditors.LabelControl label2;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.recipientComboBox = new DevExpress.XtraEditors.ComboBoxEdit();
            this.chatMemoEdit = new DevExpress.XtraEditors.MemoEdit();
            this.sendButton = new DevExpress.XtraEditors.SimpleButton();
            this.messageTextBox = new DevExpress.XtraEditors.MemoEdit();
            this.onlineUsersListBox = new DevExpress.XtraEditors.ListBoxControl();
            this.onlineUsersLabel = new DevExpress.XtraEditors.LabelControl();
            this.label1 = new DevExpress.XtraEditors.LabelControl();
            this.label2 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.recipientComboBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chatMemoEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.messageTextBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.onlineUsersListBox)).BeginInit();
            this.SuspendLayout();
            // 
            // recipientComboBox
            // 
            this.recipientComboBox.Location = new System.Drawing.Point(127, 32);
            this.recipientComboBox.Name = "recipientComboBox";
            this.recipientComboBox.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.recipientComboBox.Size = new System.Drawing.Size(330, 20);
            this.recipientComboBox.TabIndex = 0;
            // 
            // chatMemoEdit
            // 
            this.chatMemoEdit.Location = new System.Drawing.Point(12, 93);
            this.chatMemoEdit.Name = "chatMemoEdit";
            this.chatMemoEdit.Properties.ReadOnly = true;
            this.chatMemoEdit.Size = new System.Drawing.Size(490, 259);
            this.chatMemoEdit.TabIndex = 1;
            // 
            // sendButton
            // 
            this.sendButton.Location = new System.Drawing.Point(427, 372);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(75, 42);
            this.sendButton.TabIndex = 2;
            this.sendButton.Text = "Send";
            this.sendButton.Click += new System.EventHandler(this.sendButton_Click);
            // 
            // messageTextBox
            // 
            this.messageTextBox.EditValue = "Type your message here...";
            this.messageTextBox.Location = new System.Drawing.Point(12, 372);
            this.messageTextBox.Name = "messageTextBox";
            this.messageTextBox.Properties.Appearance.ForeColor = System.Drawing.Color.Gray;
            this.messageTextBox.Properties.Appearance.Options.UseForeColor = true;
            this.messageTextBox.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.messageTextBox.Properties.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.messageTextBox.Size = new System.Drawing.Size(409, 43);
            this.messageTextBox.TabIndex = 3;
            // 
            // onlineUsersListBox
            // 
            this.onlineUsersListBox.Location = new System.Drawing.Point(520, 54);
            this.onlineUsersListBox.Name = "onlineUsersListBox";
            this.onlineUsersListBox.Size = new System.Drawing.Size(194, 360);
            this.onlineUsersListBox.TabIndex = 4;
            // 
            // onlineUsersLabel
            // 
            this.onlineUsersLabel.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.onlineUsersLabel.Appearance.Options.UseFont = true;
            this.onlineUsersLabel.Location = new System.Drawing.Point(517, 32);
            this.onlineUsersLabel.Name = "onlineUsersLabel";
            this.onlineUsersLabel.Size = new System.Drawing.Size(67, 14);
            this.onlineUsersLabel.TabIndex = 5;
            this.onlineUsersLabel.Text = "Online Users";
            // 
            // label1
            // 
            this.label1.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Appearance.Options.UseFont = true;
            this.label1.Location = new System.Drawing.Point(12, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 14);
            this.label1.TabIndex = 6;
            this.label1.Text = "Select Recipient";
            // 
            // label2
            // 
            this.label2.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Appearance.Options.UseFont = true;
            this.label2.Location = new System.Drawing.Point(12, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 14);
            this.label2.TabIndex = 7;
            this.label2.Text = "Messages";
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(748, 433);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.onlineUsersLabel);
            this.Controls.Add(this.onlineUsersListBox);
            this.Controls.Add(this.messageTextBox);
            this.Controls.Add(this.sendButton);
            this.Controls.Add(this.chatMemoEdit);
            this.Controls.Add(this.recipientComboBox);
            this.IconOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("MainForm.IconOptions.LargeImage")));
            this.Name = "MainForm";
            this.Text = "Chat Client";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.recipientComboBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chatMemoEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.messageTextBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.onlineUsersListBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}