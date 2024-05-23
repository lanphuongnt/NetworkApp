using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using BCrypt.Net;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Ftp_Client
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        

        public void loadForm(object Panel, object Form)
        {
            Panel p = Panel as Panel;
            if (p.Controls.Count > 0)
            {
                p.Controls.RemoveAt(0);
            }
            Form f = Form as Form;
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            p.Controls.Add(f);
            p.Tag = f;
            f.Show();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            System.Drawing.Rectangle workingRectangle = Screen.PrimaryScreen.WorkingArea;
            this.Size = new System.Drawing.Size(Convert.ToInt32(0.5 * workingRectangle.Width), 
                Convert.ToInt32(0.5 *workingRectangle.Height));

            this.Location = new System.Drawing.Point(10, 10);
            loadForm(mainContainer.Panel2, new TranferSiteForm());
            loadForm(mainsiteContainer.Panel1, new LocalSiteForm());
            loadForm(mainsiteContainer.Panel2, new RemoteSiteForm());
                
        }

        private async void connectButton_Click(object sender, EventArgs e)
        {
            /* Đăng nhập và kết nối ở đây */
            string ftpServer = hostTextBox.Text;
            int portServer = Convert.ToInt32(portTextBox.Text);
            string username = usernameTextBox.Text;
            string password = passwdTextBox.Text;
            using (TcpClient client = new TcpClient())
            {
                try
                {
                    await client.ConnectAsync(ftpServer, portServer);
                    using (NetworkStream stream = client.GetStream())
                    {

                        byte[] buffer = new byte[1024];

                        // Fist response
                        int bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);
                        string response = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                        // infoBox.Text += response + '\n';

                        // Send user username
                        byte[] data = Encoding.ASCII.GetBytes("USER " + username);
                        await stream.WriteAsync(data, 0, data.Length);

                        // Receive response
                        bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);
                        response = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                        // infoBox.Text += response + '\n'; // Phản hồi từ máy chủ sau khi gửi lệnh USER

                        // Send password
                        data = Encoding.ASCII.GetBytes("PASS " + password);
                        await stream.WriteAsync(data, 0, data.Length);

                        // Receive response
                        bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);
                        response = Encoding.ASCII.GetString(buffer, 0, bytesRead);

                        if (response.StartsWith("230"))
                            MessageBox.Show("Đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else
                            MessageBox.Show("Đăng nhập thất bại! Username hoặc password không đúng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Đăng nhập thất bại! Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }


        }

        // Không để làm gì cả
        private void inforServerConnectPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void reconnectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /* Kết nối lại ở đây */
        }

        private void disconnectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /* Ngắt kết nối ở đây */
        }

        private void registerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new RegisterForm().Show();
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /* Cài đặt tài khoản ở đây */
        }

        /* 
         * Upload nam trong LocalSiteForm
         * Download nam trong RemoteSiteForm
         */

    }
    public class Account
    {
        public ObjectId _id { get; set; }

        [BsonElement("username")]
        public string username { get; set; }

        [BsonElement("passwd")]
        public string passwd { get; set; }

        public Account(string _username, string _passwd)
        {
            this.username = _username;
            this.passwd = _passwd;
        }

    }

}
