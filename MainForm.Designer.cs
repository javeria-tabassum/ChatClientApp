namespace ChatClientApp
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private DevExpress.XtraTab.XtraTabControl chatTabControl;
        private DevExpress.XtraEditors.MemoEdit messageTextBox;
        private DevExpress.XtraEditors.SimpleButton sendButton;
        private DevExpress.XtraEditors.ListBoxControl UsersListBox;
        private DevExpress.XtraEditors.ComboBoxEdit recipientComboBox;
        private System.Windows.Forms.Panel inputPanel;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.chatTabControl = new DevExpress.XtraTab.XtraTabControl();
            this.UsersListBox = new DevExpress.XtraEditors.ListBoxControl();
            this.messageTextBox = new DevExpress.XtraEditors.MemoEdit();
            this.sendButton = new DevExpress.XtraEditors.SimpleButton();
            this.recipientComboBox = new DevExpress.XtraEditors.ComboBoxEdit();
            this.inputPanel = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.chatTabControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UsersListBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.messageTextBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.recipientComboBox.Properties)).BeginInit();
            this.inputPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // chatTabControl
            // 
            this.chatTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chatTabControl.Location = new System.Drawing.Point(175, 0);
            this.chatTabControl.Name = "chatTabControl";
            this.chatTabControl.Size = new System.Drawing.Size(588, 421);
            this.chatTabControl.TabIndex = 0;
            this.chatTabControl.SelectedPageChanged += new DevExpress.XtraTab.TabPageChangedEventHandler(this.chatTabControl_SelectedPageChanged);
            // 
            // UsersListBox
            // 
            this.UsersListBox.Dock = System.Windows.Forms.DockStyle.Left;
            this.UsersListBox.Location = new System.Drawing.Point(0, 0);
            this.UsersListBox.Name = "UsersListBox";
            this.UsersListBox.Size = new System.Drawing.Size(175, 471);
            this.UsersListBox.TabIndex = 1;
            this.UsersListBox.SelectedIndexChanged += new System.EventHandler(this.UsersListBox_SelectedIndexChanged);
            // 
            // messageTextBox
            // 
            this.messageTextBox.EditValue = "Type your message here...";
            this.messageTextBox.Location = new System.Drawing.Point(0, 0);
            this.messageTextBox.Name = "messageTextBox";
            this.messageTextBox.Size = new System.Drawing.Size(509, 47);
            this.messageTextBox.TabIndex = 2;
            // 
            // sendButton
            // 
            this.sendButton.Location = new System.Drawing.Point(515, 0);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(73, 47);
            this.sendButton.TabIndex = 3;
            this.sendButton.Text = "Send";
            this.sendButton.Click += new System.EventHandler(this.sendButton_Click);
            // 
            // recipientComboBox
            // 
            this.recipientComboBox.Location = new System.Drawing.Point(175, 65);
            this.recipientComboBox.Name = "recipientComboBox";
            this.recipientComboBox.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.recipientComboBox.Size = new System.Drawing.Size(525, 22);
            this.recipientComboBox.TabIndex = 4;
            // 
            // inputPanel
            // 
            this.inputPanel.Controls.Add(this.messageTextBox);
            this.inputPanel.Controls.Add(this.sendButton);
            this.inputPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.inputPanel.Location = new System.Drawing.Point(175, 421);
            this.inputPanel.Name = "inputPanel";
            this.inputPanel.Size = new System.Drawing.Size(588, 50);
            this.inputPanel.TabIndex = 5;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(763, 471);
            this.Controls.Add(this.chatTabControl);
            this.Controls.Add(this.recipientComboBox);
            this.Controls.Add(this.inputPanel);
            this.Controls.Add(this.UsersListBox);
            this.IconOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("MainForm.IconOptions.LargeImage")));
            this.Name = "MainForm";
            this.Text = "Chat Application";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chatTabControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UsersListBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.messageTextBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.recipientComboBox.Properties)).EndInit();
            this.inputPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }
    }
}
