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

namespace Ftp_Client
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void messageResponseTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private async void registerButton_Click(object sender, EventArgs e)
        {
            string ftpServer = hostTextBox.Text.Trim();
            int portServer = Convert.ToInt32(portTextBox.Text.Trim());
            string username = usernameTextBox.Text.Trim();
            string password = passwordTextBox.Text.Trim();

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
                        messageResponseTextBox.Text += response + '\n';

                        // Send user username and password
                        byte[] data = Encoding.ASCII.GetBytes($"REGISTER {username} {password}");
                        await stream.WriteAsync(data, 0, data.Length);

                        // Receive response
                        bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);
                        response = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                        messageResponseTextBox.Text += response + '\n'; // Phản hồi từ máy chủ sau khi gửi lệnh REGISTER               

                        MessageBox.Show("Đăng kí thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Đăng kí thất bại! Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
