using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace Ftp_Server
{
    public partial class ConnectForm : Form
    {
        public string host { get; private set; }
        public int port { get; private set; }
        public string password { get; private set; }

        public ConnectForm()
        {
            InitializeComponent();
        }

        private void ok_Click(object sender, EventArgs e)
        {   try
            {
                port = int.Parse(this.Port.Text);
            } 
            catch
            {
                MessageBox.Show("Port không hợp lệ", "error");
                this.Close();
            }

            host = this.hostName.Text;
            password = this.Password.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();

        }

        private void cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
