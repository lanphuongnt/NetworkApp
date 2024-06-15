using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BCrypt.Net;
using System.Net;
using System.Net.Sockets;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.IO;
using System.Diagnostics;
using System.Threading;
using MongoDB.Driver.Core.Operations;
using System.Text.RegularExpressions;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Ftp_Server
{
    public partial class ManageUsersForm : Form
    {
        NetworkStream currentStream;
        List<Account> allUsers;
        public ManageUsersForm()
        {
            InitializeComponent();
        }
        public ManageUsersForm(NetworkStream stream, string username, string passwd)
        {
            usernameTextBox.Text = username;
            passwordTextBox.Text = passwd;
            currentStream = stream;
        }

        private void applyButton_Click(object sender, EventArgs e)
        {
            if (passwordTextBox.Text == string.Empty)
            {
                MessageBox.Show("Password is not empty");
                return;
            }
            string encrypt_passwd = string.Empty;
            if (passwordTextBox.Text != "Enter new password?")
            {
                encrypt_passwd = BCrypt.Net.BCrypt.EnhancedHashPassword(passwordTextBox.Text);
            }

            MongoClient conn = new MyMongoDBConnect().connection;
            var accountCollection = conn.GetDatabase("users").GetCollection<Account>("account");

            // Khong can check already vi cai phan add da check roi
            // Update or insert?
            var filter = Builders<Account>.Filter.Eq("username", usernameTextBox.Text);
            var options = new UpdateOptions { IsUpsert = true };
            UpdateDefinition<Account> update;
            if (encrypt_passwd != string.Empty) // Update passwd
            {
                update = Builders<Account>.Update.Set("passwd", encrypt_passwd);
                accountCollection.UpdateOne(filter, update, options);
            }
            update = Builders<Account>.Update.Set("role", roleComboBox.Text)
                                             .Set("virtualpath", virtualPathTextBox.Text)
                                             .Set("location", locationTextBox.Text);
            accountCollection.UpdateOne(filter, update, options);
            MessageBox.Show("Apply successfully.");
            // add a new user to allUsers
            if (userListBox.SelectedIndex > -1 )
            {
                // Bị lỗi nếu mà add user nhưng không thay đổi thông tin.
                if (userListBox.SelectedIndex < allUsers.Count)
                {
                    allUsers[userListBox.SelectedIndex].passwd = encrypt_passwd;
                }
                else
                {
                    allUsers.Add(findOneAlreadyUsers(usernameTextBox.Text));
                }
            }
        }

        private void locationTextBox_Enter(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    locationTextBox.Text = fbd.SelectedPath;
                }
            } 
        }

        private static Account findOneAlreadyUsers(string username)
        {
            MongoClient client = new MyMongoDBConnect().connection;
            var database = client.GetDatabase("users");
            var collection = database.GetCollection<Account>("account");
            // Xây dựng truy vấn
            var filter = Builders<Account>.Filter.Eq("username", username);
            return collection.Find(filter).FirstOrDefault();
        }
        private static async Task<List<Account>> findAllAlreadyUsers()
        {
            MongoClient client = new MyMongoDBConnect().connection;
            var database = client.GetDatabase("users");
            var collection = database.GetCollection<Account>("account");
            // Xây dựng truy vấn
            var filter = Builders<Account>.Filter.Empty;
            return await collection.Find(filter).ToListAsync();
        }

        public async void ManageUsersForm_Load(object sender, EventArgs e)
        {
            allUsers = await findAllAlreadyUsers();
            userListBox.Invoke((MethodInvoker)delegate
            {
                userListBox.Items.Clear();
                foreach (Account user in allUsers)
                {
                    userListBox.Items.Add(user.username);
                }
            });

        }

        private void userListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
        
            if (userListBox.SelectedIndex > -1 && userListBox.SelectedIndex < allUsers.Count)
            {
                int id = userListBox.SelectedIndex;
                Account aUser = allUsers[id];
                usernameTextBox.Text = aUser.username; // choose user
                roleComboBox.SelectedIndex = (aUser.role == "Read Only" ? 0 : 1);
                virtualPathTextBox.Text = aUser.virtualpath;
                locationTextBox.Text = aUser.location;

                // password text box
                passwordTextBox.UseSystemPasswordChar = false;
                passwordTextBox.Text = "Enter new password?";
                passwordTextBox.ForeColor = Color.Gray;
            }
            else
            {
                usernameTextBox.Text = userListBox.GetItemText(userListBox.SelectedItem);
                passwordTextBox.Clear();
                passwordTextBox.UseSystemPasswordChar = true;

                roleComboBox.SelectedIndex = -1;
                virtualPathTextBox.Clear();
                locationTextBox.Clear();
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void passwordTextBox_Enter(object sender, EventArgs e)
        {
            if (userListBox.SelectedIndex > -1 && userListBox.SelectedIndex < allUsers.Count)
            {
                if (passwordTextBox.Text == "Enter new password?")
                {
                    passwordTextBox.ForeColor = Color.Black;
                    passwordTextBox.UseSystemPasswordChar = true;
                    passwordTextBox.Clear();
                }
            }
        }

        private void passwordTextBox_Leave(object sender, EventArgs e)
        {
            if (userListBox.SelectedIndex > -1 && userListBox.SelectedIndex < allUsers.Count)
            {
                if (string.IsNullOrEmpty(passwordTextBox.Text))
                {
                    passwordTextBox.UseSystemPasswordChar = false;
                    passwordTextBox.Text = "Enter new password?";
                    passwordTextBox.ForeColor = Color.Gray;
                }
                else
                {
                    passwordTextBox.UseSystemPasswordChar = true;
                }
            }
        }

        private void addNewUserButton_Click(object sender, EventArgs e)
        {
            Regex regex = new Regex(@"^[A-Za-z0-9_@]{1,20}$");
            if (addUserTextBox.Text != string.Empty)
            {
                if (regex.IsMatch(addUserTextBox.Text))
                {
                    if (!userListBox.Items.Contains(addUserTextBox.Text))
                    {
                        userListBox.Items.Add(addUserTextBox.Text);
                    }
                    else
                    {
                        MessageBox.Show("Already user");
                    }
                }
                else
                {
                    MessageBox.Show("Invalid username");
                }
                addUserTextBox.Clear();
            }
          
        }

        private void removeUserButton_Click(object sender, EventArgs e)
        {
            Regex regex = new Regex(@"^[A-Za-z0-9_@]{1,20}$");
            if (removeUserTextBox.Text != string.Empty)
            {
                if (regex.IsMatch(removeUserTextBox.Text))
                {
                    if (userListBox.Items.Contains(removeUserTextBox.Text))
                    {
                        MongoClient client = new MyMongoDBConnect().connection;
                        var database = client.GetDatabase("users");
                        var collection = database.GetCollection<Account>("account");
                        // Xây dựng truy vấn
                        var filter = Builders<Account>.Filter.Eq("username", removeUserTextBox.Text);
                        allUsers.RemoveAt(userListBox.SelectedIndex);
                        userListBox.Items.Remove(removeUserTextBox.Text);
                        collection.DeleteOne(filter);
                    }
                    else
                    {
                        MessageBox.Show("Invalid");
                    }
                }
                else
                {
                    MessageBox.Show("Invalid username");
                }
                removeUserTextBox.Clear();
            }
        }
    }
}
