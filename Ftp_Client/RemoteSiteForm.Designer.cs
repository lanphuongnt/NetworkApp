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
            this.remotePathTextBox = new System.Windows.Forms.TextBox();
            this.remoteSiteLabel = new System.Windows.Forms.Label();
            this.headerPanel = new System.Windows.Forms.Panel();
            this.headerPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // remotePathTextBox
            // 
            this.remotePathTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.remotePathTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.remotePathTextBox.Location = new System.Drawing.Point(156, 17);
            this.remotePathTextBox.Name = "remotePathTextBox";
            this.remotePathTextBox.Size = new System.Drawing.Size(649, 31);
            this.remotePathTextBox.TabIndex = 5;
            // 
            // remoteSiteLabel
            // 
            this.remoteSiteLabel.AutoSize = true;
            this.remoteSiteLabel.Location = new System.Drawing.Point(17, 19);
            this.remoteSiteLabel.Name = "remoteSiteLabel";
            this.remoteSiteLabel.Size = new System.Drawing.Size(132, 25);
            this.remoteSiteLabel.TabIndex = 4;
            this.remoteSiteLabel.Text = "Remote site:";
            // 
            // headerPanel
            // 
            this.headerPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.headerPanel.Controls.Add(this.remotePathTextBox);
            this.headerPanel.Controls.Add(this.remoteSiteLabel);
            this.headerPanel.Location = new System.Drawing.Point(-1, 0);
            this.headerPanel.Name = "headerPanel";
            this.headerPanel.Size = new System.Drawing.Size(828, 65);
            this.headerPanel.TabIndex = 6;
            // 
            // RemoteSiteForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(826, 790);
            this.Controls.Add(this.headerPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "RemoteSiteForm";
            this.Text = "RemoteSiteForm";
            this.headerPanel.ResumeLayout(false);
            this.headerPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox remotePathTextBox;
        private System.Windows.Forms.Label remoteSiteLabel;
        private System.Windows.Forms.Panel headerPanel;
    }
}