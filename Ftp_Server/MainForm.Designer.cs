namespace Ftp_Server
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
            this.connection = new System.Windows.Forms.Button();
            this.Server = new System.Windows.Forms.MenuStrip();
            this.serverToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.connectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.disconnectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configurationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.footer = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.mainContainer = new System.Windows.Forms.SplitContainer();
            this.viewLog = new System.Windows.Forms.ListView();
            this.viewSession = new System.Windows.Forms.ListView();
            this.Server.SuspendLayout();
            this.footer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainContainer)).BeginInit();
            this.mainContainer.Panel1.SuspendLayout();
            this.mainContainer.Panel2.SuspendLayout();
            this.mainContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // connection
            // 
            this.connection.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.connection.AutoSize = true;
            this.connection.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.connection.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.connection.Location = new System.Drawing.Point(439, 299);
            this.connection.Name = "connection";
            this.connection.Size = new System.Drawing.Size(318, 69);
            this.connection.TabIndex = 0;
            this.connection.Text = "Connect to server";
            this.connection.UseVisualStyleBackColor = true;
            this.connection.Click += new System.EventHandler(this.connection_Click);
            // 
            // Server
            // 
            this.Server.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.Server.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.Server.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.serverToolStripMenuItem,
            this.configurationToolStripMenuItem});
            this.Server.Location = new System.Drawing.Point(0, 0);
            this.Server.Name = "Server";
            this.Server.Size = new System.Drawing.Size(1246, 40);
            this.Server.TabIndex = 1;
            this.Server.Text = "Server";
            // 
            // serverToolStripMenuItem
            // 
            this.serverToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.connectToolStripMenuItem,
            this.disconnectToolStripMenuItem,
            this.quitToolStripMenuItem});
            this.serverToolStripMenuItem.Name = "serverToolStripMenuItem";
            this.serverToolStripMenuItem.Size = new System.Drawing.Size(102, 36);
            this.serverToolStripMenuItem.Text = "Server";
            // 
            // connectToolStripMenuItem
            // 
            this.connectToolStripMenuItem.Name = "connectToolStripMenuItem";
            this.connectToolStripMenuItem.Size = new System.Drawing.Size(267, 44);
            this.connectToolStripMenuItem.Text = "Connect";
            // 
            // disconnectToolStripMenuItem
            // 
            this.disconnectToolStripMenuItem.Name = "disconnectToolStripMenuItem";
            this.disconnectToolStripMenuItem.Size = new System.Drawing.Size(267, 44);
            this.disconnectToolStripMenuItem.Text = "Disconnect";
            this.disconnectToolStripMenuItem.Click += new System.EventHandler(this.disconnectToolStripMenuItem_Click);
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(267, 44);
            this.quitToolStripMenuItem.Text = "Quit";
            // 
            // configurationToolStripMenuItem
            // 
            this.configurationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.usersToolStripMenuItem});
            this.configurationToolStripMenuItem.Name = "configurationToolStripMenuItem";
            this.configurationToolStripMenuItem.Size = new System.Drawing.Size(182, 36);
            this.configurationToolStripMenuItem.Text = "Configuration";
            // 
            // usersToolStripMenuItem
            // 
            this.usersToolStripMenuItem.Name = "usersToolStripMenuItem";
            this.usersToolStripMenuItem.Size = new System.Drawing.Size(206, 44);
            this.usersToolStripMenuItem.Text = "Users";
            this.usersToolStripMenuItem.Click += new System.EventHandler(this.usersToolStripMenuItem_Click);
            // 
            // footer
            // 
            this.footer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.footer.Controls.Add(this.label1);
            this.footer.Location = new System.Drawing.Point(0, 925);
            this.footer.Name = "footer";
            this.footer.Size = new System.Drawing.Size(1246, 53);
            this.footer.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Disconnect";
            // 
            // mainContainer
            // 
            this.mainContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mainContainer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.mainContainer.Location = new System.Drawing.Point(0, 43);
            this.mainContainer.Name = "mainContainer";
            this.mainContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // mainContainer.Panel1
            // 
            this.mainContainer.Panel1.Controls.Add(this.connection);
            this.mainContainer.Panel1.Controls.Add(this.viewLog);
            // 
            // mainContainer.Panel2
            // 
            this.mainContainer.Panel2.Controls.Add(this.viewSession);
            this.mainContainer.Size = new System.Drawing.Size(1243, 880);
            this.mainContainer.SplitterDistance = 693;
            this.mainContainer.TabIndex = 3;
            // 
            // viewLog
            // 
            this.viewLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.viewLog.HideSelection = false;
            this.viewLog.Location = new System.Drawing.Point(0, 0);
            this.viewLog.Name = "viewLog";
            this.viewLog.Size = new System.Drawing.Size(1239, 689);
            this.viewLog.TabIndex = 0;
            this.viewLog.UseCompatibleStateImageBehavior = false;
            // 
            // viewSession
            // 
            this.viewSession.Dock = System.Windows.Forms.DockStyle.Fill;
            this.viewSession.HideSelection = false;
            this.viewSession.Location = new System.Drawing.Point(0, 0);
            this.viewSession.Name = "viewSession";
            this.viewSession.Size = new System.Drawing.Size(1239, 179);
            this.viewSession.TabIndex = 0;
            this.viewSession.UseCompatibleStateImageBehavior = false;
            // 
            // MainForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1246, 972);
            this.Controls.Add(this.footer);
            this.Controls.Add(this.Server);
            this.Controls.Add(this.mainContainer);
            this.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.MainMenuStrip = this.Server;
            this.Name = "MainForm";
            this.Text = "FTP Server";
            this.Server.ResumeLayout(false);
            this.Server.PerformLayout();
            this.footer.ResumeLayout(false);
            this.footer.PerformLayout();
            this.mainContainer.Panel1.ResumeLayout(false);
            this.mainContainer.Panel1.PerformLayout();
            this.mainContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mainContainer)).EndInit();
            this.mainContainer.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button connection;
        private System.Windows.Forms.MenuStrip Server;
        private System.Windows.Forms.ToolStripMenuItem serverToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem connectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem disconnectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.Panel footer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem configurationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usersToolStripMenuItem;
        private System.Windows.Forms.SplitContainer mainContainer;
        private System.Windows.Forms.ListView viewLog;
        private System.Windows.Forms.ListView viewSession;
    }
}

