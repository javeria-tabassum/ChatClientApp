namespace ChatClientApp
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private DevExpress.XtraEditors.ListBoxControl onlineUsersListBox;
        private DevExpress.XtraEditors.TextEdit recipientTextBox;
        private DevExpress.XtraEditors.MemoEdit messageTextBox;
        private DevExpress.XtraEditors.SimpleButton sendButton;
        private DevExpress.XtraEditors.MemoEdit chatMemoEdit;
        private DevExpress.Utils.Layout.TablePanel tablePanel;

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
            this.onlineUsersListBox = new DevExpress.XtraEditors.ListBoxControl();
            this.recipientTextBox = new DevExpress.XtraEditors.TextEdit();
            this.messageTextBox = new DevExpress.XtraEditors.MemoEdit();
            this.sendButton = new DevExpress.XtraEditors.SimpleButton();
            this.chatMemoEdit = new DevExpress.XtraEditors.MemoEdit();
            this.tablePanel = new DevExpress.Utils.Layout.TablePanel();
            ((System.ComponentModel.ISupportInitialize)(this.onlineUsersListBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.recipientTextBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.messageTextBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chatMemoEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel)).BeginInit();
            this.tablePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // onlineUsersListBox
            // 
            this.tablePanel.SetColumn(this.onlineUsersListBox, 0);
            this.onlineUsersListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.onlineUsersListBox.Location = new System.Drawing.Point(3, 3);
            this.onlineUsersListBox.Name = "onlineUsersListBox";
            this.tablePanel.SetRow(this.onlineUsersListBox, 0);
            this.tablePanel.SetRowSpan(this.onlineUsersListBox, 4);
            this.onlineUsersListBox.Size = new System.Drawing.Size(124, 305);
            this.onlineUsersListBox.TabIndex = 0;
            // 
            // recipientTextBox
            // 
            this.tablePanel.SetColumn(this.recipientTextBox, 1);
            this.recipientTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.recipientTextBox.Location = new System.Drawing.Point(133, 3);
            this.recipientTextBox.Name = "recipientTextBox";
            this.recipientTextBox.Properties.NullValuePrompt = "Recipient";
            this.tablePanel.SetRow(this.recipientTextBox, 0);
            this.recipientTextBox.Size = new System.Drawing.Size(298, 20);
            this.recipientTextBox.TabIndex = 1;
            // 
            // messageTextBox
            // 
            this.tablePanel.SetColumn(this.messageTextBox, 1);
            this.messageTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.messageTextBox.Location = new System.Drawing.Point(133, 27);
            this.messageTextBox.Name = "messageTextBox";
            this.messageTextBox.Properties.NullValuePrompt = "Message";
            this.tablePanel.SetRow(this.messageTextBox, 1);
            this.messageTextBox.Size = new System.Drawing.Size(298, 20);
            this.messageTextBox.TabIndex = 2;
            // 
            // sendButton
            // 
            this.tablePanel.SetColumn(this.sendButton, 1);
            this.sendButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sendButton.Location = new System.Drawing.Point(133, 51);
            this.sendButton.Name = "sendButton";
            this.tablePanel.SetRow(this.sendButton, 2);
            this.sendButton.Size = new System.Drawing.Size(298, 18);
            this.sendButton.TabIndex = 3;
            this.sendButton.Text = "Send";
            this.sendButton.Click += new System.EventHandler(this.sendButton_Click);
            // 
            // chatMemoEdit
            // 
            this.tablePanel.SetColumn(this.chatMemoEdit, 1);
            this.chatMemoEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chatMemoEdit.Location = new System.Drawing.Point(133, 75);
            this.chatMemoEdit.Name = "chatMemoEdit";
            this.tablePanel.SetRow(this.chatMemoEdit, 3);
            this.chatMemoEdit.Size = new System.Drawing.Size(298, 233);
            this.chatMemoEdit.TabIndex = 4;
            // 
            // tablePanel
            // 
            this.tablePanel.Columns.AddRange(new DevExpress.Utils.Layout.TablePanelColumn[] {
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 30F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 70F)});
            this.tablePanel.Controls.Add(this.onlineUsersListBox);
            this.tablePanel.Controls.Add(this.recipientTextBox);
            this.tablePanel.Controls.Add(this.messageTextBox);
            this.tablePanel.Controls.Add(this.sendButton);
            this.tablePanel.Controls.Add(this.chatMemoEdit);
            this.tablePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tablePanel.Location = new System.Drawing.Point(0, 0);
            this.tablePanel.Name = "tablePanel";
            this.tablePanel.Rows.AddRange(new DevExpress.Utils.Layout.TablePanelRow[] {
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 24F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 24F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 24F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 100F)});
            this.tablePanel.Size = new System.Drawing.Size(434, 311);
            this.tablePanel.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 311);
            this.Controls.Add(this.tablePanel);
            this.IconOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("MainForm.IconOptions.LargeImage")));
            this.Name = "MainForm";
            this.Text = "Chat Client";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.onlineUsersListBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.recipientTextBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.messageTextBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chatMemoEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel)).EndInit();
            this.tablePanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }
    }
}