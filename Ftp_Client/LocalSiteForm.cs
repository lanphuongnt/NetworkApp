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
        public LocalSiteForm()
        {
            InitializeComponent();
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
        public void PopulateTreeView(TreeView treeView, string folderPath)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(folderPath);

            if (!directoryInfo.Exists)
            {
                throw new DirectoryNotFoundException("Folder does not exist: " + folderPath);
            }

            TreeNode rootNode = new TreeNode(directoryInfo.Name);
            rootNode.Tag = directoryInfo.FullName;
            treeView.Nodes.Add(rootNode);

            //PopulateTreeView(directoryInfo, rootNode);
        }

        static void PopulateTreeView(DirectoryInfo directoryInfo, TreeNode parentNode)
        {
            try
            {
                foreach (var directory in directoryInfo.GetDirectories())
                {
                    TreeNode directoryNode = new TreeNode(directory.Name);
                    directoryNode.Tag = directory.FullName;
                    parentNode.Nodes.Add(directoryNode);

                    //PopulateTreeView(directory, directoryNode);
                }

                foreach (var file in directoryInfo.GetFiles())
                {
                    TreeNode fileNode = new TreeNode(file.Name);
                    fileNode.Tag = file.FullName;
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
                
                // Expand child
                DirectoryInfo directoryInfo = new DirectoryInfo(folderPath);
                PopulateTreeView(directoryInfo, clickedNode);
                clickedNode.Expand();
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
    }

}
