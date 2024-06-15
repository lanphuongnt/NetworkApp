namespace Ftp_Client
{
    partial class LocalSiteForm
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
            mainContainer = new SplitContainer();
            folderTreeView = new TreeView();
            fileBrowser = new WebBrowser();
            localSiteLabel = new Label();
            localPathTextBox = new TextBox();
            backButton = new Button();
            localFileMenuStrip = new ContextMenuStrip(components);
            uploadFileToolStripMenuItem = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)mainContainer).BeginInit();
            mainContainer.Panel1.SuspendLayout();
            mainContainer.Panel2.SuspendLayout();
            mainContainer.SuspendLayout();
            localFileMenuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // mainContainer
            // 
            mainContainer.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            mainContainer.BorderStyle = BorderStyle.FixedSingle;
            mainContainer.Location = new Point(0, 53);
            mainContainer.Margin = new Padding(2);
            mainContainer.Name = "mainContainer";
            mainContainer.Orientation = Orientation.Horizontal;
            // 
            // mainContainer.Panel1
            // 
            mainContainer.Panel1.Controls.Add(folderTreeView);
            // 
            // mainContainer.Panel2
            // 
            mainContainer.Panel2.Controls.Add(fileBrowser);
            mainContainer.Size = new Size(552, 520);
            mainContainer.SplitterDistance = 202;
            mainContainer.SplitterWidth = 1;
            mainContainer.TabIndex = 1;
            // 
            // folderTreeView
            // 
            folderTreeView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            folderTreeView.Location = new Point(2, 2);
            folderTreeView.Margin = new Padding(2);
            folderTreeView.Name = "folderTreeView";
            folderTreeView.Size = new Size(550, 196);
            folderTreeView.TabIndex = 0;
            folderTreeView.NodeMouseDoubleClick += folderTreeView_NodeMouseDoubleClick;
            folderTreeView.MouseUp += FolderTreeView_MouseUp;
            //folderTreeView.NodeMouseClick += FolderTreeView_NodeMouseClick;
            // 
            // fileBrowser
            // 
            fileBrowser.Dock = DockStyle.Fill;
            fileBrowser.Location = new Point(0, 0);
            fileBrowser.Margin = new Padding(2);
            fileBrowser.MinimumSize = new Size(13, 16);
            fileBrowser.Name = "fileBrowser";
            fileBrowser.Size = new Size(550, 315);
            fileBrowser.TabIndex = 0;
            fileBrowser.DocumentCompleted += fileBrowser_DocumentCompleted;
            // 
            // localSiteLabel
            // 
            localSiteLabel.AutoSize = true;
            localSiteLabel.Location = new Point(8, 17);
            localSiteLabel.Margin = new Padding(2, 0, 2, 0);
            localSiteLabel.Name = "localSiteLabel";
            localSiteLabel.Size = new Size(74, 20);
            localSiteLabel.TabIndex = 2;
            localSiteLabel.Text = "Local site:";
            // 
            // localPathTextBox
            // 
            localPathTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            localPathTextBox.BorderStyle = BorderStyle.FixedSingle;
            localPathTextBox.Location = new Point(85, 12);
            localPathTextBox.Margin = new Padding(2);
            localPathTextBox.Name = "localPathTextBox";
            localPathTextBox.Size = new Size(350, 27);
            localPathTextBox.TabIndex = 3;
            localPathTextBox.TextChanged += localPathTextBox_TextChanged;
            localPathTextBox.Leave += localPathTextBox_Leave;
            localPathTextBox.PreviewKeyDown += localPathTextBox_PreviewKeyDown;
            // 
            // backButton
            // 
            backButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            backButton.Location = new Point(446, 4);
            backButton.Margin = new Padding(2);
            backButton.Name = "backButton";
            backButton.Size = new Size(98, 46);
            backButton.TabIndex = 4;
            backButton.Text = "Back";
            backButton.UseVisualStyleBackColor = true;
            backButton.Click += backButton_Click;
            // 
            // localFileMenuStrip
            // 
            localFileMenuStrip.ImageScalingSize = new Size(20, 20);
            localFileMenuStrip.Items.AddRange(new ToolStripItem[] { uploadFileToolStripMenuItem });
            localFileMenuStrip.Name = "localFileMenuStrip";
            localFileMenuStrip.Size = new Size(211, 56);
            // 
            // uploadFileToolStripMenuItem
            // 
            uploadFileToolStripMenuItem.Name = "uploadFileToolStripMenuItem";
            uploadFileToolStripMenuItem.Size = new Size(210, 24);
            uploadFileToolStripMenuItem.Text = "Upload file";
            uploadFileToolStripMenuItem.Click += UploadMenuItem_Click;
            // 
            // LocalSiteForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(552, 576);
            Controls.Add(backButton);
            Controls.Add(localPathTextBox);
            Controls.Add(localSiteLabel);
            Controls.Add(mainContainer);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(2);
            Name = "LocalSiteForm";
            Text = "LocalSiteForm";
            Load += LocalSiteForm_Load;
            mainContainer.Panel1.ResumeLayout(false);
            mainContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)mainContainer).EndInit();
            mainContainer.ResumeLayout(false);
            localFileMenuStrip.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.SplitContainer mainContainer;
        private System.Windows.Forms.Label localSiteLabel;
        private System.Windows.Forms.TextBox localPathTextBox;
        private System.Windows.Forms.WebBrowser fileBrowser;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.TreeView folderTreeView;
        private ContextMenuStrip localFileMenuStrip;
        private ToolStripMenuItem uploadFileToolStripMenuItem;
    }
}