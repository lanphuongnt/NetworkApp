namespace Ftp_Client
{
    partial class TranferSiteForm
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
            clientLog = new ListView();
            SuspendLayout();
            // 
            // clientLog
            // 
            clientLog.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            clientLog.Location = new Point(0, -4);
            clientLog.Name = "clientLog";
            clientLog.Size = new Size(857, 658);
            clientLog.TabIndex = 0;
            clientLog.UseCompatibleStateImageBehavior = false;
            // 
            // TranferSiteForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonHighlight;
            ClientSize = new Size(854, 684);
            Controls.Add(clientLog);
            ForeColor = SystemColors.ButtonHighlight;
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 4, 3, 4);
            Name = "TranferSiteForm";
            Text = "TranferSiteForm";
            ResumeLayout(false);
        }

        #endregion

        private ListView clientLog;
    }
}