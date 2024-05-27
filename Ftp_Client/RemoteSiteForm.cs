using Amazon.Util.Internal;
using SharpCompress.Compressors.Xz;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Ftp_Client
{
    public partial class RemoteSiteForm : Form
    {
        public class FileDetail
        {
            public string Name { get; set; }
            public string Size { get; set; }
            public string Type { get; set; }
            public string LastModified { get; set; }
        }

        public RemoteSiteForm()
        {
            InitializeComponent();
            ImageList imageList = new ImageList();
            imageList.Images.Add("folder", Image.FromFile("D:\\folder.png"));
            imageList.Images.Add("file", Image.FromFile("D:\\file.png"));

            // Gán ImageList cho TreeView
            folderTreeRemote.ImageList = imageList;
        }

        public void updateContent(string response)
        {
            try
            {
                // Reset tree view
                folderTreeRemote.Nodes.Clear();
                // Tạo một đối tượng TreeNode đại diện cho drive node \
                TreeNode driveNode = new TreeNode("\\");
                // Thêm drive node vào cây
                folderTreeRemote.Nodes.Add(driveNode);

                // Tạo các node trong cây
                string[] lines = response.Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string line in lines)
                {
                    string[] fields = line.Split('\t');
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
                        // Nếu nó là một tệp
                        string[] parts = path.Split('\\');
                        TreeNode parentNode = driveNode;

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
                        TreeNode fileNode = parentNode.Nodes.Add(parts[^1], parts[^1]);
                        fileNode.Tag = new FileDetail
                        {
                            Name = parts[^1],
                            Size = size,
                            Type = type,
                            LastModified = date
                        };
                        fileNode.ImageKey = "file";
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception in UpdateContent: {ex.Message}");
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
            remotePathTextBox.Text = node.FullPath;
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
                    fileListView.Items.Add(item);
                }
            }
        }

        private void folderTreeRemote_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            // Lấy node đã được double click
            TreeNode clickedNode = e.Node;
            ShowFileListView(clickedNode);
        }

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

        private void RemoteSiteForm_Load(object sender, EventArgs e)
        {

        }
    }
}