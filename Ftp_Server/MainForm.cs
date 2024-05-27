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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Xml.Linq;
using SharpCompress.Writers;
using SharpCompress.Compressors.Xz;
using SharpCompress.Common;

namespace Ftp_Server
{
    public partial class MainForm : Form
    {
        private string host;
        private int port;
        private string password;

        private int control_port = 21; // phải đảm bảo port này đang trống 
        private TcpListener listener;
        private Thread listenThread;

        private string type1 = "Request";
        private string type2 = "Response";
        private string time;
        public MainForm()
        {
            InitializeComponent();
        }

        private void connection_Click(object sender, EventArgs e)
        {
            using (var connectionForm = new ConnectForm())
            {
                if (connectionForm.ShowDialog() == DialogResult.OK)
                {   
                    host = connectionForm.host;
                    port = connectionForm.port;
                    password = connectionForm.password;
                    StartListening();
                }
                else
                {
                    MessageBox.Show("Can't connect and listening, try again.", "Error");
                }
            }
        }
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

        private void StartListening()
        {
            try
            {
                listener = new TcpListener(System.Net.IPAddress.Parse("0.0.0.0"), control_port);
                listener.Start();

                MessageBox.Show("FTP server started listening on port " + control_port);
                connection.Visible = false;
                
                label1.Text = "Connected to " + host;
                CreateHeaders_viewLog();
                CreateHeaders_viewSession();
                //AcceptConnections();
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
            bool runServer = true;
            while (runServer) 
            {
                try
                {
                    TcpClient client = listener.AcceptTcpClient();
                    // Start a new thread to handle the connection
                    Thread clientThread = new Thread(new ParameterizedThreadStart(HandleConnection));
                    clientThread.Start(client);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error accepting connection: " + ex.Message);
                }
            }
        }
        public bool verifyUser(string username, string password)
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
                   
                    return true;
                }
               

            }
            return false;
        }
        /*
            REGISTER <username> <password>
         */


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
                    response = Encoding.ASCII.GetBytes("200 Register successfully.");
                    stream.Write(response, 0, response.Length);
                }
                catch
                {
                    response = Encoding.ASCII.GetBytes("404 Register failed.");
                    stream.Write(response, 0, response.Length);
                };
            }
            else
            {
                response = Encoding.ASCII.GetBytes("xxx Please enter your username and password: REGISTER <username> <password>");
                stream.Write(response, 0, response.Length);
            }
        }

        private string getTime()
        {
            DateTime utcNow = DateTime.UtcNow;
            DateTime localTime = utcNow.ToLocalTime();
            return localTime.ToString();
        }
       
        private void addLog( string[] row)
        {
            ListViewItem item = new ListViewItem(row);
            if(viewLog.InvokeRequired)
            {
                viewLog.Invoke(new MethodInvoker(delegate
                {
                    viewLog.Items.Add(item);
                }));
            }
            else
            {
                viewLog.Items.Add(item);
            }
            viewLog.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
        }
        private void addSession(string[] row)
        {
            ListViewItem item = new ListViewItem(row);
            if (viewLog.InvokeRequired)
            {
                viewSession.Invoke(new MethodInvoker(delegate
                {
                    viewSession.Items.Add(item);
                }));
            }
            else
            {
                viewSession.Items.Add(item);
            }
            viewSession.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
        }
        private string handleUser(object obj, object obj_stream, string cmd)
        {
            TcpClient client = (TcpClient)obj;
            NetworkStream stream = (NetworkStream)obj_stream;

            byte[] buffer = new byte[1024];

            // Get username after user cmd
            string username = cmd.Substring(5);

            time = getTime();
            string[] row = { time, this.type1, cmd };
            addLog(row);

            

            // Send response for user cmd
            string res = "331 Please enter your password. Password: ";
            byte[] response = Encoding.ASCII.GetBytes(res);
            stream.Write(response, 0, response.Length);
            time = getTime();
            
            string[] res_log = { time, this.type2, res };
            addLog(res_log);

            // Receive password from client
            int bytesRead = stream.Read(buffer, 0, buffer.Length);
            password = Encoding.ASCII.GetString(buffer, 0, bytesRead);
            
            time = getTime();
            string[] row2 = { time, type1, password};
            addLog( row2);
          
            // Verify password
            bool ok = verifyUser(username, password.Substring(5));

            if (ok)
            {
                // Send response
                response = Encoding.ASCII.GetBytes("230 You are logged in.");
                stream.Write(response, 0, response.Length);
                time = getTime();
                string[] tmp_res = { time, type2, "230 You are logged in." };
                addLog(tmp_res);
                string sessionID = Guid.NewGuid().ToString();
                string[] success_log = { time, sessionID, client.Client.RemoteEndPoint.ToString(), username };
                addSession(success_log);
            }
            else
            {
                // Send response
                response = Encoding.ASCII.GetBytes("530 Login incorrect.");
                stream.Write(response, 0, response.Length);
                time = getTime();
                string[] tmp_res = { time, type2, "530 Login incorrect." };
                addLog(tmp_res);

            }
            return username; // Trả về username
        }
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
        private void getFolderData (string directory, StringBuilder sb, int lenSuf)
        { // Lấy tất cả thư mục và tệp từ directory ghi vào sb, bỏ phần suffix với độ dài lenSuf
            // Thêm đường dẫn của thư mục hiện tại vào chuỗi
            if (directory.Length > lenSuf)
            {
                string dirWithoutSuf = directory.Substring(lenSuf);
                // Lấy thông tin directory
                DirectoryInfo dirInfo = new DirectoryInfo(directory);
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
            // Đệ quy để thêm tất cả các thư mục con vào chuỗi
            foreach (string subDirectory in Directory.GetDirectories(directory))
            {
                getFolderData(subDirectory, sb, lenSuf);
            }
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
        private void handleList(object obj, object obj_stream, string cmd, string username)
        { // Xử lý req LIST
            TcpClient client = (TcpClient)obj;
            NetworkStream stream = (NetworkStream)obj_stream;
            byte[] buffer = new byte[1024];
            // addLog req
            time = getTime();
            string[] row = { time, this.type1, cmd };
            addLog(row);
            // Lấy location root của user
            string curLocate = getLocationDB(username);
            int lenSuf = curLocate.Length + 1;
            if (cmd.Length > 5)
            { // Nếu cmd LIST có tham số path
                string remotePath = cmd.Substring(5);
                curLocate += "\\" + remotePath;
            }
            Console.WriteLine("curLocate: {0}", curLocate);
            // Nối các đường dẫn tệp và thư muc vào sb
            StringBuilder sb = new StringBuilder();
            getFolderData(curLocate, sb, lenSuf);
            // Gửi res
            string responseStr = sb.ToString();
            Console.WriteLine("response: {0}", responseStr);
            byte[] response = Encoding.ASCII.GetBytes(responseStr);
            stream.Write(response, 0, response.Length);
            // addLog res
            time = getTime();
            string[] res_log = { time, this.type2, responseStr };
            addLog(res_log);
        }
        private void handleNLST(object obj, object obj_stream, string cmd, string username)
        { // Xử lý req NLST
            TcpClient client = (TcpClient)obj;
            NetworkStream stream = (NetworkStream)obj_stream;
            byte[] buffer = new byte[1024];
            // addLog req
            time = getTime();
            string[] row = { time, this.type1, cmd };
            addLog(row);
            // Lấy location root của user
            string curLocate = getLocationDB(username);
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
            byte[] response = Encoding.ASCII.GetBytes(responseStr);
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
        private void handleSize(object obj, object obj_stream, string cmd, string username)
        {
            // Xử lý req SIZE
            TcpClient client = (TcpClient)obj;
            NetworkStream stream = (NetworkStream)obj_stream;
            byte[] buffer = new byte[1024];
            // addLog req
            time = getTime();
            string[] row = { time, this.type1, cmd };
            addLog(row);
            // Lấy location root của user
            string responseStr = "";
            string curLocate = getLocationDB(username);
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
            byte[] response = Encoding.ASCII.GetBytes(responseStr);
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
        private void handleDsiz(object obj, object obj_stream, string cmd, string username)
        {
            // Xử lý req DSIZ
            TcpClient client = (TcpClient)obj;
            NetworkStream stream = (NetworkStream)obj_stream;
            byte[] buffer = new byte[1024];
            // addLog req
            time = getTime();
            string[] row = { time, this.type1, cmd };
            addLog(row);
            // Lấy location root của user
            string responseStr = "";
            string curLocate = getLocationDB(username);
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
            byte[] response = Encoding.ASCII.GetBytes(responseStr);
            stream.Write(response, 0, response.Length);
            // addLog res
            time = getTime();
            string[] res_log = { time, this.type2, responseStr };
            addLog(res_log);
        }
        private void HandleConnection(object obj)
        {
            
            TcpClient client = (TcpClient)obj;
            try
            {
                string username_client = "", password_client; 
                // Lấy dữ liệu luồng mạng của client
                NetworkStream stream = client.GetStream();
                host = Dns.GetHostName();
                
                // Chuỗi chào mừng
                string welcomeMessage = "Connected to" + Dns.GetHostByName(host).AddressList[0].ToString()+  "\r\n";

                // Chuyển chuỗi chào mừng thành mảng byte
                byte[] welcomeBytes = Encoding.ASCII.GetBytes(welcomeMessage);

                // Gửi chuỗi chào mừng đến client
                stream.Write(welcomeBytes, 0, welcomeBytes.Length);

                byte[] buffer = new byte[1024];
                int bytesRead;
                while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    // Xử lý dữ liệu đọc được từ client ở đây
                    
                    string receivedData = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                    if (receivedData.StartsWith("REGISTER"))
                    {
                        handleRegister(stream, receivedData);
                    }
                    else if (receivedData.StartsWith("USER"))
                    {
                        username_client = handleUser(client, stream, receivedData);
                    }
                    else if (receivedData.StartsWith("LIST"))
                    {
                        handleList(client, stream, receivedData, username_client);
                    }
                    else if (receivedData.StartsWith("NLST"))
                    {
                        handleNLST(client, stream, receivedData, username_client);
                    }
                    else if (receivedData.StartsWith("SIZE"))
                    {
                        handleSize(client, stream, receivedData, username_client);
                    }
                    else if (receivedData.StartsWith("DSIZ"))
                    {
                        handleDsiz(client, stream, receivedData, username_client);
                    }
                    else if (receivedData.StartsWith("QUIT"))
                    {

                    }
                    else if (receivedData.StartsWith("GET"))
                    {

                    }
                    else if (receivedData.StartsWith("PUT"))
                    {

                    }
                    else if (receivedData.StartsWith("CD"))
                    {

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
                client.Close();
            }
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new ManageUsersForm().ShowDialog();
        }

        private void disconnectToolStripMenuItem_Click(object sender, EventArgs e)
        {
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
}

