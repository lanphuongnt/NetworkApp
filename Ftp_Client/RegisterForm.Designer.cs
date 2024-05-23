namespace Ftp_Client
{
    partial class RegisterForm
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
            this.registerUserGroupBox = new System.Windows.Forms.GroupBox();
            this.portTextBox = new System.Windows.Forms.TextBox();
            this.hostTextBox = new System.Windows.Forms.TextBox();
            this.portLabel = new System.Windows.Forms.Label();
            this.hostLabel = new System.Windows.Forms.Label();
            this.registerButton = new System.Windows.Forms.Button();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.usernameTextBox = new System.Windows.Forms.TextBox();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.usernameLabel = new System.Windows.Forms.Label();
            this.messageResponseGroupBox = new System.Windows.Forms.GroupBox();
            this.messageResponseTextBox = new System.Windows.Forms.TextBox();
            this.registerUserGroupBox.SuspendLayout();
            this.messageResponseGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // registerUserGroupBox
            // 
            this.registerUserGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.registerUserGroupBox.Controls.Add(this.portTextBox);
            this.registerUserGroupBox.Controls.Add(this.hostTextBox);
            this.registerUserGroupBox.Controls.Add(this.portLabel);
            this.registerUserGroupBox.Controls.Add(this.hostLabel);
            this.registerUserGroupBox.Controls.Add(this.registerButton);
            this.registerUserGroupBox.Controls.Add(this.passwordTextBox);
            this.registerUserGroupBox.Controls.Add(this.usernameTextBox);
            this.registerUserGroupBox.Controls.Add(this.passwordLabel);
            this.registerUserGroupBox.Controls.Add(this.usernameLabel);
            this.registerUserGroupBox.Location = new System.Drawing.Point(21, 23);
            this.registerUserGroupBox.Name = "registerUserGroupBox";
            this.registerUserGroupBox.Size = new System.Drawing.Size(472, 389);
            this.registerUserGroupBox.TabIndex = 0;
            this.registerUserGroupBox.TabStop = false;
            this.registerUserGroupBox.Text = "Register a new user";
            // 
            // portTextBox
            // 
            this.portTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.portTextBox.Location = new System.Drawing.Point(170, 122);
            this.portTextBox.Name = "portTextBox";
            this.portTextBox.Size = new System.Drawing.Size(272, 31);
            this.portTextBox.TabIndex = 35;
            // 
            // hostTextBox
            // 
            this.hostTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.hostTextBox.Location = new System.Drawing.Point(170, 68);
            this.hostTextBox.Name = "hostTextBox";
            this.hostTextBox.Size = new System.Drawing.Size(272, 31);
            this.hostTextBox.TabIndex = 34;
            // 
            // portLabel
            // 
            this.portLabel.AutoSize = true;
            this.portLabel.Location = new System.Drawing.Point(25, 128);
            this.portLabel.Name = "portLabel";
            this.portLabel.Size = new System.Drawing.Size(57, 25);
            this.portLabel.TabIndex = 33;
            this.portLabel.Text = "Port:";
            // 
            // hostLabel
            // 
            this.hostLabel.AutoSize = true;
            this.hostLabel.Location = new System.Drawing.Point(25, 74);
            this.hostLabel.Name = "hostLabel";
            this.hostLabel.Size = new System.Drawing.Size(62, 25);
            this.hostLabel.TabIndex = 32;
            this.hostLabel.Text = "Host:";
            // 
            // registerButton
            // 
            this.registerButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.registerButton.Location = new System.Drawing.Point(193, 304);
            this.registerButton.Name = "registerButton";
            this.registerButton.Size = new System.Drawing.Size(220, 59);
            this.registerButton.TabIndex = 31;
            this.registerButton.Text = "Register";
            this.registerButton.UseVisualStyleBackColor = true;
            this.registerButton.Click += new System.EventHandler(this.registerButton_Click);
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.passwordTextBox.Location = new System.Drawing.Point(170, 237);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.Size = new System.Drawing.Size(272, 31);
            this.passwordTextBox.TabIndex = 30;
            this.passwordTextBox.UseSystemPasswordChar = true;
            // 
            // usernameTextBox
            // 
            this.usernameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.usernameTextBox.Location = new System.Drawing.Point(170, 178);
            this.usernameTextBox.Name = "usernameTextBox";
            this.usernameTextBox.Size = new System.Drawing.Size(272, 31);
            this.usernameTextBox.TabIndex = 29;
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Location = new System.Drawing.Point(25, 243);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(112, 25);
            this.passwordLabel.TabIndex = 28;
            this.passwordLabel.Text = "Password:";
            // 
            // usernameLabel
            // 
            this.usernameLabel.AutoSize = true;
            this.usernameLabel.Location = new System.Drawing.Point(25, 184);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(116, 25);
            this.usernameLabel.TabIndex = 27;
            this.usernameLabel.Text = "Username:";
            // 
            // messageResponseGroupBox
            // 
            this.messageResponseGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.messageResponseGroupBox.Controls.Add(this.messageResponseTextBox);
            this.messageResponseGroupBox.Location = new System.Drawing.Point(499, 24);
            this.messageResponseGroupBox.Name = "messageResponseGroupBox";
            this.messageResponseGroupBox.Size = new System.Drawing.Size(320, 388);
            this.messageResponseGroupBox.TabIndex = 5;
            this.messageResponseGroupBox.TabStop = false;
            this.messageResponseGroupBox.Text = "Message Response";
            // 
            // messageResponseTextBox
            // 
            this.messageResponseTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.messageResponseTextBox.BackColor = System.Drawing.Color.Gray;
            this.messageResponseTextBox.Location = new System.Drawing.Point(6, 30);
            this.messageResponseTextBox.Multiline = true;
            this.messageResponseTextBox.Name = "messageResponseTextBox";
            this.messageResponseTextBox.Size = new System.Drawing.Size(308, 352);
            this.messageResponseTextBox.TabIndex = 5;
            this.messageResponseTextBox.TextChanged += new System.EventHandler(this.messageResponseTextBox_TextChanged);
            // 
            // RegisterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(827, 437);
            this.Controls.Add(this.messageResponseGroupBox);
            this.Controls.Add(this.registerUserGroupBox);
            this.Name = "RegisterForm";
            this.Text = "RegisterForm";
            this.registerUserGroupBox.ResumeLayout(false);
            this.registerUserGroupBox.PerformLayout();
            this.messageResponseGroupBox.ResumeLayout(false);
            this.messageResponseGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox registerUserGroupBox;
        private System.Windows.Forms.TextBox portTextBox;
        private System.Windows.Forms.TextBox hostTextBox;
        private System.Windows.Forms.Label portLabel;
        private System.Windows.Forms.Label hostLabel;
        private System.Windows.Forms.Button registerButton;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.TextBox usernameTextBox;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.Label usernameLabel;
        private System.Windows.Forms.GroupBox messageResponseGroupBox;
        private System.Windows.Forms.TextBox messageResponseTextBox;
    }
}