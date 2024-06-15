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
            mainContainer = new SplitContainer();
            removeUserTextBox = new TextBox();
            addUserTextBox = new TextBox();
            removeUserButton = new Button();
            addNewUserButton = new Button();
            userListLabel = new Label();
            userListBox = new ListBox();
            cancelButton = new Button();
            passwordTextBox = new TextBox();
            passwordLabel = new Label();
            locationTextBox = new TextBox();
            virtualPathTextBox = new TextBox();
            locationLabel = new Label();
            virtualPathLabel = new Label();
            applyButton = new Button();
            usernameTextBox = new TextBox();
            usernameLabel = new Label();
            roleComboBox = new ComboBox();
            roleLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)mainContainer).BeginInit();
            mainContainer.Panel1.SuspendLayout();
            mainContainer.Panel2.SuspendLayout();
            mainContainer.SuspendLayout();
            SuspendLayout();
            // 
            // mainContainer
            // 
            mainContainer.BorderStyle = BorderStyle.Fixed3D;
            mainContainer.Dock = DockStyle.Fill;
            mainContainer.Location = new Point(0, 0);
            mainContainer.Margin = new Padding(3, 4, 3, 4);
            mainContainer.Name = "mainContainer";
            // 
            // mainContainer.Panel1
            // 
            mainContainer.Panel1.BackColor = SystemColors.ButtonHighlight;
            mainContainer.Panel1.Controls.Add(removeUserTextBox);
            mainContainer.Panel1.Controls.Add(addUserTextBox);
            mainContainer.Panel1.Controls.Add(removeUserButton);
            mainContainer.Panel1.Controls.Add(addNewUserButton);
            mainContainer.Panel1.Controls.Add(userListLabel);
            mainContainer.Panel1.Controls.Add(userListBox);
            // 
            // mainContainer.Panel2
            // 
            mainContainer.Panel2.Controls.Add(cancelButton);
            mainContainer.Panel2.Controls.Add(passwordTextBox);
            mainContainer.Panel2.Controls.Add(passwordLabel);
            mainContainer.Panel2.Controls.Add(locationTextBox);
            mainContainer.Panel2.Controls.Add(virtualPathTextBox);
            mainContainer.Panel2.Controls.Add(locationLabel);
            mainContainer.Panel2.Controls.Add(virtualPathLabel);
            mainContainer.Panel2.Controls.Add(applyButton);
            mainContainer.Panel2.Controls.Add(usernameTextBox);
            mainContainer.Panel2.Controls.Add(usernameLabel);
            mainContainer.Panel2.Controls.Add(roleComboBox);
            mainContainer.Panel2.Controls.Add(roleLabel);
            mainContainer.Size = new Size(1271, 713);
            mainContainer.SplitterDistance = 421;
            mainContainer.TabIndex = 0;
            // 
            // removeUserTextBox
            // 
            removeUserTextBox.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            removeUserTextBox.BackColor = SystemColors.ButtonFace;
            removeUserTextBox.BorderStyle = BorderStyle.FixedSingle;
            removeUserTextBox.Location = new Point(23, 638);
            removeUserTextBox.Margin = new Padding(3, 4, 3, 4);
            removeUserTextBox.Name = "removeUserTextBox";
            removeUserTextBox.Size = new Size(210, 39);
            removeUserTextBox.TabIndex = 14;
            // 
            // addUserTextBox
            // 
            addUserTextBox.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            addUserTextBox.BorderStyle = BorderStyle.FixedSingle;
            addUserTextBox.Location = new Point(23, 558);
            addUserTextBox.Margin = new Padding(3, 4, 3, 4);
            addUserTextBox.Name = "addUserTextBox";
            addUserTextBox.Size = new Size(210, 39);
            addUserTextBox.TabIndex = 13;
            // 
            // removeUserButton
            // 
            removeUserButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            removeUserButton.Location = new Point(255, 624);
            removeUserButton.Margin = new Padding(3, 4, 3, 4);
            removeUserButton.Name = "removeUserButton";
            removeUserButton.Size = new Size(145, 68);
            removeUserButton.TabIndex = 13;
            removeUserButton.Text = "Remove";
            removeUserButton.UseVisualStyleBackColor = true;
            removeUserButton.Click += removeUserButton_Click;
            // 
            // addNewUserButton
            // 
            addNewUserButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            addNewUserButton.Location = new Point(255, 544);
            addNewUserButton.Margin = new Padding(3, 4, 3, 4);
            addNewUserButton.Name = "addNewUserButton";
            addNewUserButton.Size = new Size(145, 68);
            addNewUserButton.TabIndex = 14;
            addNewUserButton.Text = "Add";
            addNewUserButton.UseVisualStyleBackColor = true;
            addNewUserButton.Click += addNewUserButton_Click;
            // 
            // userListLabel
            // 
            userListLabel.AutoSize = true;
            userListLabel.Location = new Point(3, 13);
            userListLabel.Name = "userListLabel";
            userListLabel.Size = new Size(156, 32);
            userListLabel.TabIndex = 1;
            userListLabel.Text = "Already users";
            // 
            // userListBox
            // 
            userListBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            userListBox.FormattingEnabled = true;
            userListBox.Location = new Point(2, 59);
            userListBox.Margin = new Padding(3, 4, 3, 4);
            userListBox.Name = "userListBox";
            userListBox.ScrollAlwaysVisible = true;
            userListBox.Size = new Size(414, 452);
            userListBox.TabIndex = 0;
            userListBox.SelectedIndexChanged += userListBox_SelectedIndexChanged;
            // 
            // cancelButton
            // 
            cancelButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            cancelButton.Location = new Point(681, 624);
            cancelButton.Margin = new Padding(3, 4, 3, 4);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(150, 68);
            cancelButton.TabIndex = 12;
            cancelButton.Text = "Cancel";
            cancelButton.UseVisualStyleBackColor = true;
            cancelButton.Click += cancelButton_Click;
            // 
            // passwordTextBox
            // 
            passwordTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            passwordTextBox.Location = new Point(197, 175);
            passwordTextBox.Margin = new Padding(3, 4, 3, 4);
            passwordTextBox.Name = "passwordTextBox";
            passwordTextBox.Size = new Size(571, 39);
            passwordTextBox.TabIndex = 11;
            passwordTextBox.UseSystemPasswordChar = true;
            passwordTextBox.Enter += passwordTextBox_Enter;
            passwordTextBox.Leave += passwordTextBox_Leave;
            // 
            // passwordLabel
            // 
            passwordLabel.AutoSize = true;
            passwordLabel.Location = new Point(42, 183);
            passwordLabel.Name = "passwordLabel";
            passwordLabel.Size = new Size(116, 32);
            passwordLabel.TabIndex = 10;
            passwordLabel.Text = "Password:";
            // 
            // locationTextBox
            // 
            locationTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            locationTextBox.Location = new Point(197, 416);
            locationTextBox.Margin = new Padding(3, 4, 3, 4);
            locationTextBox.Name = "locationTextBox";
            locationTextBox.Size = new Size(571, 39);
            locationTextBox.TabIndex = 9;
            locationTextBox.Enter += locationTextBox_Enter;
            // 
            // virtualPathTextBox
            // 
            virtualPathTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            virtualPathTextBox.Location = new Point(197, 335);
            virtualPathTextBox.Margin = new Padding(3, 4, 3, 4);
            virtualPathTextBox.Name = "virtualPathTextBox";
            virtualPathTextBox.Size = new Size(571, 39);
            virtualPathTextBox.TabIndex = 8;
            // 
            // locationLabel
            // 
            locationLabel.AutoSize = true;
            locationLabel.Location = new Point(42, 420);
            locationLabel.Name = "locationLabel";
            locationLabel.Size = new Size(109, 32);
            locationLabel.TabIndex = 7;
            locationLabel.Text = "Location:";
            // 
            // virtualPathLabel
            // 
            virtualPathLabel.AutoSize = true;
            virtualPathLabel.Location = new Point(42, 339);
            virtualPathLabel.Name = "virtualPathLabel";
            virtualPathLabel.Size = new Size(141, 32);
            virtualPathLabel.TabIndex = 6;
            virtualPathLabel.Text = "Virtual Path:";
            // 
            // applyButton
            // 
            applyButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            applyButton.Location = new Point(525, 624);
            applyButton.Margin = new Padding(3, 4, 3, 4);
            applyButton.Name = "applyButton";
            applyButton.Size = new Size(150, 68);
            applyButton.TabIndex = 5;
            applyButton.Text = "Apply";
            applyButton.UseVisualStyleBackColor = true;
            applyButton.Click += applyButton_Click;
            // 
            // usernameTextBox
            // 
            usernameTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            usernameTextBox.BackColor = SystemColors.ControlDark;
            usernameTextBox.Location = new Point(197, 101);
            usernameTextBox.Margin = new Padding(3, 4, 3, 4);
            usernameTextBox.Name = "usernameTextBox";
            usernameTextBox.ReadOnly = true;
            usernameTextBox.Size = new Size(571, 39);
            usernameTextBox.TabIndex = 4;
            // 
            // usernameLabel
            // 
            usernameLabel.AutoSize = true;
            usernameLabel.Location = new Point(42, 109);
            usernameLabel.Name = "usernameLabel";
            usernameLabel.Size = new Size(126, 32);
            usernameLabel.TabIndex = 2;
            usernameLabel.Text = "Username:";
            // 
            // roleComboBox
            // 
            roleComboBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            roleComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            roleComboBox.FormattingEnabled = true;
            roleComboBox.Items.AddRange(new object[] { "Read Only", "Read and Write" });
            roleComboBox.Location = new Point(197, 252);
            roleComboBox.Margin = new Padding(3, 4, 3, 4);
            roleComboBox.Name = "roleComboBox";
            roleComboBox.Size = new Size(571, 40);
            roleComboBox.TabIndex = 1;
            // 
            // roleLabel
            // 
            roleLabel.AutoSize = true;
            roleLabel.Location = new Point(42, 256);
            roleLabel.Name = "roleLabel";
            roleLabel.Size = new Size(140, 32);
            roleLabel.TabIndex = 0;
            roleLabel.Text = "User access:";
            // 
            // ManageUsersForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1271, 713);
            Controls.Add(mainContainer);
            Margin = new Padding(3, 4, 3, 4);
            Name = "ManageUsersForm";
            Text = "Manage Users Form";
            Load += ManageUsersForm_Load;
            mainContainer.Panel1.ResumeLayout(false);
            mainContainer.Panel1.PerformLayout();
            mainContainer.Panel2.ResumeLayout(false);
            mainContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)mainContainer).EndInit();
            mainContainer.ResumeLayout(false);
            ResumeLayout(false);
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