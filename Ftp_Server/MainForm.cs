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
        private void handleUser(object obj, object obj_stream, string cmd)
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

        }

        private void HandleConnection(object obj)
        {
            
            TcpClient client = (TcpClient)obj;
            try
            {
                string username_client, password_client; 
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
                        handleUser(client, stream, receivedData);
                    }
                    else if (receivedData.StartsWith("LIST"))
                    {

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

