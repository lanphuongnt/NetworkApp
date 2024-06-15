using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
using MongoDB.Driver;
using MongoDB.Bson;
using System.CodeDom;
using MongoDB.Bson.Serialization.Attributes;
using BCrypt.Net;
using System.IO;
using SharpCompress.Compressors.Xz;
using System.Net.NetworkInformation;

namespace Ftp_Server
{
    public partial class MainForm : Form
    {
        private string host = GetLocalIPv4();
        private string password = "";
        public bool runServer = false;
        private int control_port = 21; // phải đảm bảo port này đang trống 
        private TcpListener listener;
        private Thread listenThread;

        private string type1 = "Request"; // FIX
        private string type2 = "Response";
        private string type3 = "Error";
        private string time = "";

        private Dictionary<string, FtpConnection> connectedClients = new Dictionary<string, FtpConnection>(); // -QANH
        
        public MainForm()
        {
            InitializeComponent();
        }

        public static string GetLocalIPv4()
        {
            foreach (NetworkInterface ni in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (ni.NetworkInterfaceType == NetworkInterfaceType.Wireless80211 &&
                    ni.OperationalStatus == OperationalStatus.Up)
                {
                    foreach (UnicastIPAddressInformation ip in ni.GetIPProperties().UnicastAddresses)
                    {
                        if (ip.Address.AddressFamily == AddressFamily.InterNetwork)
                        {
                            return ip.Address.ToString();
                        }
                    }
                }
            }
            return "127.0.0.1";
        }

        // Handle viewLog
        private void CreateHeaders_viewLog()
        {
            // Clear existing columns
            viewLog.Columns.Clear();

            // Add new columns
            viewLog.Columns.Add("Date/Time");
            viewLog.Columns.Add("Type");
            viewLog.Columns.Add("Message");

            // Set column widths
            viewLog.Columns[0].Width = 200;
            viewLog.Columns[1].Width = 200;
            viewLog.Columns[2].Width = 500;

            viewLog.View = View.Details;
        }
        private void CreateHeaders_viewSession()
        {
            // Clear existing columns
            viewSession.Columns.Clear();
            // Add new columns
            viewSession.Columns.Add("Date/Time");
            viewSession.Columns.Add("SessionID");
            viewSession.Columns.Add("Host");
            viewSession.Columns.Add("User");
            // Set column widths
            viewSession.Columns[0].Width = 200;
            viewSession.Columns[1].Width = 200;
            viewSession.Columns[2].Width = 200;
            viewSession.Columns[2].Width = 200;

            viewSession.View = View.Details;
        }

        /*private void resetViewSession()
        {
            if (viewSession.InvokeRequired)
            {
                viewSession.Invoke(new MethodInvoker(delegate
                {
                    viewSession.Items.Clear();
                    foreach (var item in connectedClients)
                    {
                        FtpConnection conn = item.Value;
                        string[] success_log = { conn.StartTime.ToString(), conn.SessionID, conn.RemoteEndpoint, conn.Username };
                        addSession(success_log);
                    }

                }));
            }
            else
            {
                viewSession.Items.Clear();
                foreach (var item in connectedClients)
                {
                    FtpConnection conn = item.Value;
                    string[] success_log = { conn.StartTime.ToString(), conn.SessionID, conn.RemoteEndpoint, conn.Username };
                    addSession(success_log);
                }

            }
        }*/

        private void addLog(string[] row)
        {
            ListViewItem item = new ListViewItem(row);

            viewLog.Invoke(new MethodInvoker(delegate
            {
                viewLog.Items.Add(item);
                viewLog.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            }));
        }

        private void addSession(string[] row)
        {
            ListViewItem item = new ListViewItem(row);
            viewSession.Invoke((MethodInvoker)(() =>
            {
                viewSession.Items.Add(item);
                viewSession.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            }));

        }

        // End handle viewLog

        private void StartListening()
        {
            try
            {
                if (listener != null)
                {
                    listener.Stop();
                    listener = null;
                }
                listener = new TcpListener(System.Net.IPAddress.Parse(host), control_port);

                listener.Start(); // start listening

                label1.Text = "Started " + host + ":" + control_port;
                runServer = true;
                //create in log view
                CreateHeaders_viewLog();
                CreateHeaders_viewSession();
                listenThread = new Thread(new ThreadStart(AcceptConnections));
                listenThread.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error starting FTP server: " + ex.Message);
            }
        }
        private void AcceptConnections()
        {
            while (runServer)
            {
                try
                {
                    // Accept a new connection
                    TcpClient client = listener.AcceptTcpClient();
                    
                    //MessageBox.Show("2 " + client.ToString());
                    FtpConnection ftpConnection = new FtpConnection(client);
                    // Start a new thread to handle the connection
                    connectedClients.Add(ftpConnection.SessionID, ftpConnection); // add client to list
                    Thread clientThread = new Thread(new ParameterizedThreadStart(obj => HandleConnection((FtpConnection)obj)));
                    clientThread.Start(ftpConnection);
                }
                catch (Exception ex)
                {
                    if (!runServer)
                        break;
                    MessageBox.Show("Error accepting connection: " + ex.Message);
                }
            }
        }

        //
        // Stop listening - QANH
        //
        private void StopListening()
        {
            runServer = false;
            if (listener!=null)
            {
                listener.Stop();
            }
            // if have thread 
            if (listenThread!= null)
            {
                listenThread.Interrupt();
            }
            viewLog.Items.Clear();
            viewSession.Items.Clear();
            try
            {
                foreach (var kvp in connectedClients)
                {
                    FtpConnection connection = kvp.Value;
                    connection.Client.Close();
                }
                connectedClients.Clear();
                label1.Text = "Stopped " + host + ":" + control_port;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error stopping FTP server: " + ex.Message);
            }
        }

        private void HandleConnection(FtpConnection obj)
        {
            
            try
            {
                /*string hostName = Dns.GetHostName();
                // Chuỗi chào mừng
                string welcomeMessage = "Connected to" + Dns.GetHostEntry(hostName).HostName + "\r\n";
                // Chuyển chuỗi chào mừng thành mảng byte
                byte[] welcomeBytes = Encoding.UTF8.GetBytes(welcomeMessage);
               
                
                // Gửi chuỗi chào mừng đến client
                stream.Write(welcomeBytes, 0, welcomeBytes.Length);*/

                byte[] buffer = new byte[1024];
                int bytesRead;
                while (runServer && obj.Client.Connected)
                {
                    NetworkStream stream = obj.Client.GetStream();
                    bytesRead = 0;
                    try
                    {
                        bytesRead = stream.Read(buffer, 0, buffer.Length);
                    }
                    catch (IOException ex)
                    {
                        break;
                    }

                    if (bytesRead <= 0)
                    {
                        // Client has closed the connection
                        break;
                    }

                    string receivedData = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                    if (receivedData.StartsWith("REGISTER"))
                    {
                        receivedData = receivedData.Replace("\r\n", "").Replace("\n", "").Replace("\r", "");
                        handleRegister(stream, receivedData);
                    }
                    else if (receivedData.StartsWith("USER"))
                    {
                        receivedData = receivedData.Replace("\r\n", "").Replace("\n", "").Replace("\r", "");
                        handleUser(obj, receivedData);
                    }
                    else if (receivedData.StartsWith("LIST"))
                    {
                        handleList(obj, receivedData);
                    }
                    else if (receivedData.StartsWith("NLST"))
                    {
                        handleNLST(obj, receivedData);
                    }
                    else if (receivedData.StartsWith("SIZE"))
                    {
                        handleSize(obj, receivedData);
                    }
                    else if (receivedData.StartsWith("DSIZ"))
                    {
                        handleDsiz(obj, receivedData);
                    }
                    else if (receivedData.StartsWith("MKD"))
                    {
                        handleMKD(obj, receivedData);
                    }
                    else if (receivedData.StartsWith("RMD"))
                    {
                        handleRMD(obj, receivedData);
                    }
                    else if (receivedData.StartsWith("DELE"))
                    {
                        handleDELE(obj, receivedData);
                    }
                    else if (receivedData.StartsWith("QUIT"))
                    {
                        handleQuitClient(obj);
                    }
                    else if(receivedData.StartsWith("REIN")){
                        handleREIN(obj);
                    }
                    
                    else if (receivedData.StartsWith("RETR"))
                    {
                        handleRetrCommand(obj, receivedData);
                    }
                    else if (receivedData.StartsWith("STOR"))
                    {
                        handleStorCommand(obj, receivedData);
                    }
                    else if (receivedData.StartsWith("CWD")) // PHUONG 28/5
                    {
                        receivedData = receivedData.Replace("\r\n", "").Replace("\n", "").Replace("\r", "");
                        handleCwdCommand(obj, receivedData);
                    }
                    else if (receivedData.StartsWith("PWD"))
                    {
                        receivedData = receivedData.Replace("\r\n", "").Replace("\n", "").Replace("\r", "");
                        handlePwdCommand(obj, receivedData);
                    }
                    else if (receivedData.StartsWith("PORT"))
                    {
                        // Client tạo TcpListener
                        // Server tạo kết nối
                        // PHUONG
                        receivedData = receivedData.Replace("\r\n", "").Replace("\n", "").Replace("\r", "");
                        portCommandHandler(obj, receivedData);
                    }
                    else if (receivedData.StartsWith("PASV"))
                    {
                        // PHUONG
                        receivedData = receivedData.Replace("\r\n", "").Replace("\n", "").Replace("\r", "");
                        sendConnectionInformation(obj, receivedData);
                    }
                    else
                    {
                        MessageBox.Show("Command not found.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error handling connection: " + ex.Message);
            }
            finally
            {
                obj.Client.Close();
                removeConnect(obj);

            }

        }

        // Code phan data connection
        /**
         * Nhận command PASV -> Tạo IP và Port -> Mở kết nối (TcpListener (rieng)) -> Gui thong tin Ket noi 
         */

        // Ham start listen for data stream - PHUONG
        private void StartDataListening(object conn)
        {
            FtpConnection connection = (FtpConnection)conn;
            try
            {
                connection.DataListener.Start();
                connection.DataClient = connection.DataListener.AcceptTcpClient();
               

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error starting FTP server: " + ex.Message);
            }
        }

        // Ham convert tu IPEndpoint sang string - PHUONG
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

        // Convert tu string sang IPEndpoint - PHUONG
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


        // Tao ket noi den IP cua server dang lang nghe va random port - PHUONG
        private string createDataConnection(FtpConnection conn)
        {
            IPEndPoint localEndPoint = listener.LocalEndpoint as IPEndPoint;

            if (localEndPoint != null)
            {
                // Create data listener
                int freePort = PortFinder.GetRandomFreePort();
                conn.DataListener = new TcpListener(localEndPoint.Address, freePort);
                IPEndPoint dataLocalEndPoint = conn.DataListener.LocalEndpoint as IPEndPoint;
                if (dataLocalEndPoint != null)
                {
                    Thread dataConnectionThread = new Thread(StartDataListening);
                    dataConnectionThread.Start(conn);
                    return ConvertToString(dataLocalEndPoint);
                }
                else
                {
                    return string.Empty;
                }
            }
            else
            {
                Console.WriteLine("Unable to determine the local endpoint.");
                return string.Empty;
            }
        }

        // Gui thong tin ket noi doi voi PASV - PHUONG
        private void sendConnectionInformation(FtpConnection conn, string cmd)
        {

            //MessageBox.Show($"Receive {cmd}", "Server", MessageBoxButtons.OK, MessageBoxIcon.Information);
            // Add receive command
            time = getTime();
            string[] row = { time, this.type1, cmd };
            addLog(row);
            // End add receive command

            //TcpClient _client = (TcpClient)obj;
            //NetworkStream stream = (NetworkStream)obj_stream;
            NetworkStream stream = conn.Stream;
            try
            {

                byte[] buffer = new byte[1024];

                // Tao ket noi
                string ipAndPort = createDataConnection(conn);

                // Send response for user cmd

                string res = $"227 Entering Passive Mode ({ipAndPort})";
                byte[] response = Encoding.UTF8.GetBytes(res);
                stream.Write(response, 0, response.Length);

                // Add response log
                time = getTime();
                string[] res_log = { time, this.type2, res };
                addLog(res_log);

            }
            catch (Exception)
            {
                string res = $"500 Wrong command";
                byte[] response = Encoding.UTF8.GetBytes(res);
                stream.Write(response, 0, response.Length);
            }
        }

        // Code phần PORT
        // PHUONG
        private void portCommandHandler(FtpConnection conn, string cmd)
        {
            NetworkStream _stream = conn.Stream;
            try
            {
                time = getTime();
                string[] row = { time, this.type1, cmd };
                addLog(row);

                string connectionInformationStr = cmd.Trim().Split(' ')[^1];
                connectionInformationStr = connectionInformationStr.Replace("(", "").Replace(")", "");

                //MessageBox.Show(connectionInformationStr);

                IPEndPoint _remoteIpEndPoint = ConvertToConnectionInformation(connectionInformationStr);
                IPEndPoint _localIpEndPoint = new IPEndPoint(System.Net.IPAddress.Any, _remoteIpEndPoint.Port + 1); // Set mac dinh la port 20 - khong solve duoc multi client - hoac la phai luon mo port 20  // PHUONG

                TcpClient dataClient = new TcpClient(_localIpEndPoint);
                dataClient.ConnectAsync(_remoteIpEndPoint.Address, _remoteIpEndPoint.Port); // active 

                // Luu lai tcp client cua data connection
                conn.DataClient = dataClient;

                //MessageBox.Show("Connect ok");

                byte[] buffer = new byte[1024];
                // Send response for user cmd

                string res = $"200 PORT command successful";
                byte[] response = Encoding.UTF8.GetBytes(res);
                _stream.Write(response, 0, response.Length);

                // Add response log
                time = getTime();
                string[] res_log = { time, this.type2, res };
                addLog(res_log);

            }
            catch (Exception e)
            {
                string res = $"500 Wrong command";
                byte[] response = Encoding.UTF8.GetBytes(res);
                _stream.Write(response, 0, response.Length);

                // Add response log
                time = getTime();
                string[] res_log = { time, this.type2, res };
                addLog(res_log);
                //MessageBox.Show(e.ToString());
            }
        }
        // End code phan data connection

        public Account verifyUser(string username, string password)
        {
            var client = new MyMongoDBConnect().connection;
            var database = client.GetDatabase("users");
            var collection = database.GetCollection<BsonDocument>("account");
            // Xây dựng truy vấn
            var filter = Builders<BsonDocument>.Filter.Eq("username", username);
            // Thực hiện truy vấn
            var result = collection.Find(filter).FirstOrDefault();

            if (result != null)
            {
                if (BCrypt.Net.BCrypt.EnhancedVerify(password, result["passwd"].AsString))
                {

                    return new Account(result["username"].AsString, result["passwd"].AsString, result["role"].AsString, result["virtualpath"].AsString, result["location"].AsString);
                }
            }
            return null;
        }

        private void handleRegister(object obj, string command)
        {
            string[] myParams = command.Split(' ');

            NetworkStream stream = (NetworkStream)obj;
            byte[] buffer = new byte[1024];

            // Send response for user cmd
            byte[] response;

            if (myParams.Length > 2)
            {
                string username, passwd;
                username = myParams[1];
                passwd = myParams[2];
                try
                {
                    new ManageUsersForm(stream, username, passwd).ShowDialog();
                    response = Encoding.UTF8.GetBytes("200 Register successfully.");
                    stream.Write(response, 0, response.Length);
                }
                catch
                {
                    response = Encoding.UTF8.GetBytes("404 Register failed.");
                    stream.Write(response, 0, response.Length);
                };
            }
            else
            {
                response = Encoding.UTF8.GetBytes("xxx Please enter your username and password: REGISTER <username> <password>");
                stream.Write(response, 0, response.Length);
            }
        }

        /*
         Code QUANHH
         */
        // nhan request REIN -> ghi log -> xoa client khoi dir -> tạo mới conn -> add dir -> add log
        private void handleREIN(FtpConnection conn)
        {
            string time = getTime();
            string[] row = { time, type1, "REIN\r\n" };
            addLog(row);
            removeConnect(conn);
            removeViewSession(conn);
            try
            {
                bool check = conn.SignedIn;
                string username = conn.Username;
                FtpConnection newConn = new FtpConnection(conn.Client);
                newConn.SetUsername(username);
                string responseStr = "220 Service ready for new user.";
                byte[] response = Encoding.UTF8.GetBytes(responseStr + "\r\n");
                newConn.Stream.Write(response, 0, response.Length);

                time = getTime();
                string[] res_log = { time, "Response", responseStr };
                addLog(res_log);
                connectedClients.Add(newConn.SessionID, newConn);
                string[] session_log = { getTime(), newConn.SessionID, newConn.RemoteEndpoint, newConn.Username };
                addSession(session_log);

            }
            catch (Exception ex)
            {
                string[] res_log = { getTime(), "Error", ex.Message };
                addLog(res_log);
            }
        }
        private void handleQuitClient(FtpConnection conn)
        {
            string time = getTime();
            string[] row = { time, type1, "QUIT" };
            addLog(row);
            removeViewSession(conn);
            string goodbyeMessage = "221 Goodbye.\r\n";
            byte[] goodbyeBytes = Encoding.UTF8.GetBytes(goodbyeMessage);
            conn.Stream.Write(goodbyeBytes, 0, goodbyeBytes.Length);

            time = getTime();
            string[] res_log = { time, type2, goodbyeMessage };
            addLog(res_log);

            removeConnect(conn);
            conn.Client.Close();
        }
        private void removeConnect(FtpConnection obj)
        {
            if (connectedClients.ContainsKey(obj.SessionID))
            {
                connectedClients.Remove(obj.SessionID);
            }

        }
        private void removeViewSession(FtpConnection conn)
        {

            if (this.InvokeRequired)
            {
                this.Invoke(new Action<FtpConnection>(removeViewSession), new object[] { conn });
                return;
            }

            foreach (ListViewItem item in viewSession.Items)
            {

                if (item.SubItems[1].Text == conn.SessionID)
                {
                    viewSession.Items.Remove(item);
                    break;
                }
            }
        }

        // FIX
        // tu server ve client (download)
        private void SendResponse(FtpConnection conn, string message, string type)
        {
            byte[] response = Encoding.ASCII.GetBytes(message + "\r\n");
            conn.Stream.Write(response, 0, response.Length);
            // Log the response
            string[] log = { getTime(), type, message };
            addLog(log);
        }
        private void handleRetrCommand(FtpConnection conn, string cmd)
        {
            string[] row = { getTime(), type1, cmd };
            addLog(row);

            cmd = cmd.Trim();
            string fileName = cmd.Split(" ")[1];
           
            string currentDir = conn.CurrentDir.TrimStart('\\');
            // Kết hợp các đường dẫn lại
            string fullPath = Path.Combine(conn.Acc.location, currentDir, fileName);
            // Hiển thị đường dẫn kết hợp
           
            if (File.Exists(fullPath))
            {
                if (conn.DataClient == null)
                {
                    SendResponse(conn, "425 Can't open data connection.", type3);
                    return;
                }
                // Send 150 response to the client to indicate the start of file transfer
                SendResponse(conn, "150 Starting data transfer.", type2);
                try
                {
                    // Get the data client stream to transfer the file
                    using (NetworkStream dataStream = conn.DataClient.GetStream())
                    using (FileStream fileStream = new FileStream(fullPath, FileMode.Open, FileAccess.Read))
                    {
                        fileStream.CopyTo(dataStream);
                    }
                    // Send 226 response to indicate that the file transfer was successful
                    SendResponse(conn, "226 Operation successful.", type2);
                }
                catch (Exception ex)
                {
                    // Send error response if something goes wrong during file transfer
                    SendResponse(conn, "426 Connection closed; transfer aborted.", type3);
                    MessageBox.Show("Error during file transfer: " + ex.Message);
                }
                finally
                {
                    if (conn.DataClient != null)
                    {
                        conn.DataClient.Close();
                    }
                }
            }
            else
            {
                SendResponse(conn, "550 File not found.", type3);
            }
        }
        // tuwf client -> server
        private void handleStorCommand(FtpConnection conn, string cmd)
        {
            // Step 1: Nhận và phản hồi cho cmd
            string[] row = { getTime(), type1, cmd };
            addLog(row);

            cmd = cmd.Trim();
            string fileName = cmd.Split(" ")[1];

            // Remove invalid characters from fileName
            fileName = string.Concat(fileName.Split(Path.GetInvalidFileNameChars()));

            string currentDir = conn.CurrentDir.TrimStart('\\');
            string fullPath = Path.Combine(conn.Acc.location, currentDir, fileName);
            string directoryPath = Path.GetDirectoryName(fullPath);

            // Tạo thư mục nếu chưa tồn tại
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            // Hiển thị đường dẫn kết hợp
            //MessageBox.Show($"Full path: {fullPath}", "Debug");

            try
            {
                // Sử dụng FileStream với FileMode.Create để tạo hoặc ghi đè tệp
                using (FileStream fileStream = new FileStream(fullPath, FileMode.Create, FileAccess.Write))
                {
                    // Step 4: Gửi phản hồi 150 để chỉ ra rằng sẵn sàng nhận tệp
                    SendResponse(conn, "150 Opening data connection.", type2);

                    // Step 5: Nhận dữ liệu tệp từ client
                    using (NetworkStream dataStream = conn.DataClient.GetStream())
                    {
                        dataStream.CopyTo(fileStream);
                    }
                }

                // Step 6: Gửi phản hồi 226 để chỉ ra rằng quá trình truyền tệp đã hoàn tất
                SendResponse(conn, "226 Operation successful.", type2);
            }
            catch (Exception ex)
            {
                // Ghi lại lỗi và gửi phản hồi thất bại
                MessageBox.Show($"Error during file upload: {ex.Message}\n{ex.StackTrace}", "Error");
                SendResponse(conn, "426 Connection closed; transfer aborted.", type3);
            }
            finally
            {
                if (conn.DataClient != null)
                {
                    conn.DataClient.Close();
                }
            }
        }

        private string getTime()
        {
            DateTime utcNow = DateTime.UtcNow;
            DateTime localTime = utcNow.ToLocalTime();
            return localTime.ToString();
        }


        private void handleUser(FtpConnection conn, string cmd)
        {
            NetworkStream stream = conn.Stream;
            byte[] buffer = new byte[1024];
            // Get username after user cmd
            string username = cmd.Substring(5);
            time = getTime();
            string[] row = { time, this.type1, cmd };
            addLog(row);

            // Send response for user cmd
            string res = "331 Please, specify the password.";
            byte[] response = Encoding.UTF8.GetBytes(res);
            stream.Write(response, 0, response.Length);
            time = getTime();

            string[] res_log = { time, this.type2, res };
            addLog(res_log);

            // Receive password from client
            int bytesRead = stream.Read(buffer, 0, buffer.Length);
            password = Encoding.UTF8.GetString(buffer, 0, bytesRead);
            password = password.Replace("\r\n", "").Replace("\n", "").Replace("\r", "");

            time = getTime();
            string[] row2 = { time, type1, password };
            addLog(row2);

            // FIX response
            // Verify password
            Account ok = verifyUser(username, password.Substring(5));
            if (ok != null)
            {
                // Send response
                string mes = "230 Login successful";
                response = Encoding.UTF8.GetBytes(mes);
                stream.Write(response, 0, response.Length);
                time = getTime();
                string[] tmp_res = { time, type2, mes };
                addLog(tmp_res);
                conn.SetUsername(username);
                conn.SetSignedIn(true);
                conn.setAccount(ok);
                string[] success_log = { conn.StartTime.ToString(), conn.SessionID, conn.RemoteEndpoint, conn.Username };
                addSession(success_log);
            }
            else
            {
                // Send response
                response = Encoding.UTF8.GetBytes("530 Login incorrect.");
                stream.Write(response, 0, response.Length);
                time = getTime();
                string[] tmp_res = { time, type2, "530 Login incorrect." };
                addLog(tmp_res);
            }
        }

        // PHUONG 28/5
        private void handleCwdCommand(FtpConnection conn, string cmd)
        {
            // Fake session
            time = getTime();
            string[] tmp_res = { time, type1, cmd };
            addLog(tmp_res);

            NetworkStream stream = conn.Stream;
            string requiredPath = cmd.Replace("CWD ", "");
            // MessageBox.Show("req :" + requiredPath + ":");
            byte[] buffer = new byte[1024];
            byte[] response;
            // Location in server -> Get from Account
            string rootDirectory = conn.getRootDirectory(); // test chứ cái path này phải lấy trong database
                                                            // MessageBox.Show("ROOT : " + rootDirectory);
                                                            // Lấy path hiện tại
            string currentDirectory = conn.getCurrentDirectory();
            // MessageBox.Show("CUR : " + currentDirectory);
            // Tạo virtualpath
            string vPath;
            if (requiredPath == null || requiredPath == "")
            {
                // MessageBox.Show("ROOT : " + requiredPath);
                vPath = "\\";
                //vPath = Path.GetFullPath(requiredPath);// Lấy path chuẩn
            }
            else
            {
              
                vPath = requiredPath;
            }
            // MessageBox.Show("VPath " + vPath, "server");

            // Lấy local path
            // string fullPath = Path.GetFullPath(Path.Combine(rootDirectory, requiredPath.TrimStart(Path.DirectorySeparatorChar)));
            string fullPath = rootDirectory + requiredPath;
            // MessageBox.Show(fullPath, "Server");
            string responseStr;
            if (Directory.Exists(fullPath))
            {
                // Cần full path 
                conn.setCurrentDirectory(vPath);
                responseStr = "250 CWD command successful";

            }
            else
            {
                responseStr = "550 Couldn't open the file or directory";

            }
            response = Encoding.UTF8.GetBytes(responseStr);
            time = getTime();
            string[] tmp_res_2 = { time, this.type2, responseStr };
            addLog(tmp_res_2);
            stream.Write(response, 0, response.Length);
            // Send response for user cmd
        }
        private void handlePwdCommand(FtpConnection conn, string cmd)
        {
            // Get Client
            NetworkStream stream = conn.Stream;
            time = getTime();
            string[] tmp_res = { time, type1, cmd };
            addLog(tmp_res);

            // Check valid command
            byte[] response;


            if (cmd == "PWD")
            {
                response = Encoding.UTF8.GetBytes($"257 {conn.getCurrentDirectory()} is current directory");
              
            }
            else
            {
                response = Encoding.UTF8.GetBytes("500 Wrong command");
            }
            
            stream.Write(response, 0, response.Length);
            string responseStr = Encoding.UTF8.GetString(response);
            time = getTime();
            string[] tmp_res_2 = { time, type2, responseStr };
            addLog(tmp_res_2);
        }

        // Code Thuy merge 29/5

        private static readonly Dictionary<string, string> MimeTypes = new Dictionary<string, string>(StringComparer.InvariantCultureIgnoreCase)
        {
            { ".txt", "Text File" },
            { ".pdf", "PDF Document" },
            { ".doc", "Microsoft Word Document" },
            { ".docx", "Microsoft Word Document" },
            { ".xls", "Microsoft Excel Document" },
            { ".xlsx", "Microsoft Excel Document" },
            { ".jpg", "JPEG Image" },
            { ".jpeg", "JPEG Image" },
            { ".png", "PNG Image" },
            { ".gif", "GIF Image" },
            { ".html", "HTML Document" },
            { ".htm", "HTML Document" },
            { ".zip", "ZIP Archive" },
            { ".rar", "RAR Archive" },
            { ".ppt", "Microsoft PowerPoint Presentation" },
            // Thêm các phần mở rộng khác và loại tệp tương ứng nếu cần
        };
        private string GetFileType(string filePath)
        { // Lấy File Type dựa trên đường dẫn
            string extension = Path.GetExtension(filePath);
            if (MimeTypes.ContainsKey(extension))
            {
                return MimeTypes[extension];
            }
            return "File";
        }
        private void getFolderData(string directory, StringBuilder sb, int lenSuf)
        { // Lấy tất cả thư mục và tệp từ directory ghi vào sb, bỏ phần suffix với độ dài lenSuf
            // Thêm đường dẫn của thư mục hiện tại vào chuỗi
            
                foreach (string dir in Directory.GetDirectories(directory))
                {
                    string dirWithoutSuf = dir.Substring(lenSuf);
                    // Lấy thông tin directory
                    DirectoryInfo dirInfo = new DirectoryInfo(dir);
                    string lastModified = dirInfo.LastWriteTime.ToString("yyyy-MM-dd HH:mm:ss");

                    sb.AppendLine($"DIR:{dirWithoutSuf}\t-\tFile folder\t{lastModified}");
                }
           

            // Thêm tất cả các tệp trong thư mục hiện tại vào chuỗi
        
            foreach (string file in Directory.GetFiles(directory))
            {
                string fileWithoutSuf = file.Substring(lenSuf);
                FileInfo fileInfo = new FileInfo(file);
                string fileSize = fileInfo.Length.ToString();
                string lastModified = fileInfo.LastWriteTime.ToString("yyyy-MM-dd HH:mm:ss");
                string fileType = GetFileType(file);
                
                sb.AppendLine($"{fileWithoutSuf}\t{fileSize}\t{fileType}\t{lastModified}");
            }
            /*// Đệ quy để thêm tất cả các thư mục con vào chuỗi
            foreach (string subDirectory in Directory.GetDirectories(directory))
            {
                getFolderData(subDirectory, sb, lenSuf);
            }*/
        }
        private string getLocationDB(string username)
        { // Lấy location của user từ DB
            var client = new MyMongoDBConnect().connection;
            var database = client.GetDatabase("users");
            var collection = database.GetCollection<BsonDocument>("account");
            // Xây dựng truy vấn
            var filter = Builders<BsonDocument>.Filter.Eq("username", username);
            // Thực hiện truy vấn
            var result = collection.Find(filter).FirstOrDefault();

            if (result != null)
            {
                return result["location"].AsString;
            }
            return null;
        }
        private void handleList(FtpConnection conn, string cmd)
        { // Xử lý req LIST
          // addLog req
            time = getTime();
            string[] row = { time, this.type1, cmd };
            addLog(row);
            NetworkStream stream = conn.Stream;
            
            // Check stream
            if (stream == null)
            {
                return;
            }

            byte[] response;


            if (conn.DataClient == null)
            {
                response = Encoding.UTF8.GetBytes("425 Can't open data connection"); //425 Use PORT or PASV first.
                stream.WriteAsync(response, 0, response.Length).Wait();
                return;
            }
            else
            {
                response = Encoding.UTF8.GetBytes("150 Starting data transfer");
                stream.WriteAsync(response, 0, response.Length).Wait();
                // addLog req
                string[] res = { getTime(), this.type2, Encoding.UTF8.GetString(response)};
                addLog(res);

                NetworkStream dataStream = conn.DataClient.GetStream();
                string curLocate = conn.getRootDirectory();
                string currentPath = conn.getCurrentDirectory();
                //MessageBox.Show("VIR " + currentPath.ToString());
                //MessageBox.Show("LOC " + curLocate.ToString());
                curLocate += currentPath;
                if (currentPath != "\\" && currentPath != "/")
                {
                    curLocate += "\\";
                }
                int lenSuf = curLocate.Length;
                //MessageBox.Show(lenSuf.ToString());
                //MessageBox.Show("curlocalte " + curLocate);
                
                //Console.WriteLine("curLocate: {0}", curLocate);
                // Nối các đường dẫn tệp và thư muc vào sb
                StringBuilder sb = new StringBuilder();
                getFolderData(curLocate, sb, lenSuf);
                // Gửi res
                try
                {
                    string dataResponseStr = sb.ToString();
                    if (dataResponseStr == "")
                    {
                        dataResponseStr = "\n"; // 
                    }
                    //MessageBox.Show(dataResponseStr, "server");
                    byte[] dataResponse = Encoding.UTF8.GetBytes(dataResponseStr);
                    
                    dataStream.Write(dataResponse, 0, dataResponse.Length);

                    // Response gui thanh cong
                    string responseStr = "226 Operation successful";
                    response = Encoding.UTF8.GetBytes(responseStr);
                    stream.Write(response, 0, response.Length);
                    // addLog res
                    time = getTime();
                    string[] res_log = { time, this.type2, responseStr };
                    addLog(res_log);

                }
                catch (Exception ex)
                {
                    string responseStr = "426 Connection closed. transfer aborded.";
                    response = Encoding.UTF8.GetBytes(responseStr);
                    stream.Write(response, 0, response.Length);
                    time = getTime();
                    string[] res_log = { time, this.type2, responseStr };
                    addLog(res_log);
                    //MessageBox.Show(ex.Message);
                }
            }

        }
        private void handleNLST(FtpConnection conn, string cmd)
        { // Xử lý req NLST
   
            NetworkStream stream = conn.Stream;
            byte[] buffer = new byte[1024];
            // addLog req
            time = getTime();
            string[] row = { time, this.type1, cmd };
            addLog(row);
            // Lấy location root của user
            string curLocate = conn.getRootDirectory();
            if (cmd.Length > 5)
            { // Nếu cmd LIST có tham số path
                string remotePath = cmd.Substring(5);
                curLocate += "\\" + remotePath;
            }
            Console.WriteLine("curLocate: {0}", curLocate);
            StringBuilder sb = new StringBuilder();
            string[] files = Directory.GetFiles(curLocate);
            foreach (string file in files)
            {
                string fileName = Path.GetFileName(file);
                sb.Append(fileName);
            }
            // Lấy danh sách các thư mục con trong thư mục
            string[] subDirectories = Directory.GetDirectories(curLocate);
            foreach (string subDirectory in subDirectories)
            {
                string directoryName = $"DIR:{Path.GetFileName(subDirectory)}";
                sb.Append(directoryName);
            }
            // Gửi res
            string responseStr = sb.ToString();
            Console.WriteLine("response: {0}", responseStr);
            byte[] response = Encoding.UTF8.GetBytes(responseStr);
            stream.Write(response, 0, response.Length);
            // addLog res
            time = getTime();
            string[] res_log = { time, this.type2, responseStr };
            addLog(res_log);
        }
        private long getFileSize(string path)
        { // Lấy kích thước file theo đường dẫn
            try
            {
                FileInfo file = new FileInfo(path);
                long fileSize = file.Length;
                return fileSize;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error getting file size for {path}: {e.Message}");
                return 0;
            }
        }
        private void handleSize(FtpConnection conn, string cmd)
        {
            // Xử lý req SIZE
            NetworkStream stream = conn.Stream;
            byte[] buffer = new byte[1024];
            // addLog req
            time = getTime();
            string[] row = { time, this.type1, cmd };
            addLog(row);
            // Lấy location root của user
            string responseStr = "";
            string curLocate = conn.getRootDirectory();
            // Lấy filePath
            if (cmd.Length < 5)
            {
                responseStr = "501 Syntax error in parameters or arguments";
            }
            string filePath = curLocate + "\\" + cmd.Substring(5);
            if (File.Exists(filePath))
            {
                long fileSize = getFileSize(filePath);
                responseStr = $"213 {fileSize}";
            }
            else
            {
                responseStr = $"550 File {filePath} not found";
            }
            // Gửi res
            Console.WriteLine("response: {0}", responseStr);
            byte[] response = Encoding.UTF8.GetBytes(responseStr);
            stream.Write(response, 0, response.Length);
            // addLog res
            time = getTime();
            string[] res_log = { time, this.type2, responseStr };
            addLog(res_log);
        }

        private long getDirSize(string path)
        { // Lấy kích thước file theo đường dẫn
            try
            {
                long totalSize = 0;
                DirectoryInfo dirInfo = new DirectoryInfo(path);
                foreach (FileInfo file in dirInfo.GetFiles())
                { // Lấy tất cả kích thước các tệp
                    totalSize += file.Length;
                }
                foreach (DirectoryInfo subDir in dirInfo.GetDirectories())
                {
                    totalSize += getDirSize(subDir.FullName);
                }

                return totalSize;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error getting directory size for {path}: {e.Message}");
                return 0;
            }
        }

        private void handleDsiz(FtpConnection conn, string cmd)
        {
            // Xử lý req DSIZ
           
            NetworkStream stream = conn.Stream;
            byte[] buffer = new byte[1024];
            // addLog req
            time = getTime();
            string[] row = { time, this.type1, cmd };
            addLog(row);
            // Lấy location root của user
            string responseStr = "";
            string curLocate = conn.getRootDirectory();
            // Lấy dirPath
            if (cmd.Length < 5)
            {
                responseStr = "501 Syntax error in parameters or arguments";
            }
            string dirPath = curLocate + "\\" + cmd.Substring(5);
            if (Directory.Exists(dirPath))
            {
                long dirSize = getDirSize(dirPath);
                responseStr = $"213 {dirSize}";
            }
            else
            {
                responseStr = $"550 Directory {dirPath} not found";
            }
            // Gửi res
            Console.WriteLine("response: {0}", responseStr);
            byte[] response = Encoding.UTF8.GetBytes(responseStr);
            stream.Write(response, 0, response.Length);
            // addLog res
            time = getTime();
            string[] res_log = { time, this.type2, responseStr };
            addLog(res_log);
        }

        private void handleMKD(FtpConnection conn, string cmd)
        {// cmd format: MKD //pathFolder
            // Xử lý req MKD
            NetworkStream stream = conn.Stream;
            byte[] buffer = new byte[1024];
            // addLog req
            time = getTime();
            string[] row = { time, this.type1, cmd };
            addLog(row);
            // Lấy location root của user
            string curLocate = conn.getRootDirectory();
            string currentPath = conn.getCurrentDirectory();

            string folderPath = curLocate + currentPath + "\\" + cmd.Substring(4);
            //MessageBox.Show("Folder path :" + folderPath);
            // Tạo folderPath
            try
            {
                string responseStr = "";
                if (Directory.Exists(folderPath))
                {
                    responseStr = "550 Create directory operation failed.";
                }
                else
                {
                    Directory.CreateDirectory(folderPath);
                    responseStr = "257 New folder created";
                }

                // Gửi res
                Console.WriteLine("response: {0}", responseStr);
                byte[] response = Encoding.UTF8.GetBytes(responseStr);
                stream.Write(response, 0, response.Length);
                // addLog res
                time = getTime();
                string[] res_log = { time, this.type2, responseStr };
                addLog(res_log);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error creating folder: {ex.Message}");
            }
        }

        private void handleRMD(FtpConnection conn, string cmd)
        {// cmd format: RMD //pathFolder
            // Xử lý req RMD
            NetworkStream stream = conn.Stream;
            byte[] buffer = new byte[1024];
            // addLog req
            time = getTime();
            string[] row = { time, this.type1, cmd };
            addLog(row);
            // Lấy location root của user
            string curLocate = conn.getRootDirectory();
            string currentPath = conn.getCurrentDirectory();
            string folderPath = curLocate + currentPath + "\\" + cmd.Substring(4);
            // Xóa folderPath
            try
            {
                string responseStr = "";
                if (Directory.Exists(folderPath))
                {
                    Directory.Delete(folderPath, true);
                    responseStr = "250 Directory removed.";
                }
                else
                {
                    responseStr = "550 Directory not found.";
                }
                // Gửi res
                Console.WriteLine("response: {0}", responseStr);
                byte[] response = Encoding.UTF8.GetBytes(responseStr);
                stream.Write(response, 0, response.Length);
                // addLog res
                time = getTime();
                string[] res_log = { time, this.type2, responseStr };
                addLog(res_log);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting folder: {ex.Message}");
            }
        }

        private void handleDELE(FtpConnection conn, string cmd)
        {// cmd format: DELE //pathFile
         // Xử lý req DELE

            NetworkStream stream = conn.Stream;
            byte[] buffer = new byte[1024];
            // addLog req
            time = getTime();
            string[] row = { time, this.type1, cmd };
            addLog(row);
            // Lấy location root của user
            string curLocate = conn.getRootDirectory();
            string currentPath = conn.getCurrentDirectory();

            string filePath = curLocate + currentPath + "\\" + cmd.Substring(5);
            // Xóa folderPath
            try
            {
                string responseStr = "";
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                    responseStr = "250 File deleted.";
                }
                else
                {
                    responseStr = "550 File not found.";
                }
                // Gửi res
                Console.WriteLine("response: {0}", responseStr);
                byte[] response = Encoding.UTF8.GetBytes(responseStr);
                stream.Write(response, 0, response.Length);
                // addLog res
                time = getTime();
                string[] res_log = { time, this.type2, responseStr };
                addLog(res_log);
            
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting file: {ex.Message}");
            }
        }



        // Code phan data connection

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new ManageUsersForm().ShowDialog();
        }

        // restart lại server
        private void restartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StopListening();  // Ngừng server hiện tại
            StartListening(); // Bắt đầu lại server
        }

        // đóng server
        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StopListening();
            this.Close();
        }
        // bắt đầu lắng nghe
        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StartListening();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }
    }

    public class MyMongoDBConnect
    {
        //Demo connect link
        //const string connectionUri = "mongodb+srv://client:123@cluster0.mpy38sv.mongodb.net/?retryWrites=true&w=majority&appName=Cluster0";
        const string connectionUri = "mongodb+srv://22521168:TO82PIYRxNeYBd18@cluster0.x3ovogy.mongodb.net/?retryWrites=true&w=majority&appName=Cluster0";
        public MongoClient connection;
        public MyMongoDBConnect()
        {
            var settings = MongoClientSettings.FromConnectionString(connectionUri);
            // Set the ServerApi field of the settings object to set the version of the Stable API on the client
            settings.ServerApi = new ServerApi(ServerApiVersion.V1);
            // Create a new client and connect to the server
            this.connection = new MongoClient(settings);
            // Send a ping to confirm a successful connection
        }
    }


    public class Account
    {

        public ObjectId _id { get; set; }

        [BsonElement("username")]
        public string username { get; set; }
        [BsonElement("passwd")]
        public string passwd { get; set; }
        [BsonElement("role")]
        public string role { get; set; }
        [BsonElement("virtualpath")]
        public string virtualpath { get; set; }
        [BsonElement("location")]
        public string location { get; set; }
        public Account(string _username, string _passwd, string _role, string _virtualpath, string _location)
        {
            this.username = _username;
            this.passwd = _passwd;
            this.role = _role;
            this.virtualpath = _virtualpath;
            this.location = _location;
        }
    }


    // PHUONG
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

    public class FtpConnection
    {
        public TcpClient Client { get; private set; }
        public NetworkStream Stream { get; private set; }
        public string Username { get; set; }
        public string SessionID { get; private set; }
        public DateTime StartTime { get; private set; }
        public string RemoteEndpoint { get; private set; }
        public string CurrentDir { get; private set; }
        public Account Acc { get; private set; }
        public bool SignedIn { get; private set; }
        public TcpClient DataClient { get; set; }
        public TcpListener DataListener { get; set; }
        public FtpConnection(TcpClient client)
        {
            this.Client = client;
            this.Stream = client.GetStream();
            this.SessionID = GenerateSessionID();
            this.StartTime = DateTime.Now;
            this.RemoteEndpoint = client.Client.RemoteEndPoint.ToString();
            this.Username = "";
            this.CurrentDir = "\\";
            this.Acc = null;
            this.SignedIn = false;
            this.DataClient = null;
            this.DataListener = null;
        }
        public void SetUsername(string username)
        {
            this.Username = username;
        }

        public void SetSignedIn(bool signedIn)
        {
            this.SignedIn = signedIn;
        }
        public void ResetSession()
        {
            // Reset session-specific data
            SessionID = GenerateSessionID();
            Username = string.Empty;
            // Any other session-specific reset actions
        }
        public void setAccount(Account acc)
        {
            this.Acc = acc;
        }

        private string GenerateSessionID()
        {
            // Implementation to generate a unique session ID
            return Guid.NewGuid().ToString();
        }
        public string getCurrentDirectory()
        {
            return this.CurrentDir;
        }
        public void setCurrentDirectory(string currentDirectory)
        {
            this.CurrentDir = currentDirectory;
        }
        public string getRootDirectory()
        {
            return this.Acc.location;
        }

    }
}

