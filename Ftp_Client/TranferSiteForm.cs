using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ftp_Client
{
    public partial class TranferSiteForm : Form
    {
        public TranferSiteForm()
        {
            InitializeComponent();
            CreateHeaders_clientLog();
        }
        private void CreateHeaders_clientLog()
        {
            // Clear existing columns
            clientLog.Columns.Clear();

            // Add new columns
            clientLog.Columns.Add("Type");
            clientLog.Columns.Add("Date/Time");
            clientLog.Columns.Add("Message");


            // Set column widths
            clientLog.Columns[0].Width = 200;
            clientLog.Columns[1].Width = 200;
            clientLog.Columns[2].Width = 500;

            clientLog.View = View.Details;
        }
        private string getTime()
        {
            DateTime utcNow = DateTime.UtcNow;
            DateTime localTime = utcNow.ToLocalTime();
            return localTime.ToString();
        }
        public void addItemLog(string noti, string message)
        {
            ListViewItem lvi = new ListViewItem(noti + ": ");
            lvi.SubItems.Add(getTime());
            lvi.SubItems.Add(message);
            this.clientLog.Items.Add(lvi);
            clientLog.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
        }
    }
}
