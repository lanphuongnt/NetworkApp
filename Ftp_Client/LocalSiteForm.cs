using Amazon.Util.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ftp_Client
{
    public partial class LocalSiteForm : Form
    {
        public event Func<object, string, Task> FileUploadRequested;

        public LocalSiteForm()
        {
            InitializeComponent();
            folderTreeView.MouseUp += FolderTreeView_MouseUp;
            folderTreeView.AfterCheck += FolderTreeView_AfterCheck;
            folderTreeView.CheckBoxes = true;
        }

        private void localPathTextBox_Leave(object sender, EventArgs e)
        {
            /*   folderDialog.Url = new Uri(localPathTextBox.Text);*/
        }

        private void localPathTextBox_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!string.IsNullOrEmpty(localPathTextBox.Text))
                {
                    // Display in file browser
                    fileBrowser.Url = new Uri(localPathTextBox.Text);
                }
                else
                {
                    fileBrowser.Url = null;
                }
                //   else
                // {
                //localPathTextBox.Text = fileBrowser.Url.ToString().Substring(8);
                //}

                /*folderDialog.Url = new Uri(localPathTextBox.Text);*/
            }
        }

        private void fileBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            localPathTextBox.Text = fileBrowser.Url.ToString().Substring(8);
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            if (fileBrowser.CanGoBack)
            {
                fileBrowser.GoBack();
            }
        }

        /// TREE FOLDER
        // Tree Drives
        public void CreateTreeView()
        {
            // Lấy danh sách các ổ đĩa
            DriveInfo[] drives = DriveInfo.GetDrives();

            // Thêm các ổ đĩa vào TreeView
            foreach (DriveInfo drive in drives)
            {
                TreeNode driveNode = new TreeNode(drive.Name);
                driveNode.Tag = drive.RootDirectory.FullName;
                folderTreeView.Nodes.Add(driveNode);

                // Thêm cấu trúc thư mục của từng ổ đĩa
                PopulateTreeView(new DirectoryInfo(drive.Name), driveNode);
            }

        }

        private void localPathTextBox_TextChanged(object sender, EventArgs e)
        {
            if (Directory.Exists(localPathTextBox.Text))
            {
                // update file browser
                fileBrowser.Url = new Uri(localPathTextBox.Text);
            }
        }

        static void PopulateTreeView(DirectoryInfo directoryInfo, TreeNode parentNode)
        {
            try
            {
                foreach (var directory in directoryInfo.GetDirectories())
                {
                    TreeNode directoryNode = new TreeNode(directory.Name);
                    directoryNode.Tag = directory.FullName;
                    directoryNode.Checked = false; // Thêm checkbox
                    parentNode.Nodes.Add(directoryNode);

                    //PopulateTreeView(directory, directoryNode);
                }

                foreach (var file in directoryInfo.GetFiles())
                {
                    TreeNode fileNode = new TreeNode(file.Name);
                    fileNode.Tag = file.FullName;
                    fileNode.Checked = false; // Thêm checkbox
                    parentNode.Nodes.Add(fileNode);
                }
            }
            catch (UnauthorizedAccessException)
            {
                // Skip the directory if access is denied
            }
        }

        private void LocalSiteForm_Load(object sender, EventArgs e)
        {
            CreateTreeView();
        }

        private void folderTreeView_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            // Retrieve the double clicked node
            TreeNode clickedNode = e.Node;

            string folderPath = clickedNode.Tag as string;
            // Check if the double clicked node is a directory
            if (Directory.Exists(folderPath))
            {
                // CD to this path
                localPathTextBox.Text = folderPath;

                // Clear selection before populating tree view
                ClearSelection();

                // Expand child
                DirectoryInfo directoryInfo = new DirectoryInfo(folderPath);
                PopulateTreeView(directoryInfo, clickedNode);
                clickedNode.Expand();
            }
        }
        private List<TreeNode> selectedNodes = new List<TreeNode>();

        private async void UploadMenuItem_Click(object sender, EventArgs e)
        {
            List<string> selectedFiles = new List<string>();

            foreach (TreeNode node in folderTreeView.Nodes)
            {
                selectedFiles.AddRange(GetCheckedFiles(node));
            }

            foreach (string filePath in selectedFiles)
            {
                await FileUploadRequested?.Invoke(this, filePath);
            }
        }

        private List<string> GetCheckedFiles(TreeNode parentNode)
        {
            List<string> selectedFiles = new List<string>();

            if (parentNode.Checked && parentNode.Tag is string filePath && File.Exists(filePath))
            {
                selectedFiles.Add(filePath);
            }

            foreach (TreeNode node in parentNode.Nodes)
            {
                selectedFiles.AddRange(GetCheckedFiles(node));
            }

            return selectedFiles;
        }

        private void ClearSelection()
        {
            foreach (TreeNode node in folderTreeView.Nodes)
            {
                ClearNodeSelection(node);
            }
        }

        private void ClearNodeSelection(TreeNode node)
        {
            node.Checked = false;
            foreach (TreeNode childNode in node.Nodes)
            {
                ClearNodeSelection(childNode);
            }
        }

        private void FolderTreeView_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (e.Action != TreeViewAction.Unknown)
            {
                if (e.Node.Checked)
                {
                    selectedNodes.Add(e.Node);
                }
                else
                {
                    selectedNodes.Remove(e.Node);
                }
            }
        }

        private void FolderTreeView_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                TreeNode node = folderTreeView.GetNodeAt(e.X, e.Y);
                if (node != null)
                {
                    folderTreeView.SelectedNode = node;
                    string selectedPath = node.FullPath;
                    if (File.Exists(selectedPath))
                    {
                        localFileMenuStrip.Show(folderTreeView, e.Location);
                    }
                }
            }
        }

    public string GetLocalPath()
        {
            return localPathTextBox.Text;
        }
    }
}
