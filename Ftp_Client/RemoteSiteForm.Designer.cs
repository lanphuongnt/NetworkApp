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
            remotePathTextBox = new TextBox();
            remoteSiteLabel = new Label();
            headerPanel = new Panel();
            folderTreeRemote = new TreeView();
            panel2 = new Panel();
            fileListView = new ListView();
            panel1 = new Panel();
            headerPanel.SuspendLayout();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // remotePathTextBox
            // 
            remotePathTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            remotePathTextBox.BorderStyle = BorderStyle.FixedSingle;
            remotePathTextBox.Location = new Point(104, 14);
            remotePathTextBox.Margin = new Padding(2);
            remotePathTextBox.Name = "remotePathTextBox";
            remotePathTextBox.Size = new Size(437, 27);
            remotePathTextBox.TabIndex = 5;
            remotePathTextBox.PreviewKeyDown += remotePathTextBox_PreviewKeyDown;
            // 
            // remoteSiteLabel
            // 
            remoteSiteLabel.AutoSize = true;
            remoteSiteLabel.Location = new Point(11, 15);
            remoteSiteLabel.Margin = new Padding(2, 0, 2, 0);
            remoteSiteLabel.Name = "remoteSiteLabel";
            remoteSiteLabel.Size = new Size(91, 20);
            remoteSiteLabel.TabIndex = 4;
            remoteSiteLabel.Text = "Remote site:";
            // 
            // headerPanel
            // 
            headerPanel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            headerPanel.Controls.Add(remotePathTextBox);
            headerPanel.Controls.Add(remoteSiteLabel);
            headerPanel.Location = new Point(-1, 0);
            headerPanel.Margin = new Padding(2);
            headerPanel.Name = "headerPanel";
            headerPanel.Size = new Size(552, 52);
            headerPanel.TabIndex = 6;
            // 
            // folderTreeRemote
            // 
            folderTreeRemote.Dock = DockStyle.Fill;
            folderTreeRemote.Location = new Point(0, 0);
            folderTreeRemote.Margin = new Padding(2);
            folderTreeRemote.Name = "folderTreeRemote";
            folderTreeRemote.Size = new Size(552, 236);
            folderTreeRemote.TabIndex = 7;
            folderTreeRemote.NodeMouseDoubleClick += folderTreeRemote_NodeMouseDoubleClick;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel2.Controls.Add(fileListView);
            panel2.Location = new Point(-1, 296);
            panel2.Name = "panel2";
            panel2.Size = new Size(552, 297);
            panel2.TabIndex = 10;
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
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonHighlight;
            ClientSize = new Size(551, 596);
            Controls.Add(panel1);
            Controls.Add(panel2);
            Controls.Add(headerPanel);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(2);
            Name = "RemoteSiteForm";
            Text = "RemoteSiteForm";
            Load += RemoteSiteForm_Load;
            headerPanel.ResumeLayout(false);
            headerPanel.PerformLayout();
            panel2.ResumeLayout(false);
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TextBox remotePathTextBox;
        private System.Windows.Forms.Label remoteSiteLabel;
        private System.Windows.Forms.Panel headerPanel;
        private TreeView folderTreeRemote;
        private Panel panel2;
        private Panel panel1;
        private ListView fileListView;
    }
}