using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RW_Database
{
    public partial class formOpenPort : Form
    {
        public bool success;
        public int port;

        public formOpenPort()
        {
            InitializeComponent();
        }

        private void okBut_Click(object sender, EventArgs e)
        {
            port = int.Parse(portTextBox.Text);
            success = true;
            Close();
        }

        private void cancelBut_Click(object sender, EventArgs e)
        {
            success = false;
            Close();
        }
    }
}
