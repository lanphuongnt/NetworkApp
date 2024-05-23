namespace Ftp_Server
{
    partial class ManageUsersForm
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
            this.removeUserTextBox = new System.Windows.Forms.TextBox();
            this.addUserTextBox = new System.Windows.Forms.TextBox();
            this.removeUserButton = new System.Windows.Forms.Button();
            this.addNewUserButton = new System.Windows.Forms.Button();
            this.userListLabel = new System.Windows.Forms.Label();
            this.userListBox = new System.Windows.Forms.ListBox();
            this.cancelButton = new System.Windows.Forms.Button();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.locationTextBox = new System.Windows.Forms.TextBox();
            this.virtualPathTextBox = new System.Windows.Forms.TextBox();
            this.locationLabel = new System.Windows.Forms.Label();
            this.virtualPathLabel = new System.Windows.Forms.Label();
            this.applyButton = new System.Windows.Forms.Button();
            this.usernameTextBox = new System.Windows.Forms.TextBox();
            this.usernameLabel = new System.Windows.Forms.Label();
            this.roleComboBox = new System.Windows.Forms.ComboBox();
            this.roleLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.mainContainer)).BeginInit();
            this.mainContainer.Panel1.SuspendLayout();
            this.mainContainer.Panel2.SuspendLayout();
            this.mainContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainContainer
            // 
            this.mainContainer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.mainContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainContainer.Location = new System.Drawing.Point(0, 0);
            this.mainContainer.Name = "mainContainer";
            // 
            // mainContainer.Panel1
            // 
            this.mainContainer.Panel1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.mainContainer.Panel1.Controls.Add(this.removeUserTextBox);
            this.mainContainer.Panel1.Controls.Add(this.addUserTextBox);
            this.mainContainer.Panel1.Controls.Add(this.removeUserButton);
            this.mainContainer.Panel1.Controls.Add(this.addNewUserButton);
            this.mainContainer.Panel1.Controls.Add(this.userListLabel);
            this.mainContainer.Panel1.Controls.Add(this.userListBox);
            // 
            // mainContainer.Panel2
            // 
            this.mainContainer.Panel2.Controls.Add(this.cancelButton);
            this.mainContainer.Panel2.Controls.Add(this.passwordTextBox);
            this.mainContainer.Panel2.Controls.Add(this.passwordLabel);
            this.mainContainer.Panel2.Controls.Add(this.locationTextBox);
            this.mainContainer.Panel2.Controls.Add(this.virtualPathTextBox);
            this.mainContainer.Panel2.Controls.Add(this.locationLabel);
            this.mainContainer.Panel2.Controls.Add(this.virtualPathLabel);
            this.mainContainer.Panel2.Controls.Add(this.applyButton);
            this.mainContainer.Panel2.Controls.Add(this.usernameTextBox);
            this.mainContainer.Panel2.Controls.Add(this.usernameLabel);
            this.mainContainer.Panel2.Controls.Add(this.roleComboBox);
            this.mainContainer.Panel2.Controls.Add(this.roleLabel);
            this.mainContainer.Size = new System.Drawing.Size(1173, 557);
            this.mainContainer.SplitterDistance = 389;
            this.mainContainer.TabIndex = 0;
            // 
            // removeUserTextBox
            // 
            this.removeUserTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.removeUserTextBox.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.removeUserTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.removeUserTextBox.Location = new System.Drawing.Point(21, 498);
            this.removeUserTextBox.Name = "removeUserTextBox";
            this.removeUserTextBox.Size = new System.Drawing.Size(194, 31);
            this.removeUserTextBox.TabIndex = 14;
            // 
            // addUserTextBox
            // 
            this.addUserTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.addUserTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.addUserTextBox.Location = new System.Drawing.Point(21, 435);
            this.addUserTextBox.Name = "addUserTextBox";
            this.addUserTextBox.Size = new System.Drawing.Size(194, 31);
            this.addUserTextBox.TabIndex = 13;
            // 
            // removeUserButton
            // 
            this.removeUserButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.removeUserButton.Location = new System.Drawing.Point(235, 487);
            this.removeUserButton.Name = "removeUserButton";
            this.removeUserButton.Size = new System.Drawing.Size(134, 53);
            this.removeUserButton.TabIndex = 13;
            this.removeUserButton.Text = "Remove";
            this.removeUserButton.UseVisualStyleBackColor = true;
            this.removeUserButton.Click += new System.EventHandler(this.removeUserButton_Click);
            // 
            // addNewUserButton
            // 
            this.addNewUserButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.addNewUserButton.Location = new System.Drawing.Point(235, 424);
            this.addNewUserButton.Name = "addNewUserButton";
            this.addNewUserButton.Size = new System.Drawing.Size(134, 53);
            this.addNewUserButton.TabIndex = 14;
            this.addNewUserButton.Text = "Add";
            this.addNewUserButton.UseVisualStyleBackColor = true;
            this.addNewUserButton.Click += new System.EventHandler(this.addNewUserButton_Click);
            // 
            // userListLabel
            // 
            this.userListLabel.AutoSize = true;
            this.userListLabel.Location = new System.Drawing.Point(3, 10);
            this.userListLabel.Name = "userListLabel";
            this.userListLabel.Size = new System.Drawing.Size(144, 25);
            this.userListLabel.TabIndex = 1;
            this.userListLabel.Text = "Already users";
            // 
            // userListBox
            // 
            this.userListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.userListBox.FormattingEnabled = true;
            this.userListBox.ItemHeight = 25;
            this.userListBox.Location = new System.Drawing.Point(2, 46);
            this.userListBox.Name = "userListBox";
            this.userListBox.ScrollAlwaysVisible = true;
            this.userListBox.Size = new System.Drawing.Size(382, 354);
            this.userListBox.TabIndex = 0;
            this.userListBox.SelectedIndexChanged += new System.EventHandler(this.userListBox_SelectedIndexChanged);
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.Location = new System.Drawing.Point(628, 487);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(138, 53);
            this.cancelButton.TabIndex = 12;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.passwordTextBox.Location = new System.Drawing.Point(182, 137);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.Size = new System.Drawing.Size(526, 31);
            this.passwordTextBox.TabIndex = 11;
            this.passwordTextBox.UseSystemPasswordChar = true;
            this.passwordTextBox.Enter += new System.EventHandler(this.passwordTextBox_Enter);
            this.passwordTextBox.Leave += new System.EventHandler(this.passwordTextBox_Leave);
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Location = new System.Drawing.Point(39, 143);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(112, 25);
            this.passwordLabel.TabIndex = 10;
            this.passwordLabel.Text = "Password:";
            // 
            // locationTextBox
            // 
            this.locationTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.locationTextBox.Location = new System.Drawing.Point(182, 325);
            this.locationTextBox.Name = "locationTextBox";
            this.locationTextBox.Size = new System.Drawing.Size(526, 31);
            this.locationTextBox.TabIndex = 9;
            this.locationTextBox.Enter += new System.EventHandler(this.locationTextBox_Enter);
            // 
            // virtualPathTextBox
            // 
            this.virtualPathTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.virtualPathTextBox.Location = new System.Drawing.Point(182, 262);
            this.virtualPathTextBox.Name = "virtualPathTextBox";
            this.virtualPathTextBox.Size = new System.Drawing.Size(526, 31);
            this.virtualPathTextBox.TabIndex = 8;
            // 
            // locationLabel
            // 
            this.locationLabel.AutoSize = true;
            this.locationLabel.Location = new System.Drawing.Point(39, 328);
            this.locationLabel.Name = "locationLabel";
            this.locationLabel.Size = new System.Drawing.Size(100, 25);
            this.locationLabel.TabIndex = 7;
            this.locationLabel.Text = "Location:";
            // 
            // virtualPathLabel
            // 
            this.virtualPathLabel.AutoSize = true;
            this.virtualPathLabel.Location = new System.Drawing.Point(39, 265);
            this.virtualPathLabel.Name = "virtualPathLabel";
            this.virtualPathLabel.Size = new System.Drawing.Size(129, 25);
            this.virtualPathLabel.TabIndex = 6;
            this.virtualPathLabel.Text = "Virtual Path:";
            // 
            // applyButton
            // 
            this.applyButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.applyButton.Location = new System.Drawing.Point(484, 487);
            this.applyButton.Name = "applyButton";
            this.applyButton.Size = new System.Drawing.Size(138, 53);
            this.applyButton.TabIndex = 5;
            this.applyButton.Text = "Apply";
            this.applyButton.UseVisualStyleBackColor = true;
            this.applyButton.Click += new System.EventHandler(this.applyButton_Click);
            // 
            // usernameTextBox
            // 
            this.usernameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.usernameTextBox.BackColor = System.Drawing.SystemColors.ControlDark;
            this.usernameTextBox.Location = new System.Drawing.Point(182, 79);
            this.usernameTextBox.Name = "usernameTextBox";
            this.usernameTextBox.ReadOnly = true;
            this.usernameTextBox.Size = new System.Drawing.Size(526, 31);
            this.usernameTextBox.TabIndex = 4;
            // 
            // usernameLabel
            // 
            this.usernameLabel.AutoSize = true;
            this.usernameLabel.Location = new System.Drawing.Point(39, 85);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(116, 25);
            this.usernameLabel.TabIndex = 2;
            this.usernameLabel.Text = "Username:";
            // 
            // roleComboBox
            // 
            this.roleComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.roleComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.roleComboBox.FormattingEnabled = true;
            this.roleComboBox.Items.AddRange(new object[] {
            "Read Only",
            "Read and Write"});
            this.roleComboBox.Location = new System.Drawing.Point(182, 197);
            this.roleComboBox.Name = "roleComboBox";
            this.roleComboBox.Size = new System.Drawing.Size(526, 33);
            this.roleComboBox.TabIndex = 1;
            // 
            // roleLabel
            // 
            this.roleLabel.AutoSize = true;
            this.roleLabel.Location = new System.Drawing.Point(39, 200);
            this.roleLabel.Name = "roleLabel";
            this.roleLabel.Size = new System.Drawing.Size(137, 25);
            this.roleLabel.TabIndex = 0;
            this.roleLabel.Text = "User access:";
            // 
            // ManageUsersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1173, 557);
            this.Controls.Add(this.mainContainer);
            this.Name = "ManageUsersForm";
            this.Text = "Manage Users Form";
            this.Load += new System.EventHandler(this.ManageUsersForm_Load);
            this.mainContainer.Panel1.ResumeLayout(false);
            this.mainContainer.Panel1.PerformLayout();
            this.mainContainer.Panel2.ResumeLayout(false);
            this.mainContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainContainer)).EndInit();
            this.mainContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer mainContainer;
        private System.Windows.Forms.Label roleLabel;
        private System.Windows.Forms.ComboBox roleComboBox;
        private System.Windows.Forms.Label usernameLabel;
        private System.Windows.Forms.TextBox usernameTextBox;
        private System.Windows.Forms.Button applyButton;
        private System.Windows.Forms.Label virtualPathLabel;
        private System.Windows.Forms.Label locationLabel;
        private System.Windows.Forms.TextBox virtualPathTextBox;
        private System.Windows.Forms.TextBox locationTextBox;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.ListBox userListBox;
        private System.Windows.Forms.Label userListLabel;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button removeUserButton;
        private System.Windows.Forms.Button addNewUserButton;
        private System.Windows.Forms.TextBox removeUserTextBox;
        private System.Windows.Forms.TextBox addUserTextBox;
    }
}