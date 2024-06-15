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
using System.Net;
using System.Reflection.Emit;
using Amazon.Runtime.Internal.Transform;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Ftp_Client
{
    public partial class MainForm : Form
    {

        public TcpClient client = new TcpClient();
        public NetworkStream stream;
        private TranferSiteForm transferSiteForm;
        private LocalSiteForm localSiteForm;
        private RemoteSiteForm remoteSiteForm;
        public MainForm()
        {
            InitializeComponent();
            transferSiteForm = new TranferSiteForm();
            localSiteForm = new LocalSiteForm();
            //remoteSiteForm = new RemoteSiteForm();
            localSiteForm.FileUploadRequested += async (sender, fileName) => await OnFileUploadRequested(sender, fileName);
         
        }



        /// <summary>
        /// START LAN PHUONG CODE
        /// </summary>

        // Tcp listener khi goi lenh PORT
        public TcpListener dataListener;

        // Tcp Client khi goi lenh PASV
        public TcpClient dataClient;


        private async Task OnAddListRequested(object sender, TreeNode node)
        {
            //.Show("ADD LIST");

            try
            {
                string fullPath = node.FullPath.Substring(1);
                //MessageBox.Show(fullPath);
                string ok = await sendCwdCommandAsync(fullPath);
                string dataResponse = " ";
                if (ok.StartsWith("250"))
                {

                    ok = await sendPwdCommandAsync();
                    if (ok.StartsWith("257"))
                    {
                        dataResponse = await sendListCommandAsync();
                    }

                }
                remoteSiteForm.updateContent(dataResponse, node);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

      
        // Tao TCP Listerner cho DATA connection -> ACTIVE / PORT
        private void createDataTcpListener(object obj_ipEndPoint)
        {
            try
            {
                IPEndPoint _ipEndPoint = (IPEndPoint)obj_ipEndPoint;
                dataListener = new TcpListener(_ipEndPoint);
                dataListener.Start();
                dataClient = dataListener.AcceptTcpClient();
            }
            catch (Exception)
            {
                MessageBox.Show("Error");
            }
            finally
            {
                dataListener?.Stop();
            }
        }


        /// TAO TCP Client cho Data connection -> PASSIVE / PASV
        public static string GetLocalIPv4()
        {
           
                // Lấy tất cả địa chỉ IP của máy
            IPAddress[] add = Dns.GetHostAddresses(Dns.GetHostName());
            if (add.Length > 2)
            {
                return add[1].ToString();
            }
            else
            {
                return "127.0.0.1";
            }
        }

        // SET PASSIVE OR ACTIVE MODE
        private async Task<bool> setDataConnection()
        {
            if (activeModeRadioButton.Checked)
            {
                byte[] buffer = new byte[1024];
                int bytesRead = 0;
                string response;

                IPAddress ip = IPAddress.Parse(GetLocalIPv4()); // IP cua client
                int freeport = PortFinder.GetRandomFreePort(); // Port random cua client
                IPEndPoint localipE = new IPEndPoint(ip, freeport);

                // Create TCP Listener
                Thread createDataTcpListenerThread = new Thread(createDataTcpListener);
                createDataTcpListenerThread.Start(localipE);


                // Send PORT
                string _cmd = $"PORT {ConvertToString(localipE)}\r\n";
                byte[] data = Encoding.UTF8.GetBytes(_cmd);
                await stream.WriteAsync(data, 0, data.Length);

                transferSiteForm.addItemLog("Status", "Sending PORT command...");
                // Receive response
                bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);
                response = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                
                if (response.StartsWith("200"))
                {
                    transferSiteForm.addItemLog("Status", response);
                    //MessageBox.Show(response, "Client", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
                else
                {
                    //MessageBox.Show("PORT command failed", "Client", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    transferSiteForm.addItemLog("Error", response);
                    return false;
                }
                  
            }
            else if (passiveModeRadioButton.Checked)
            {

                byte[] buffer = new byte[1024];
                int bytesRead = 0;
                string response;

                // Send PORT
                byte[] data = Encoding.UTF8.GetBytes("PASV\r\n");
                await stream.WriteAsync(data, 0, data.Length);
                transferSiteForm.addItemLog("Status", "Sending PASV command...");

                // Receive response
                bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);
                response = Encoding.UTF8.GetString(buffer, 0, bytesRead);

                // infoBox.Text += response + '\n'; // Phản hồi từ máy chủ sau khi gửi lệnh USER


                // Khúc này tao đang tạo message box thôi à, 
                if (response.StartsWith("227"))
                {
                    transferSiteForm.addItemLog("Status", response);
                    string ciStrWithBounder = response.Split(' ')[^1]; // Lấy phần tử cuối cùng sau khi tách chuỗi
                    string ciStr = ciStrWithBounder.Replace("\r\n", "").Replace("\n", "").Replace("\r", "").Replace("(", "").Replace(")", "");

                    IPEndPoint rmIpE = ConvertToConnectionInformation(ciStr);
                    //MessageBox.Show("Create data tcp client");
                    dataClient = new TcpClient();
   
                    await dataClient.ConnectAsync(rmIpE);
                    //MessageBox.Show("TUi ket noi r ne");
                    return true;
                }
                else
                {
                    MessageBox.Show("PASV command failed", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
            }
            else
            {
                MessageBox.Show("Please check mode", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                transferSiteForm.addItemLog("Error", "Error when sending PASV command");
                return false;
            }
        }
        public string ConvertToString(IPEndPoint _ipendpoint)
        {
            IPAddress _ipAddress = _ipendpoint.Address;
            int _port = _ipendpoint.Port;
            // Split the IP address into its four octets
            byte[] ipParts = _ipAddress.GetAddressBytes();

            // Calculate the port parts
            int p1 = _port / 256;
            int p2 = _port % 256;

            // Format the string as required by the FTP PORT command
            return $"{ipParts[0]},{ipParts[1]},{ipParts[2]},{ipParts[3]},{p1},{p2}";
        }

        // Convert tu string sang IPEndpoint
        public IPEndPoint ConvertToConnectionInformation(string str)
        {
            // Split the input string into parts
            string[] parts = str.Split(',');

            // Check if we have exactly 6 parts
            if (parts.Length != 6)
            {
                throw new FormatException("The input string must have exactly 6 parts.");
            }

            // Convert the first four parts to bytes for the IP address
            byte[] ipBytes = new byte[4];
            for (int i = 0; i < 4; i++)
            {
                ipBytes[i] = byte.Parse(parts[i]);
            }

            // Convert the last two parts to form the port number
            int port = (int.Parse(parts[4]) * 256) + int.Parse(parts[5]);

            // Create a new IPAddress object
            IPAddress ipAddress = new IPAddress(ipBytes);

            // Create and return a new ConnectionInformation object
            return new IPEndPoint(ipAddress, port);
        }


        /// <summary>
        /// END LAN PHUONG CODE
        /// </summary>

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

        private void MainForm_Load(object sender, EventArgs e)
        {
            //System.Drawing.Rectangle workingRectangle = Screen.PrimaryScreen.WorkingArea;
            //this.Size = new System.Drawing.Size(Convert.ToInt32(0.5 * workingRectangle.Width), Convert.ToInt32(0.5 * workingRectangle.Height));

            //this.Location = new System.Drawing.Point(10, 10);
            this.WindowState = FormWindowState.Maximized;

            loadForm(mainContainer.Panel2, transferSiteForm);
            loadForm(mainsiteContainer.Panel1, localSiteForm);
            //loadForm(mainsiteContainer.Panel2, remoteSiteForm);

        }


        private async Task<string> sendListCommandAsync()
        {
            try
            {
                bool ok = await setDataConnection();
                
                if (!ok)
                {
                    return "";
                }

                if (dataClient == null)
                {
                    MessageBox.Show("Error when create data client");
                    return "";
                    // Copy sau cua upload QUANH
                }
                ////
                ///
                byte[] buffer = new byte[1024];
                

                byte[] data = Encoding.UTF8.GetBytes("LIST");
                await stream.WriteAsync(data, 0, data.Length);
                
                transferSiteForm.addItemLog("Status", "Sending LIST command...");
                // Response cua LIST 150
                int bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);
                string response = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                
                if (response.StartsWith("150")){
                    transferSiteForm.addItemLog("Status", response);
                    using (NetworkStream dataStream = dataClient.GetStream())
                    {
                        // Nhan byte
                        byte[] dataBuffer = new byte[40960];
                        int dataByteRead = await dataStream.ReadAsync(dataBuffer, 0, dataBuffer.Length);

                        string dataResponse = Encoding.UTF8.GetString(dataBuffer);
                        // Nhan response 226 Operation successful
                        bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);
                        response = Encoding.UTF8.GetString(buffer, 0, bytesRead);

                        transferSiteForm.addItemLog("Status", response);
                        // update content into remotesite
                        //MessageBox.Show("Data response: " + dataResponse);

                        return dataResponse;
                    }
                }
                else
                {
                    transferSiteForm.addItemLog("Error", response);
                    dataClient.Close();
                    return "";
                }

                
            }
            catch (Exception)
            {
                transferSiteForm.addItemLog("Error", "Error when sending list command");
                dataClient.Close();
                return "";
            }
        } 

        private async void connectButton_Click(object sender, EventArgs e)
        {
            /* Đăng nhập và kết nối ở đây */
            //MessageBox.Show("Connect" + client.Connected.ToString());
            if (client.Connected)
            {
                stream?.Close();
                client.Close();
                
                //MessageBox.Show("Initial?");
            }
            client = new TcpClient(); // Reinitialize client
            // DEBUG Chỗ này xài, nhớ bỏ comment
            if (hostTextBox.Text == "" || portTextBox.Text == "" || usernameTextBox.Text == "" || passwdTextBox.Text == "")
            {
                MessageBox.Show("Please fill in all fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string ftpServer = hostTextBox.Text;
            int portServer = Convert.ToInt32(portTextBox.Text);
            string username = usernameTextBox.Text;
            string password = passwdTextBox.Text;

            try
            {
                transferSiteForm.addItemLog("Status", "Connecting to server...");
                await client.ConnectAsync(ftpServer, portServer);
                stream = client.GetStream();
                transferSiteForm.addItemLog("Status", "Conected to server");
                //buffer
                byte[] buffer = new byte[1024];
                int bytesRead;
                string response;
                /*// Fist response
                int bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);
                string response = Encoding.UTF8.GetString(buffer, 0, bytesRead);*/

                // Send user username
                byte[] data = Encoding.UTF8.GetBytes("USER " + username);
                await stream.WriteAsync(data, 0, data.Length);

                // Receive response
                bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);
                response = Encoding.UTF8.GetString(buffer, 0, bytesRead); // Phản hồi từ máy chủ sau khi gửi lệnh USER

                // Send password
                data = Encoding.UTF8.GetBytes("PASS " + password);
                await stream.WriteAsync(data, 0, data.Length);

                // Receive response
                bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);
                response = Encoding.UTF8.GetString(buffer, 0, bytesRead);

                if (response.StartsWith("230"))
                {
                    //MessageBox.Show(response, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    transferSiteForm.addItemLog("Status", response);
                    loadRemoteSiteForm();
                    //sendListCommandAsync();
                }
                else
                {
                    transferSiteForm.addItemLog("Eror", "Login failed");
                    if (client.Connected)
                    {
                        stream?.Close();
                        client.Close();
                    }
                }
                //MessageBox.Show("Đăng nhập thất bại! Username hoặc password không đúng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            catch (Exception ex)
            {
                transferSiteForm.addItemLog("Eror", "Failed to connect");
                if (client.Connected)
                {
                    stream?.Close();
                    client.Close();
                }
                MessageBox.Show("Đăng nhập thất bại! Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        // PHUONG 28/5
        private async Task<string> sendCwdCommandAsync(string requiredPath)
        {
            try
            {
                byte[] buffer = new byte[1024];
                string cmd = $"CWD {requiredPath}\r\n";
                transferSiteForm.addItemLog("Status", "Sending CWD command...");
                byte[] data = Encoding.UTF8.GetBytes(cmd);
                await stream.WriteAsync(data, 0, data.Length);

                int bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);
                string response = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                transferSiteForm.addItemLog("Status", response);
                //MessageBox.Show($"Send CWD: {response}", "Client");
                // Check response
                return response;
                /*if (response.StartsWith("250"))
                {
                    return true;
                }
                else
                {
                    return false;
                }*/
            }
            catch (Exception)
            {
                return string.Empty;
                //return false;
            }
        }

        // Gọi hàm này như này : string response = await sendPwdCommandAsync(requiredPath);
        private async Task<string> sendPwdCommandAsync()
        {
            try
            {
                byte[] buffer = new byte[1024];
                string cmd = "PWD\r\n";
                transferSiteForm.addItemLog("Status", "Sending PWD command...");
                byte[] data = Encoding.UTF8.GetBytes(cmd);
                await stream.WriteAsync(data, 0, data.Length);

                int bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);
                string response = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                transferSiteForm.addItemLog($"Status", response);
                if (response.StartsWith("257"))
                {
                    string remoteVirtualPath = response.Replace("257 ", "").Replace(" is current directory", "");
                    remoteSiteForm.remotePathTextBox.Text = remoteVirtualPath;
                    //MessageBox.Show("RESPONSE PWD: " + response);
                }
          
                return response;
            }
            catch (Exception)
            {
                transferSiteForm.addItemLog("Error", "Error when sending PWD command");
                return "Error when sending PWD command";
            }
        }

        private async Task SendREINCommand()
        {
            try
            {
                transferSiteForm.addItemLog("Status", "Sending REIN command...");
                if (client.Connected)
                {
                    stream = client.GetStream();
                    // Send REIN command
                    byte[] data = Encoding.UTF8.GetBytes("REIN\r\n");
                    await stream.WriteAsync(data, 0, data.Length);

                    // Receive response
                    byte[] buffer = new byte[1024];
                    int bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);
                    string response = Encoding.UTF8.GetString(buffer, 0, bytesRead);

                    if (response.StartsWith("220"))
                    {
                        transferSiteForm.addItemLog("Status", response);
                        loadRemoteSiteForm();
                    }
                    else
                    {
                        transferSiteForm.addItemLog("Error", "Failed to reset connection: " + response);
                    }
                }
                else
                {
                    transferSiteForm.addItemLog("Error", "Client is not connected.");
                }
            }
            catch (Exception ex)
            {
                transferSiteForm.addItemLog("Error", "Error sending REIN command: " + ex.Message);
            }
        }

        //QANH  - code
        //
        // Khi click vào nút reconnect
        private async void reconnectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /* Kết nối lại ở đây */
            await SendREINCommand();
        }

        private async void disconnectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            transferSiteForm.addItemLog("Status", "Sending QUIT command...");
            if (client == null)
            {
                transferSiteForm.addItemLog("Error", "Client is not connected.");
                return;
            }
            if (client.Connected)
            {
                stream = client.GetStream();
                // Send quit command
                byte[] data = Encoding.UTF8.GetBytes("QUIT\r\n");
                await stream.WriteAsync(data, 0, data.Length);

                // Receive response
                byte[] buffer = new byte[1024];
                int bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);
                string response = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                if (response.StartsWith("221"))
                {
                    transferSiteForm.addItemLog("Status", "Disconnect from server");
                    client.Close();
                    remoteSiteForm.Close();
                }
                else
                {
                    transferSiteForm.addItemLog("Error", "Failed to reset connection: " + response);
                }
            }
            else
            {
                transferSiteForm.addItemLog("Error", "Client is not connected.");
                return;
            }
        }

        // Không để làm gì cả
        private void inforServerConnectPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        //END - QANH  - code
        private void registerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new RegisterForm().Show();
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /* Cài đặt tài khoản ở đây */
        }


        private async Task<string> SendCommand(string command)
        {
            byte[] commandBytes = Encoding.UTF8.GetBytes(command + "\r\n");
            await stream.WriteAsync(commandBytes, 0, commandBytes.Length);
            return await ReadResponse();
        }
        private async Task<string> ReadResponse()
        {
            byte[] buffer = new byte[1024];
            int bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);
            return Encoding.UTF8.GetString(buffer, 0, bytesRead);
        }

        // localSiteForm
        private async Task OnFileUploadRequested(object sender,string filePath)
        {
            if (!client.Connected)
            {
                transferSiteForm.addItemLog("Error", "Not connected to the server.");
                return;
            }
            bool ok = await setDataConnection();
            // Upload the file
            await UploadFile(filePath);

        }
        private async Task UploadFile(string filePath)
        {
            //MessageBox.Show(filePath);
            try
            {
                // Step 1: Establish data connection (PASV or PORT)
                if (dataClient == null)
                {
                    transferSiteForm.addItemLog("Error", "Failed to establish data connection.");
                    return;
                }
                if (string.IsNullOrEmpty(filePath))
                {
                    transferSiteForm.addItemLog("Error", "filePath is null");
                    dataClient.Close();
                    return;
                }
                if (!File.Exists(filePath))
                {
                    transferSiteForm.addItemLog("Error", "File does not exist");
                    dataClient.Close();
                    return;
                }

                // Step 2: Send the STOR command
                // stor + filename
                string fileName = Path.GetFileName(filePath);
                string response = await SendCommand($"STOR {fileName}\r\n");
                transferSiteForm.addItemLog("Status", $"STOR {fileName}");
                if (!response.StartsWith("150"))
                {
                    transferSiteForm.addItemLog("Error", response);
                    dataClient.Close();
                    return;
                }
                else
                {
                    transferSiteForm.addItemLog("Status", response);
                    transferSiteForm.addItemLog("Status", "Starting data transfer");
                    // Step 3: Transfer the file
                    NetworkStream dataStream = dataClient.GetStream();
                    using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                    {
                        await fs.CopyToAsync(dataStream);
                    }
                    dataStream.Close();
                    dataClient.Close();
                    // Step 4: Receive final response
                    response = await ReadResponse();
                    transferSiteForm.addItemLog("Status", response.StartsWith("226") ? response : "Upload failed: " + response);
                }
            }
            catch (Exception ex)
            {
                transferSiteForm.addItemLog("Error", "Failed to upload file: " + ex.Message);
            }
        }
        // RemoteSite form
        private  async Task OnDownloadRequested(object sender, string filePath)
        {
            if (!client.Connected)
            {
                transferSiteForm.addItemLog("Error", "Not connected to the server.");
                return;
            }
            bool ok = await setDataConnection();
            // Download the file
            await DownloadFile(filePath);
        }
        private async Task DownloadFile(string remoteFilePath)
        {
            string localFilePath = localSiteForm.GetLocalPath();
            
            //step 1: Establish data connectio  n (PASV or PORT)
            
            if (dataClient == null)
            {
                transferSiteForm.addItemLog("Error", "Failed to establish data connection.");
                return ;
            }
            // step 2: Send the RETR command
            string fileName = Path.GetFileName(remoteFilePath);
            string response = await SendCommand($"RETR {fileName}\r\n");
            transferSiteForm.addItemLog("Status", $"RETR {fileName}");
            if (!response.StartsWith("150"))
            {
                transferSiteForm.addItemLog("Error", "Failed to start file download: " + response);
                dataClient.Close();
                return ;
            }
            else
            {
                transferSiteForm.addItemLog("Status", response);
                transferSiteForm.addItemLog("Status", "Starting data transfer");
            }

            // step 3: Receive the file and save it to the local disk
            try
            {
                // Assuming dataClient is a NetworkStream or similar
                using (NetworkStream networkStream = dataClient.GetStream())
                {
                    string pathSave = Path.Combine(localFilePath, fileName);
                    //MessageBox.Show(pathSave);
                    using (FileStream fileStream = new FileStream( pathSave,FileMode.Create, FileAccess.Write, FileShare.None))
                    {
                        await networkStream.CopyToAsync(fileStream);
                    }
                }
                response = await ReadResponse();
                transferSiteForm.addItemLog("Status", response);

            }
            catch (Exception ex)
            {
                transferSiteForm.addItemLog("Error", "Error during file download: " + ex.Message);
            }
            finally
            {
                dataClient.Close();
            }

        }
        // lắng nghe upload click bên localsite -> PASV/PORT -> data connection -> gửi lệnh STOR + pathfile -> ok thì gửi file qua dataconnection    
        // lăng nghe download bên remotesite -> PASV/ PORT -> data connection -> gửi lệnh RETR + pathfile -> nhận file và lưu trên local 


        // Code MKD RMD DELE
        private async void OnMkdRequested(object sender, string path)
        {
            //MessageBox.Show("MKD " + path);
            // Gửi request MKD
            NetworkStream stream = this.client.GetStream();
            byte[] data = Encoding.ASCII.GetBytes("MKD " + path);
            transferSiteForm.addItemLog("Status", "MKD " + path);
            await stream.WriteAsync(data, 0, data.Length);
            byte[] buffer = new byte[1024];
            int bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);
            string response = Encoding.ASCII.GetString(buffer, 0, bytesRead);
            transferSiteForm.addItemLog("Status", response);
            string mess = response.Substring(4);
            //MessageBox.Show(mess);
            // Load lại folderTree
            if (response.StartsWith("257"))
                remoteSiteForm.createNode(path);
        }
        private async void OnDeleRequested(object sender, string path)
        {
            //MessageBox.Show("DELE " + path);
            // Gửi request DELE
            NetworkStream stream = this.client.GetStream();
            byte[] data = Encoding.ASCII.GetBytes("DELE " + path);
            await stream.WriteAsync(data, 0, data.Length);
            transferSiteForm.addItemLog("Status", "DELE " + path);
            byte[] buffer = new byte[1024];
            int bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);
            string response = Encoding.ASCII.GetString(buffer, 0, bytesRead);
            transferSiteForm.addItemLog("Status", response);
            string mess = response.Substring(4);
            //MessageBox.Show(mess);
            // Load lại folderTree
            if (response.StartsWith("250"))
                remoteSiteForm.deleteNode(path);


        }
        private async void OnRmdRequested(object sender, string path)
        {
            //MessageBox.Show("RMD " + path);
            // Gửi request RMD
            NetworkStream stream = this.client.GetStream();
            byte[] data = Encoding.ASCII.GetBytes("RMD " + path);
            transferSiteForm.addItemLog("Status", "RMD " + path);
            await stream.WriteAsync(data, 0, data.Length);
            byte[] buffer = new byte[1024];
            int bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);
            string response = Encoding.ASCII.GetString(buffer, 0, bytesRead);
            transferSiteForm.addItemLog("Status", response);
            string mess = response.Substring(4);
            //MessageBox.Show(mess);
            // Load lại folderTree
            if (response.StartsWith("250"))
                remoteSiteForm.deleteNode(path);

        }
        
        // End
        // Load remotesite form
        public void loadRemoteSiteForm()
        {
            remoteSiteForm = new RemoteSiteForm();
            remoteSiteForm.AddListNodeRequested += OnAddListRequested;
            remoteSiteForm.MkdRequested += OnMkdRequested;
            remoteSiteForm.DeleRequested += OnDeleRequested;
            remoteSiteForm.RmdRequested += OnRmdRequested;
            remoteSiteForm.DownloadRequested += async (sender, fileName) => await OnDownloadRequested(sender, fileName);
            loadForm(mainsiteContainer.Panel2, remoteSiteForm);       
        }
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
    public class ConnectionInformation
    {

    }
    public class PortFinder
    {
        private static Random random = new Random();

        public static int GetRandomFreePort(int minPort = 1024, int maxPort = 65535)
        {
            int port;
            while (true)
            {
                port = random.Next(minPort, maxPort + 1);
                if (IsPortFree(port))
                {
                    break;
                }
            }
            return port;
        }

        private static bool IsPortFree(int port)
        {
            bool isAvailable = true;

            TcpListener tcpListener = null;
            try
            {
                tcpListener = new TcpListener(IPAddress.Any, port);
                tcpListener.Start();
            }
            catch (SocketException)
            {
                isAvailable = false;
            }
            finally
            {
                tcpListener?.Stop();
            }

            return isAvailable;
        }
    }
}
