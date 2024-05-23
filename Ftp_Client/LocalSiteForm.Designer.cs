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
            this.mainContainer = new System.Windows.Forms.SplitContainer();
            this.fileBrowser = new System.Windows.Forms.WebBrowser();
            this.localSiteLabel = new System.Windows.Forms.Label();
            this.localPathTextBox = new System.Windows.Forms.TextBox();
            this.backButton = new System.Windows.Forms.Button();
            this.folderTreeView = new System.Windows.Forms.TreeView();
            ((System.ComponentModel.ISupportInitialize)(this.mainContainer)).BeginInit();
            this.mainContainer.Panel1.SuspendLayout();
            this.mainContainer.Panel2.SuspendLayout();
            this.mainContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainContainer
            // 
            this.mainContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mainContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mainContainer.Location = new System.Drawing.Point(0, 66);
            this.mainContainer.Name = "mainContainer";
            this.mainContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // mainContainer.Panel1
            // 
            this.mainContainer.Panel1.Controls.Add(this.folderTreeView);
            // 
            // mainContainer.Panel2
            // 
            this.mainContainer.Panel2.Controls.Add(this.fileBrowser);
            this.mainContainer.Size = new System.Drawing.Size(828, 650);
            this.mainContainer.SplitterDistance = 253;
            this.mainContainer.SplitterWidth = 1;
            this.mainContainer.TabIndex = 1;
            // 
            // fileBrowser
            // 
            this.fileBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fileBrowser.Location = new System.Drawing.Point(0, 0);
            this.fileBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.fileBrowser.Name = "fileBrowser";
            this.fileBrowser.Size = new System.Drawing.Size(826, 394);
            this.fileBrowser.TabIndex = 0;
            this.fileBrowser.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.fileBrowser_DocumentCompleted);
            // 
            // localSiteLabel
            // 
            this.localSiteLabel.AutoSize = true;
            this.localSiteLabel.Location = new System.Drawing.Point(12, 21);
            this.localSiteLabel.Name = "localSiteLabel";
            this.localSiteLabel.Size = new System.Drawing.Size(110, 25);
            this.localSiteLabel.TabIndex = 2;
            this.localSiteLabel.Text = "Local site:";
            // 
            // localPathTextBox
            // 
            this.localPathTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.localPathTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.localPathTextBox.Location = new System.Drawing.Point(128, 15);
            this.localPathTextBox.Name = "localPathTextBox";
            this.localPathTextBox.Size = new System.Drawing.Size(524, 31);
            this.localPathTextBox.TabIndex = 3;
            this.localPathTextBox.TextChanged += new System.EventHandler(this.localPathTextBox_TextChanged);
            this.localPathTextBox.Leave += new System.EventHandler(this.localPathTextBox_Leave);
            this.localPathTextBox.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.localPathTextBox_PreviewKeyDown);
            // 
            // backButton
            // 
            this.backButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.backButton.Location = new System.Drawing.Point(669, 5);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(147, 57);
            this.backButton.TabIndex = 4;
            this.backButton.Text = "Back";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // folderTreeView
            // 
            this.folderTreeView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.folderTreeView.Location = new System.Drawing.Point(3, 3);
            this.folderTreeView.Name = "folderTreeView";
            this.folderTreeView.Size = new System.Drawing.Size(824, 245);
            this.folderTreeView.TabIndex = 0;
            this.folderTreeView.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.folderTreeView_NodeMouseDoubleClick);
            // 
            // LocalSiteForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(828, 720);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.localPathTextBox);
            this.Controls.Add(this.localSiteLabel);
            this.Controls.Add(this.mainContainer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LocalSiteForm";
            this.Text = "LocalSiteForm";
            this.Load += new System.EventHandler(this.LocalSiteForm_Load);
            this.mainContainer.Panel1.ResumeLayout(false);
            this.mainContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mainContainer)).EndInit();
            this.mainContainer.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer mainContainer;
        private System.Windows.Forms.Label localSiteLabel;
        private System.Windows.Forms.TextBox localPathTextBox;
        private System.Windows.Forms.WebBrowser fileBrowser;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.TreeView folderTreeView;
    }
}