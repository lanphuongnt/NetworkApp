using Amazon.Util.Internal;
using SharpCompress.Common;
using SharpCompress.Compressors.Xz;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Ftp_Client
{
    public partial class RemoteSiteForm : Form
    {
        public RemoteSiteForm()
        {
            InitializeComponent();

            // Tạo ImageList cho folderTreeRemote
            ImageList imageList = new ImageList();
            //MessageBox.Show(Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, @"Images\folder.png"));
            imageList.Images.Add("folder", Image.FromFile(Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, @"Images\folder.png")));
            imageList.Images.Add("file", Image.FromFile(Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, @"Images\file.png")));
            folderTreeRemote.ImageList = imageList;
            TreeNode root = folderTreeRemote.Nodes[0];
            root.ImageKey = "folder";
        }

        public class FileDetail
        {
            public string Name { get; set; }
            public string Size { get; set; }
            public string Type { get; set; }
            public string LastModified { get; set; }
        }
        public static class FolderNameInputDialog
        { // Tạo InputDialog để nhập folderName khi New Folder
            public static string ShowDialog(string text, string caption, RemoteSiteForm form)
            {
                Form prompt = new Form()
                {
                    Width = 250,
                    Height = 150,
                    FormBorderStyle = FormBorderStyle.FixedDialog,
                    Text = caption,
                    StartPosition = FormStartPosition.CenterScreen
                };
                Label textLabel = new Label() { Left = 25, Top = 20, Text = text };
                TextBox folderNameBox = new TextBox() { Left = 25, Top = 50, Width = 200 };
                Button confirmation = new Button() { Text = "Ok", Left = 350, Width = 100, Top = 70, DialogResult = DialogResult.OK };

                // Thiết lập để xử lý khi nhấn Enter
                folderNameBox.KeyDown += (sender, e) => form.folderNameBox_KeyDown(sender, e, prompt);

                prompt.Controls.Add(textLabel);
                prompt.Controls.Add(folderNameBox);

                return prompt.ShowDialog() == DialogResult.OK ? folderNameBox.Text : "";
            }
        }
        // Load RemoteSiteForm từ MainForm
        public void updateContent(string response, TreeNode driveNode)
        {
            try
            {
                /*if (clear) {
                    folderTreeRemote.Nodes.Clear();
                }*/
                // Reset tree view
                // Tạo một đối tượng TreeNode đại diện cho drive node \
                //TreeNode driveNode = new TreeNode("\\");
                

                // Thêm drive node vào cây
                //folderTreeRemote.Nodes.Add(driveNode);

                // Tạo các node trong cây
                string[] lines = response.Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string line in lines)
                {
                    string[] fields = line.Split('\t');
                    if (fields.Length < 4) continue;

                    string path = fields[0];
                    string size = fields[1];
                    string type = fields[2];
                    string date = fields[3];

                    if (path.StartsWith("DIR:"))
                    {
                        
                        // Nếu là directory
                        string directoryPath = path.Substring("DIR:".Length);
                        if (string.IsNullOrEmpty(directoryPath)) continue;
                        string[] parts = directoryPath.Split('\\');
                        TreeNode parentNode = driveNode;

                        foreach (string part in parts)
                        {
                            if (parentNode.Nodes.ContainsKey(part))
                            {
                                // Kiểm tra xem parentNode.Nodes có chứa phần tử với khóa part hay không
                                parentNode = parentNode.Nodes[part];
                            }
                            else
                            {
                                // Nếu không có, tạo một nút mới và gán nó cho parentNode
                                parentNode = parentNode.Nodes.Add(part, part);
                                parentNode.Tag = new FileDetail
                                {
                                    Name = part,
                                    Size = size,
                                    Type = type,
                                    LastModified = date
                                };
                                parentNode.ImageKey = "folder";
                            }
                        }
                    }
                    else
                    {
                        //MessageBox.Show("RMS2");
                        // Nếu nó là một tệp
                        string[] parts = path.Split('\\');
                        TreeNode parentNode = driveNode;
                        //MessageBox.Show(parts.Length.ToString());
                        
                        for (int i = 0; i < parts.Length - 1; i++)
                        {
                            if (parentNode.Nodes.ContainsKey(parts[i]))
                            {
                                // Kiểm tra xem parentNode.Nodes có chứa phần tử với khóa parts[i] hay không
                                parentNode = parentNode.Nodes[parts[i]];
                            }
                            else
                            {
                                // Nếu không có, tạo một nút mới và gán nó cho parentNode
                                parentNode = parentNode.Nodes.Add(parts[i], parts[i]);
                            }
                        }
                        TreeNode fileNode;
                        if (parentNode.Nodes.ContainsKey(parts[^1]))
                        {
                            fileNode = parentNode.Nodes[parts[^1]];
                        }
                        else
                        {
                            fileNode = parentNode.Nodes.Add(parts[^1], parts[^1]);
                        }
                        //MessageBox.Show("RMS3");

                        fileNode.Tag = new FileDetail
                        {
                            Name = parts[^1],
                            Size = size,
                            Type = type,
                            LastModified = date
                        };
                        //MessageBox.Show("rms4");
                        fileNode.ImageKey = "file";
                        //MessageBox.Show("rms5");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Exception in UpdateContent: {ex.Message}");
            }
        }
        private void remotePathTextBox_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        { // Thay đổi path trong textBox -> thay đổi listView
            if (e.KeyCode == Keys.Enter)
            {
                string path = remotePathTextBox.Text;
                TreeNode node = FindNodeByPath(folderTreeRemote.Nodes, path);
                if (node != null)
                {
                    ShowFileListView(node);
                }
                else
                {
                    MessageBox.Show("Folder does not exist!");
                    remotePathTextBox.Text = "";
                }
            }
        }
        private void ShowFileListView(TreeNode node)
        { // Hiện listView các files
            //remotePathTextBox.Text = node.FullPath;
            fileListView.Items.Clear();
            fileListView.Columns.Clear();
            fileListView.View = View.Details;

            // Tạo các cột cho ListView
            fileListView.Columns.Add("Filename", 150, HorizontalAlignment.Left);
            fileListView.Columns.Add("Filesize", 70, HorizontalAlignment.Right);
            fileListView.Columns.Add("Filetype", 100, HorizontalAlignment.Left);
            fileListView.Columns.Add("Last Modified", 140, HorizontalAlignment.Left);

            foreach (TreeNode subNode in node.Nodes)
            {
                if (subNode.Tag is FileDetail detail)
                {
                    ListViewItem item = new ListViewItem(subNode.Text);
                    item.SubItems.Add(detail.Size.ToString()); // Đảm bảo rằng Size là chuỗi
                    item.SubItems.Add(detail.Type.ToString());
                    item.SubItems.Add(detail.LastModified.ToString()); // Đảm bảo rằng LastModified là chuỗi
                    item.Tag = detail;
                    fileListView.Items.Add(item);
                }
            }
        }

       /* public event EventHandler<string> CwdRequested;
        public event EventHandler<string> PwdRequested;*/
        /// GPT
        public delegate Task AddListNodeRequestedHandler(object sender, TreeNode e);
        public event AddListNodeRequestedHandler AddListNodeRequested;

        private async void folderTreeRemote_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            // Lấy node đã được double click
            TreeNode clickedNode = e.Node;
            //MessageBox.Show("Double click");
            if (clickedNode != null)
            {
                if (AddListNodeRequested != null)
                {
                    var invocationList = AddListNodeRequested.GetInvocationList();
                    foreach (var handler in invocationList)
                    {
                        await ((AddListNodeRequestedHandler)handler)(this, clickedNode);
                    }
                }

                ShowFileListView(clickedNode);
                clickedNode.EnsureVisible();
            }
        }

        // END GPT


        /* public event EventHandler<TreeNode> AddListNodeRequested;
         private async void folderTreeRemote_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
         {
             // Lấy node đã được double click
             TreeNode clickedNode = e.Node;
             MessageBox.Show("Double click");
             if (clickedNode != null)
             {
                 AddListNodeRequested?.Invoke(this, clickedNode);
                 *//*CwdRequested?.Invoke(this, nodeName);
                 PwdRequested?.Invoke(this, nodeName);*//*
                 ShowFileListView(clickedNode);
             }
         }*/

        private TreeNode FindNodeByPath(TreeNodeCollection nodes, string path)
        { // Tìm node trong cây theo đường dẫn
            foreach (TreeNode node in nodes)
            {
                if (node.FullPath.Equals(path, StringComparison.OrdinalIgnoreCase))
                {
                    return node; // Trả về node nếu đường dẫn khớp
                }

                // Duyệt qua các node con của node hiện tại nếu có
                TreeNode foundNode = FindNodeByPath(node.Nodes, path);
                if (foundNode != null)
                {
                    return foundNode; // Trả về node nếu tìm thấy ở các node con
                }
            }
            return null; // Trả về null nếu không tìm thấy node nào có đường dẫn khớp
        }
        // Tạo sự kiện click chuột phải vào fileListView
        private async void fileListView_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var point = fileListView.PointToClient(Cursor.Position);
                var item = fileListView.GetItemAt(point.X, point.Y);
                if (item != null && item.Tag is FileDetail detail)
                {
                    if (detail.Type.ToString() == "File folder")
                    {
                        folderMenuStrip.Show(fileListView, point);
                    }
                    else
                    {
                        fileMenuStrip.Show(fileListView, point);
                    }
                }
                else
                {
                    blankMenuStrip.Show(fileListView, point);
                }
            }
        }
        // Hiện InputDialog để nhập FolderName mới sau khi New folder
        private async void newFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string folderName = FolderNameInputDialog.ShowDialog("Enter the name:", "New Folder", this);
            // Sử dụng folderName để tạo thư mục mới
        }

        // Cập nhật xóa node
        public void deleteNode(string nodeName)
        {
            //MessageBox.Show("NodeName - "+nodeName);
            string path = remotePathTextBox.Text + "\\" + nodeName;
            //MessageBox.Show(path);
            if (!path.StartsWith("\\\\") && !path.EndsWith('/'))
            {
                path = "\\" + path;
            }
            //MessageBox.Show("DELE " + path);
            TreeNode node = FindNodeByPath(folderTreeRemote.Nodes, path);
            TreeNode parentNode = node.Parent;
            node.Remove();
            //MessageBox.Show($"Node with path {path} has been deleted from TreeView.");
            parentNode.EnsureVisible();
            ShowFileListView(parentNode);
        }
        // Cập nhật tạo node
        public void createNode(string folderName)
        {
            string path = remotePathTextBox.Text;
            if (path != "\\" && path != "/")
            {
                path = "\\" + path;
            }
            //MessageBox.Show(path);
            TreeNode parentNode = FindNodeByPath(folderTreeRemote.Nodes, path);
            TreeNode node = parentNode.Nodes.Add(folderName, folderName);
            node.Tag = new FileDetail
            {
                Name = folderName,
                Size = "-",
                Type = "File folder",
                LastModified = "-"
            };
            //MessageBox.Show($"Node with path {path} has been created from TreeView.");
            parentNode.ExpandAll();
            ShowFileListView(parentNode);
        }
        // Sự kiện nhấn enter sau khi nhập folder name
        public event EventHandler<string> MkdRequested;
        public void folderNameBox_KeyDown(object sender, KeyEventArgs e, Form prompt)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string path = remotePathTextBox.Text;
                TextBox folderNameBox = sender as TextBox;
                // Kích hoạt sự kiện MkdRequested
                MkdRequested?.Invoke(this, folderNameBox.Text);

                prompt.DialogResult = DialogResult.OK;
                prompt.Close();
            }
        }

        public event EventHandler<string> DeleRequested;
        private async void deleteFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fileListView.SelectedItems.Count > 0)
            {
                string fileName = fileListView.SelectedItems[0].Text;
                //MessageBox.Show($"DELE {fileName}");
                DeleRequested?.Invoke(this, fileName);
            }
        }
        public event EventHandler<string> RmdRequested;
        private async void deleteFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fileListView.SelectedItems.Count > 0)
            {
                string folderName = fileListView.SelectedItems[0].Text;
                //MessageBox.Show($"RMD {folderName}");
                RmdRequested?.Invoke(this, folderName);
            }
        }
        public event Func<object, string, Task> DownloadRequested;

        /*private async void downloadFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fileListView.SelectedItems.Count > 0)
            {
                string fileName = fileListView.SelectedItems[0].Text;
                //MessageBox.Show($"RETR {fileName}");
                DownloadRequested?.Invoke(this, fileName);
            }
        }*/
        private async Task  downloadFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fileListView.SelectedItems.Count > 0)
            {
                foreach (ListViewItem selectedItem in fileListView.SelectedItems)
                {
                    string fileName = selectedItem.Text;
                    // Gọi sự kiện DownloadRequested cho mỗi tệp được chọn
                    await DownloadRequested.Invoke(this, fileName);
                }
            }
        }

    }
}