namespace Ftp_Client
{
    partial class RemoteSiteForm
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
            components = new System.ComponentModel.Container();
            TreeNode treeNode1 = new TreeNode("\\");
            remotePathTextBox = new TextBox();
            remoteSiteLabel = new Label();
            headerPanel = new Panel();
            folderTreeRemote = new TreeView();
            panel2 = new Panel();
            fileListView = new ListView();
            panel1 = new Panel();
            fileMenuStrip = new ContextMenuStrip(components);
            deleteFileToolStripMenuItem = new ToolStripMenuItem();
            downloadFileToolStripMenuItem = new ToolStripMenuItem();
            folderMenuStrip = new ContextMenuStrip(components);
            deleteFolderToolStripMenuItem = new ToolStripMenuItem();
            blankMenuStrip = new ContextMenuStrip(components);
            newFolderToolStripMenuItem = new ToolStripMenuItem();
            headerPanel.SuspendLayout();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            fileMenuStrip.SuspendLayout();
            folderMenuStrip.SuspendLayout();
            blankMenuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // remotePathTextBox
            // 
            remotePathTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            remotePathTextBox.BorderStyle = BorderStyle.FixedSingle;
            remotePathTextBox.Location = new Point(169, 22);
            remotePathTextBox.Name = "remotePathTextBox";
            remotePathTextBox.Size = new Size(709, 39);
            remotePathTextBox.TabIndex = 5;
            remotePathTextBox.PreviewKeyDown += remotePathTextBox_PreviewKeyDown;
            // 
            // remoteSiteLabel
            // 
            remoteSiteLabel.AutoSize = true;
            remoteSiteLabel.Location = new Point(18, 24);
            remoteSiteLabel.Name = "remoteSiteLabel";
            remoteSiteLabel.Size = new Size(145, 32);
            remoteSiteLabel.TabIndex = 4;
            remoteSiteLabel.Text = "Remote site:";
            // 
            // headerPanel
            // 
            headerPanel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            headerPanel.Controls.Add(remotePathTextBox);
            headerPanel.Controls.Add(remoteSiteLabel);
            headerPanel.Location = new Point(-2, 0);
            headerPanel.Name = "headerPanel";
            headerPanel.Size = new Size(897, 83);
            headerPanel.TabIndex = 6;
            // 
            // folderTreeRemote
            // 
            folderTreeRemote.Dock = DockStyle.Fill;
            folderTreeRemote.Location = new Point(0, 0);
            folderTreeRemote.Name = "folderTreeRemote";
            treeNode1.Name = "\\";
            treeNode1.Text = "\\";
            folderTreeRemote.Nodes.AddRange(new TreeNode[] { treeNode1 });
            folderTreeRemote.Size = new Size(897, 378);
            folderTreeRemote.TabIndex = 7;
            folderTreeRemote.NodeMouseDoubleClick += folderTreeRemote_NodeMouseDoubleClick;
            
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel2.Controls.Add(fileListView);
            panel2.Location = new Point(-2, 474);
            panel2.Margin = new Padding(5);
            panel2.Name = "panel2";
            panel2.Size = new Size(897, 475);
            panel2.TabIndex = 10;
            // 
            // fileListView
            // 
            fileListView.Dock = DockStyle.Fill;
            fileListView.Location = new Point(0, 0);
            fileListView.Margin = new Padding(5);
            fileListView.Name = "fileListView";
            fileListView.Size = new Size(897, 475);
            fileListView.TabIndex = 0;
            fileListView.UseCompatibleStateImageBehavior = false;
            fileListView.MouseUp += fileListView_MouseUp;
            fileListView.MultiSelect = true;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel1.Controls.Add(folderTreeRemote);
            panel1.Location = new Point(-2, 91);
            panel1.Margin = new Padding(5);
            panel1.Name = "panel1";
            panel1.Size = new Size(897, 378);
            panel1.TabIndex = 11;
            // 
            // fileMenuStrip
            // 
            fileMenuStrip.ImageScalingSize = new Size(20, 20);
            fileMenuStrip.Items.AddRange(new ToolStripItem[] { deleteFileToolStripMenuItem, downloadFileToolStripMenuItem });
            fileMenuStrip.Name = "fileMenuStrip";
            fileMenuStrip.Size = new Size(237, 80);
            // 
            // deleteFileToolStripMenuItem
            // 
            deleteFileToolStripMenuItem.Name = "deleteFileToolStripMenuItem";
            deleteFileToolStripMenuItem.Size = new Size(236, 38);
            deleteFileToolStripMenuItem.Text = "Delete file";
            deleteFileToolStripMenuItem.Click += deleteFileToolStripMenuItem_Click;
            // 
            // downloadFileToolStripMenuItem
            // 
            downloadFileToolStripMenuItem.Name = "downloadFileToolStripMenuItem";
            downloadFileToolStripMenuItem.Size = new Size(236, 38);
            downloadFileToolStripMenuItem.Text = "Download file";
            downloadFileToolStripMenuItem.Click += async (sender, e) => await downloadFileToolStripMenuItem_Click(sender, e);

        // 
        // folderMenuStrip
        // 
        folderMenuStrip.ImageScalingSize = new Size(20, 20);
            folderMenuStrip.Items.AddRange(new ToolStripItem[] { deleteFolderToolStripMenuItem });
            folderMenuStrip.Name = "folderMenuStrip";
            folderMenuStrip.Size = new Size(229, 42);
            // 
            // deleteFolderToolStripMenuItem
            // 
            deleteFolderToolStripMenuItem.Name = "deleteFolderToolStripMenuItem";
            deleteFolderToolStripMenuItem.Size = new Size(228, 38);
            deleteFolderToolStripMenuItem.Text = "Delete folder";
            deleteFolderToolStripMenuItem.Click += deleteFolderToolStripMenuItem_Click;
            // 
            // blankMenuStrip
            // 
            blankMenuStrip.ImageScalingSize = new Size(20, 20);
            blankMenuStrip.Items.AddRange(new ToolStripItem[] { newFolderToolStripMenuItem });
            blankMenuStrip.Name = "blankMenuStrip";
            blankMenuStrip.Size = new Size(207, 42);
            // 
            // newFolderToolStripMenuItem
            // 
            newFolderToolStripMenuItem.Name = "newFolderToolStripMenuItem";
            newFolderToolStripMenuItem.Size = new Size(206, 38);
            newFolderToolStripMenuItem.Text = "New folder";
            newFolderToolStripMenuItem.Click += newFolderToolStripMenuItem_Click;
            // 
            // fileListView
            // 
            fileListView.Dock = DockStyle.Fill;
            fileListView.Location = new Point(0, 0);
            fileListView.Name = "fileListView";
            fileListView.Size = new Size(552, 297);
            fileListView.TabIndex = 0;
            fileListView.UseCompatibleStateImageBehavior = false;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel1.Controls.Add(folderTreeRemote);
            panel1.Location = new Point(-1, 57);
            panel1.Name = "panel1";
            panel1.Size = new Size(552, 236);
            panel1.TabIndex = 11;
            // 
            // RemoteSiteForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonHighlight;
            ClientSize = new Size(895, 954);
            Controls.Add(panel1);
            Controls.Add(panel2);
            Controls.Add(headerPanel);
            FormBorderStyle = FormBorderStyle.None;
            Name = "RemoteSiteForm";
            Text = "RemoteSiteForm";
            headerPanel.ResumeLayout(false);
            headerPanel.PerformLayout();
            panel2.ResumeLayout(false);
            panel1.ResumeLayout(false);
            fileMenuStrip.ResumeLayout(false);
            folderMenuStrip.ResumeLayout(false);
            blankMenuStrip.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        public System.Windows.Forms.TextBox remotePathTextBox;
        private System.Windows.Forms.Label remoteSiteLabel;
        private System.Windows.Forms.Panel headerPanel;
        private TreeView folderTreeRemote;
        private Panel panel2;
        private Panel panel1;
        private ListView fileListView;
        private ContextMenuStrip fileMenuStrip;
        private ToolStripMenuItem deleteFileToolStripMenuItem;
        private ContextMenuStrip folderMenuStrip;
        private ToolStripMenuItem deleteFolderToolStripMenuItem;
        private ContextMenuStrip blankMenuStrip;
        private ToolStripMenuItem newFolderToolStripMenuItem;
        private ToolStripMenuItem downloadFileToolStripMenuItem;
    }
}