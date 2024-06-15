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
            inforServerConnectPanel = new Panel();
            activeModeRadioButton = new RadioButton();
            passiveModeRadioButton = new RadioButton();
            connectButton = new Button();
            passwdTextBox = new TextBox();
            usernameTextBox = new TextBox();
            hostTextBox = new TextBox();
            passwdLabel = new Label();
            portTextBox = new TextBox();
            usernameLabel = new Label();
            portLabel = new Label();
            hostLabel = new Label();
            mainContainer = new SplitContainer();
            mainsiteContainer = new SplitContainer();
            menuStrip1 = new MenuStrip();
            serverToolStripMenuItem = new ToolStripMenuItem();
            reconnectToolStripMenuItem = new ToolStripMenuItem();
            disconnectToolStripMenuItem = new ToolStripMenuItem();
            userToolStripMenuItem = new ToolStripMenuItem();
            registerToolStripMenuItem = new ToolStripMenuItem();
            settingsToolStripMenuItem = new ToolStripMenuItem();
            inforServerConnectPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)mainContainer).BeginInit();
            mainContainer.Panel1.SuspendLayout();
            mainContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)mainsiteContainer).BeginInit();
            mainsiteContainer.SuspendLayout();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // inforServerConnectPanel
            // 
            inforServerConnectPanel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            inforServerConnectPanel.BackColor = Color.Gainsboro;
            inforServerConnectPanel.Controls.Add(activeModeRadioButton);
            inforServerConnectPanel.Controls.Add(passiveModeRadioButton);
            inforServerConnectPanel.Controls.Add(connectButton);
            inforServerConnectPanel.Controls.Add(passwdTextBox);
            inforServerConnectPanel.Controls.Add(usernameTextBox);
            inforServerConnectPanel.Controls.Add(hostTextBox);
            inforServerConnectPanel.Controls.Add(passwdLabel);
            inforServerConnectPanel.Controls.Add(portTextBox);
            inforServerConnectPanel.Controls.Add(usernameLabel);
            inforServerConnectPanel.Controls.Add(portLabel);
            inforServerConnectPanel.Controls.Add(hostLabel);
            inforServerConnectPanel.Location = new Point(0, 56);
            inforServerConnectPanel.Margin = new Padding(3, 4, 3, 4);
            inforServerConnectPanel.Name = "inforServerConnectPanel";
            inforServerConnectPanel.Size = new Size(1856, 78);
            inforServerConnectPanel.TabIndex = 1;
            inforServerConnectPanel.Paint += inforServerConnectPanel_Paint;
            // 
            // activeModeRadioButton
            // 
            activeModeRadioButton.AutoSize = true;
            activeModeRadioButton.Location = new Point(1516, 39);
            activeModeRadioButton.Name = "activeModeRadioButton";
            activeModeRadioButton.Size = new Size(180, 36);
            activeModeRadioButton.TabIndex = 9;
            activeModeRadioButton.TabStop = true;
            activeModeRadioButton.Text = "Active Mode";
            activeModeRadioButton.UseVisualStyleBackColor = true;
            // 
            // passiveModeRadioButton
            // 
            passiveModeRadioButton.AutoSize = true;
            passiveModeRadioButton.Location = new Point(1516, 3);
            passiveModeRadioButton.Name = "passiveModeRadioButton";
            passiveModeRadioButton.Size = new Size(190, 36);
            passiveModeRadioButton.TabIndex = 4;
            passiveModeRadioButton.TabStop = true;
            passiveModeRadioButton.Text = "Passive Mode";
            passiveModeRadioButton.UseVisualStyleBackColor = true;
            // 
            // connectButton
            // 
            connectButton.Location = new Point(1270, 12);
            connectButton.Margin = new Padding(3, 4, 3, 4);
            connectButton.Name = "connectButton";
            connectButton.Size = new Size(184, 52);
            connectButton.TabIndex = 8;
            connectButton.Text = "Connect";
            connectButton.UseVisualStyleBackColor = true;
            connectButton.Click += connectButton_Click;
            // 
            // passwdTextBox
            // 
            passwdTextBox.Location = new Point(1046, 18);
            passwdTextBox.Margin = new Padding(3, 4, 3, 4);
            passwdTextBox.Name = "passwdTextBox";
            passwdTextBox.Size = new Size(184, 39);
            passwdTextBox.TabIndex = 7;
            passwdTextBox.UseSystemPasswordChar = true;
            // 
            // usernameTextBox
            // 
            usernameTextBox.Location = new Point(713, 12);
            usernameTextBox.Margin = new Padding(3, 4, 3, 4);
            usernameTextBox.Multiline = true;
            usernameTextBox.Name = "usernameTextBox";
            usernameTextBox.Size = new Size(184, 53);
            usernameTextBox.TabIndex = 6;
            // 
            // hostTextBox
            // 
            hostTextBox.Location = new Point(87, 12);
            hostTextBox.Margin = new Padding(3, 4, 3, 4);
            hostTextBox.Multiline = true;
            hostTextBox.Name = "hostTextBox";
            hostTextBox.Size = new Size(184, 53);
            hostTextBox.TabIndex = 4;
            // 
            // passwdLabel
            // 
            passwdLabel.AutoSize = true;
            passwdLabel.Location = new Point(919, 24);
            passwdLabel.Name = "passwdLabel";
            passwdLabel.Size = new Size(116, 32);
            passwdLabel.TabIndex = 3;
            passwdLabel.Text = "Password:";
            // 
            // portTextBox
            // 
            portTextBox.Location = new Point(366, 12);
            portTextBox.Margin = new Padding(3, 4, 3, 4);
            portTextBox.Multiline = true;
            portTextBox.Name = "portTextBox";
            portTextBox.Size = new Size(184, 53);
            portTextBox.TabIndex = 5;
            // 
            // usernameLabel
            // 
            usernameLabel.AutoSize = true;
            usernameLabel.Location = new Point(576, 24);
            usernameLabel.Name = "usernameLabel";
            usernameLabel.Size = new Size(126, 32);
            usernameLabel.TabIndex = 2;
            usernameLabel.Text = "Username:";
            // 
            // portLabel
            // 
            portLabel.AutoSize = true;
            portLabel.Location = new Point(295, 24);
            portLabel.Name = "portLabel";
            portLabel.Size = new Size(61, 32);
            portLabel.TabIndex = 1;
            portLabel.Text = "Port:";
            // 
            // hostLabel
            // 
            hostLabel.AutoSize = true;
            hostLabel.Location = new Point(13, 24);
            hostLabel.Name = "hostLabel";
            hostLabel.Size = new Size(68, 32);
            hostLabel.TabIndex = 0;
            hostLabel.Text = "Host:";
            // 
            // mainContainer
            // 
            mainContainer.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            mainContainer.BorderStyle = BorderStyle.Fixed3D;
            mainContainer.Location = new Point(13, 142);
            mainContainer.Margin = new Padding(3, 4, 3, 4);
            mainContainer.Name = "mainContainer";
            mainContainer.Orientation = Orientation.Horizontal;
            // 
            // mainContainer.Panel1
            // 
            mainContainer.Panel1.Controls.Add(mainsiteContainer);
            // 
            // mainContainer.Panel2
            // 
            mainContainer.Panel2.BackColor = SystemColors.Info;
            mainContainer.Size = new Size(1831, 1024);
            mainContainer.SplitterDistance = 680;
            mainContainer.SplitterWidth = 3;
            mainContainer.TabIndex = 2;
            // 
            // mainsiteContainer
            // 
            mainsiteContainer.BorderStyle = BorderStyle.Fixed3D;
            mainsiteContainer.Dock = DockStyle.Fill;
            mainsiteContainer.Location = new Point(0, 0);
            mainsiteContainer.Margin = new Padding(3, 4, 3, 4);
            mainsiteContainer.Name = "mainsiteContainer";
            // 
            // mainsiteContainer.Panel1
            // 
            mainsiteContainer.Panel1.BackColor = SystemColors.AppWorkspace;
            mainsiteContainer.Panel1.RightToLeft = RightToLeft.No;
            // 
            // mainsiteContainer.Panel2
            // 
            mainsiteContainer.Panel2.BackColor = SystemColors.ActiveCaption;
            mainsiteContainer.Panel2.RightToLeft = RightToLeft.No;
            mainsiteContainer.RightToLeft = RightToLeft.No;
            mainsiteContainer.Size = new Size(1831, 680);
            mainsiteContainer.SplitterDistance = 606;
            mainsiteContainer.SplitterWidth = 2;
            mainsiteContainer.TabIndex = 0;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(32, 32);
            menuStrip1.Items.AddRange(new ToolStripItem[] { serverToolStripMenuItem, userToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(6, 3, 0, 3);
            menuStrip1.Size = new Size(1857, 42);
            menuStrip1.TabIndex = 3;
            menuStrip1.Text = "menuStrip1";
            // 
            // serverToolStripMenuItem
            // 
            serverToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { reconnectToolStripMenuItem, disconnectToolStripMenuItem });
            serverToolStripMenuItem.Name = "serverToolStripMenuItem";
            serverToolStripMenuItem.Size = new Size(101, 36);
            serverToolStripMenuItem.Text = "Server";
            // 
            // reconnectToolStripMenuItem
            // 
            reconnectToolStripMenuItem.Name = "reconnectToolStripMenuItem";
            reconnectToolStripMenuItem.Size = new Size(265, 44);
            reconnectToolStripMenuItem.Text = "Reconnect";
            reconnectToolStripMenuItem.Click += reconnectToolStripMenuItem_Click;
            // 
            // disconnectToolStripMenuItem
            // 
            disconnectToolStripMenuItem.Name = "disconnectToolStripMenuItem";
            disconnectToolStripMenuItem.Size = new Size(265, 44);
            disconnectToolStripMenuItem.Text = "Disconnect";
            disconnectToolStripMenuItem.Click += disconnectToolStripMenuItem_Click;
            // 
            // userToolStripMenuItem
            // 
            userToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { registerToolStripMenuItem, settingsToolStripMenuItem });
            userToolStripMenuItem.Name = "userToolStripMenuItem";
            userToolStripMenuItem.Size = new Size(81, 36);
            userToolStripMenuItem.Text = "User";
            // 
            // registerToolStripMenuItem
            // 
            registerToolStripMenuItem.Name = "registerToolStripMenuItem";
            registerToolStripMenuItem.Size = new Size(233, 44);
            registerToolStripMenuItem.Text = "Register";
            registerToolStripMenuItem.Click += registerToolStripMenuItem_Click;
            // 
            // settingsToolStripMenuItem
            // 
            settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            settingsToolStripMenuItem.Size = new Size(233, 44);
            settingsToolStripMenuItem.Text = "Settings";
            settingsToolStripMenuItem.Click += settingsToolStripMenuItem_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1857, 1181);
            Controls.Add(mainContainer);
            Controls.Add(inforServerConnectPanel);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Margin = new Padding(3, 4, 3, 4);
            Name = "MainForm";
            Text = "FTP Client";
            Load += MainForm_Load;
            inforServerConnectPanel.ResumeLayout(false);
            inforServerConnectPanel.PerformLayout();
            mainContainer.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)mainContainer).EndInit();
            mainContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)mainsiteContainer).EndInit();
            mainsiteContainer.ResumeLayout(false);
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
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
        private RadioButton activeModeRadioButton;
        private RadioButton passiveModeRadioButton;
    }
}

