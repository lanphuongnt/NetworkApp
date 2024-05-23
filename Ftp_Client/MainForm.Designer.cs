namespace Ftp_Client
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.inforServerConnectPanel = new System.Windows.Forms.Panel();
            this.connectButton = new System.Windows.Forms.Button();
            this.passwdTextBox = new System.Windows.Forms.TextBox();
            this.usernameTextBox = new System.Windows.Forms.TextBox();
            this.hostTextBox = new System.Windows.Forms.TextBox();
            this.passwdLabel = new System.Windows.Forms.Label();
            this.portTextBox = new System.Windows.Forms.TextBox();
            this.usernameLabel = new System.Windows.Forms.Label();
            this.portLabel = new System.Windows.Forms.Label();
            this.hostLabel = new System.Windows.Forms.Label();
            this.mainContainer = new System.Windows.Forms.SplitContainer();
            this.mainsiteContainer = new System.Windows.Forms.SplitContainer();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.serverToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reconnectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.disconnectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.userToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.registerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inforServerConnectPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainContainer)).BeginInit();
            this.mainContainer.Panel1.SuspendLayout();
            this.mainContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainsiteContainer)).BeginInit();
            this.mainsiteContainer.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // inforServerConnectPanel
            // 
            this.inforServerConnectPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.inforServerConnectPanel.BackColor = System.Drawing.Color.Gainsboro;
            this.inforServerConnectPanel.Controls.Add(this.connectButton);
            this.inforServerConnectPanel.Controls.Add(this.passwdTextBox);
            this.inforServerConnectPanel.Controls.Add(this.usernameTextBox);
            this.inforServerConnectPanel.Controls.Add(this.hostTextBox);
            this.inforServerConnectPanel.Controls.Add(this.passwdLabel);
            this.inforServerConnectPanel.Controls.Add(this.portTextBox);
            this.inforServerConnectPanel.Controls.Add(this.usernameLabel);
            this.inforServerConnectPanel.Controls.Add(this.portLabel);
            this.inforServerConnectPanel.Controls.Add(this.hostLabel);
            this.inforServerConnectPanel.Location = new System.Drawing.Point(0, 44);
            this.inforServerConnectPanel.Name = "inforServerConnectPanel";
            this.inforServerConnectPanel.Size = new System.Drawing.Size(1527, 61);
            this.inforServerConnectPanel.TabIndex = 1;
            this.inforServerConnectPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.inforServerConnectPanel_Paint);
            // 
            // connectButton
            // 
            this.connectButton.Location = new System.Drawing.Point(1172, 9);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(170, 41);
            this.connectButton.TabIndex = 8;
            this.connectButton.Text = "Connect";
            this.connectButton.UseVisualStyleBackColor = true;
            this.connectButton.Click += new System.EventHandler(this.connectButton_Click);
            // 
            // passwdTextBox
            // 
            this.passwdTextBox.Location = new System.Drawing.Point(966, 14);
            this.passwdTextBox.Name = "passwdTextBox";
            this.passwdTextBox.Size = new System.Drawing.Size(170, 31);
            this.passwdTextBox.TabIndex = 7;
            this.passwdTextBox.UseSystemPasswordChar = true;
            // 
            // usernameTextBox
            // 
            this.usernameTextBox.Location = new System.Drawing.Point(658, 9);
            this.usernameTextBox.Multiline = true;
            this.usernameTextBox.Name = "usernameTextBox";
            this.usernameTextBox.Size = new System.Drawing.Size(170, 42);
            this.usernameTextBox.TabIndex = 6;
            // 
            // hostTextBox
            // 
            this.hostTextBox.Location = new System.Drawing.Point(80, 9);
            this.hostTextBox.Multiline = true;
            this.hostTextBox.Name = "hostTextBox";
            this.hostTextBox.Size = new System.Drawing.Size(170, 42);
            this.hostTextBox.TabIndex = 4;
            // 
            // passwdLabel
            // 
            this.passwdLabel.AutoSize = true;
            this.passwdLabel.Location = new System.Drawing.Point(848, 19);
            this.passwdLabel.Name = "passwdLabel";
            this.passwdLabel.Size = new System.Drawing.Size(112, 25);
            this.passwdLabel.TabIndex = 3;
            this.passwdLabel.Text = "Password:";
            // 
            // portTextBox
            // 
            this.portTextBox.Location = new System.Drawing.Point(338, 9);
            this.portTextBox.Multiline = true;
            this.portTextBox.Name = "portTextBox";
            this.portTextBox.Size = new System.Drawing.Size(170, 42);
            this.portTextBox.TabIndex = 5;
            // 
            // usernameLabel
            // 
            this.usernameLabel.AutoSize = true;
            this.usernameLabel.Location = new System.Drawing.Point(532, 19);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(116, 25);
            this.usernameLabel.TabIndex = 2;
            this.usernameLabel.Text = "Username:";
            // 
            // portLabel
            // 
            this.portLabel.AutoSize = true;
            this.portLabel.Location = new System.Drawing.Point(272, 19);
            this.portLabel.Name = "portLabel";
            this.portLabel.Size = new System.Drawing.Size(57, 25);
            this.portLabel.TabIndex = 1;
            this.portLabel.Text = "Port:";
            // 
            // hostLabel
            // 
            this.hostLabel.AutoSize = true;
            this.hostLabel.Location = new System.Drawing.Point(12, 19);
            this.hostLabel.Name = "hostLabel";
            this.hostLabel.Size = new System.Drawing.Size(62, 25);
            this.hostLabel.TabIndex = 0;
            this.hostLabel.Text = "Host:";
            // 
            // mainContainer
            // 
            this.mainContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mainContainer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.mainContainer.Location = new System.Drawing.Point(12, 111);
            this.mainContainer.Name = "mainContainer";
            this.mainContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // mainContainer.Panel1
            // 
            this.mainContainer.Panel1.Controls.Add(this.mainsiteContainer);
            // 
            // mainContainer.Panel2
            // 
            this.mainContainer.Panel2.BackColor = System.Drawing.SystemColors.Info;
            this.mainContainer.Size = new System.Drawing.Size(1504, 800);
            this.mainContainer.SplitterDistance = 532;
            this.mainContainer.SplitterWidth = 2;
            this.mainContainer.TabIndex = 2;
            // 
            // mainsiteContainer
            // 
            this.mainsiteContainer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.mainsiteContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainsiteContainer.Location = new System.Drawing.Point(0, 0);
            this.mainsiteContainer.Name = "mainsiteContainer";
            // 
            // mainsiteContainer.Panel1
            // 
            this.mainsiteContainer.Panel1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.mainsiteContainer.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            // 
            // mainsiteContainer.Panel2
            // 
            this.mainsiteContainer.Panel2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.mainsiteContainer.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.mainsiteContainer.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.mainsiteContainer.Size = new System.Drawing.Size(1504, 532);
            this.mainsiteContainer.SplitterDistance = 499;
            this.mainsiteContainer.SplitterWidth = 2;
            this.mainsiteContainer.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.serverToolStripMenuItem,
            this.userToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1528, 40);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // serverToolStripMenuItem
            // 
            this.serverToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.reconnectToolStripMenuItem,
            this.disconnectToolStripMenuItem});
            this.serverToolStripMenuItem.Name = "serverToolStripMenuItem";
            this.serverToolStripMenuItem.Size = new System.Drawing.Size(101, 36);
            this.serverToolStripMenuItem.Text = "Server";
            // 
            // reconnectToolStripMenuItem
            // 
            this.reconnectToolStripMenuItem.Name = "reconnectToolStripMenuItem";
            this.reconnectToolStripMenuItem.Size = new System.Drawing.Size(265, 44);
            this.reconnectToolStripMenuItem.Text = "Reconnect";
            this.reconnectToolStripMenuItem.Click += new System.EventHandler(this.reconnectToolStripMenuItem_Click);
            // 
            // disconnectToolStripMenuItem
            // 
            this.disconnectToolStripMenuItem.Name = "disconnectToolStripMenuItem";
            this.disconnectToolStripMenuItem.Size = new System.Drawing.Size(265, 44);
            this.disconnectToolStripMenuItem.Text = "Disconnect";
            this.disconnectToolStripMenuItem.Click += new System.EventHandler(this.disconnectToolStripMenuItem_Click);
            // 
            // userToolStripMenuItem
            // 
            this.userToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.registerToolStripMenuItem,
            this.settingsToolStripMenuItem});
            this.userToolStripMenuItem.Name = "userToolStripMenuItem";
            this.userToolStripMenuItem.Size = new System.Drawing.Size(81, 36);
            this.userToolStripMenuItem.Text = "User";
            // 
            // registerToolStripMenuItem
            // 
            this.registerToolStripMenuItem.Name = "registerToolStripMenuItem";
            this.registerToolStripMenuItem.Size = new System.Drawing.Size(233, 44);
            this.registerToolStripMenuItem.Text = "Register";
            this.registerToolStripMenuItem.Click += new System.EventHandler(this.registerToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(233, 44);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1528, 923);
            this.Controls.Add(this.mainContainer);
            this.Controls.Add(this.inforServerConnectPanel);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "FTP Client";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.inforServerConnectPanel.ResumeLayout(false);
            this.inforServerConnectPanel.PerformLayout();
            this.mainContainer.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mainContainer)).EndInit();
            this.mainContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mainsiteContainer)).EndInit();
            this.mainsiteContainer.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel inforServerConnectPanel;
        private System.Windows.Forms.Label hostLabel;
        private System.Windows.Forms.Label portLabel;
        private System.Windows.Forms.Label passwdLabel;
        private System.Windows.Forms.Label usernameLabel;
        private System.Windows.Forms.TextBox passwdTextBox;
        private System.Windows.Forms.TextBox usernameTextBox;
        private System.Windows.Forms.TextBox portTextBox;
        private System.Windows.Forms.TextBox hostTextBox;
        private System.Windows.Forms.Button connectButton;
        private System.Windows.Forms.SplitContainer mainContainer;
        private System.Windows.Forms.SplitContainer mainsiteContainer;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem serverToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reconnectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem disconnectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem userToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem registerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
    }
}

