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
            Server = new MenuStrip();
            serverToolStripMenuItem = new ToolStripMenuItem();
            startToolStripMenuItem = new ToolStripMenuItem();
            restartToolStripMenuItem = new ToolStripMenuItem();
            quitToolStripMenuItem = new ToolStripMenuItem();
            configurationToolStripMenuItem = new ToolStripMenuItem();
            usersToolStripMenuItem = new ToolStripMenuItem();
            footer = new Panel();
            label1 = new Label();
            mainContainer = new SplitContainer();
            viewLog = new ListView();
            viewSession = new ListView();
            Server.SuspendLayout();
            footer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)mainContainer).BeginInit();
            mainContainer.Panel1.SuspendLayout();
            mainContainer.Panel2.SuspendLayout();
            mainContainer.SuspendLayout();
            SuspendLayout();
            // 
            // Server
            // 
            Server.ImageScalingSize = new Size(32, 32);
            Server.Items.AddRange(new ToolStripItem[] { serverToolStripMenuItem, configurationToolStripMenuItem });
            Server.Location = new Point(0, 0);
            Server.Name = "Server";
            Server.Padding = new Padding(6, 3, 0, 3);
            Server.Size = new Size(986, 42);
            Server.TabIndex = 1;
            Server.Text = "Server";
            // 
            // serverToolStripMenuItem
            // 
            serverToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { startToolStripMenuItem, restartToolStripMenuItem, quitToolStripMenuItem });
            serverToolStripMenuItem.Name = "serverToolStripMenuItem";
            serverToolStripMenuItem.Size = new Size(101, 36);
            serverToolStripMenuItem.Text = "Server";
            // 
            // startToolStripMenuItem
            // 
            startToolStripMenuItem.Name = "startToolStripMenuItem";
            startToolStripMenuItem.Size = new Size(219, 44);
            startToolStripMenuItem.Text = "Start";
            startToolStripMenuItem.Click += startToolStripMenuItem_Click;
            // 
            // restartToolStripMenuItem
            // 
            restartToolStripMenuItem.Name = "restartToolStripMenuItem";
            restartToolStripMenuItem.Size = new Size(219, 44);
            restartToolStripMenuItem.Text = "Restart";
            restartToolStripMenuItem.Click += restartToolStripMenuItem_Click;
            // 
            // quitToolStripMenuItem
            // 
            quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            quitToolStripMenuItem.Size = new Size(219, 44);
            quitToolStripMenuItem.Text = "Quit";
            quitToolStripMenuItem.Click += quitToolStripMenuItem_Click;
            // 
            // configurationToolStripMenuItem
            // 
            configurationToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { usersToolStripMenuItem });
            configurationToolStripMenuItem.Name = "configurationToolStripMenuItem";
            configurationToolStripMenuItem.Size = new Size(181, 36);
            configurationToolStripMenuItem.Text = "Configuration";
            // 
            // usersToolStripMenuItem
            // 
            usersToolStripMenuItem.Name = "usersToolStripMenuItem";
            usersToolStripMenuItem.Size = new Size(204, 44);
            usersToolStripMenuItem.Text = "Users";
            usersToolStripMenuItem.Click += usersToolStripMenuItem_Click;
            // 
            // footer
            // 
            footer.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            footer.Controls.Add(label1);
            footer.Location = new Point(0, 533);
            footer.Margin = new Padding(3, 4, 3, 4);
            footer.Name = "footer";
            footer.Size = new Size(986, 61);
            footer.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(13, 17);
            label1.Name = "label1";
            label1.Size = new Size(132, 32);
            label1.TabIndex = 0;
            label1.Text = "Disconnect";
            // 
            // mainContainer
            // 
            mainContainer.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            mainContainer.BorderStyle = BorderStyle.Fixed3D;
            mainContainer.Location = new Point(0, 55);
            mainContainer.Margin = new Padding(3, 4, 3, 4);
            mainContainer.Name = "mainContainer";
            mainContainer.Orientation = Orientation.Horizontal;
            // 
            // mainContainer.Panel1
            // 
            mainContainer.Panel1.Controls.Add(viewLog);
            // 
            // mainContainer.Panel2
            // 
            mainContainer.Panel2.Controls.Add(viewSession);
            mainContainer.Size = new Size(983, 470);
            mainContainer.SplitterDistance = 235;
            mainContainer.TabIndex = 3;
            // 
            // viewLog
            // 
            viewLog.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            viewLog.Location = new Point(-2, -2);
            viewLog.Margin = new Padding(3, 4, 3, 4);
            viewLog.Name = "viewLog";
            viewLog.Size = new Size(978, 243);
            viewLog.TabIndex = 0;
            viewLog.UseCompatibleStateImageBehavior = false;
            // 
            // viewSession
            // 
            viewSession.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            viewSession.Location = new Point(-2, 4);
            viewSession.Margin = new Padding(3, 4, 3, 4);
            viewSession.Name = "viewSession";
            viewSession.Size = new Size(978, 219);
            viewSession.TabIndex = 0;
            viewSession.UseCompatibleStateImageBehavior = false;
            // 
            // MainForm
            // 
            AllowDrop = true;
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(986, 588);
            Controls.Add(footer);
            Controls.Add(Server);
            Controls.Add(mainContainer);
            ForeColor = SystemColors.HotTrack;
            MainMenuStrip = Server;
            Margin = new Padding(3, 4, 3, 4);
            Name = "MainForm";
            Text = "FTP Server";
            Load += MainForm_Load;
            Server.ResumeLayout(false);
            Server.PerformLayout();
            footer.ResumeLayout(false);
            footer.PerformLayout();
            mainContainer.Panel1.ResumeLayout(false);
            mainContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)mainContainer).EndInit();
            mainContainer.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.MenuStrip Server;
        private System.Windows.Forms.ToolStripMenuItem serverToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem restartToolStripMenuItem;
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

