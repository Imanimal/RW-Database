using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RW_Database
{
    public partial class deleteBox : Form
    {
        public bool success;
        public string deleteId;

        public deleteBox(string nameTable)
        {
            InitializeComponent();
            Text = nameTable + ": удалить запись";
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            deleteId = valueField.Text;
            success = true;
            Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            success = false;
            Close();
        }
    }
}
