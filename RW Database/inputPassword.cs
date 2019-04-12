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
    public partial class inputPassword : Form
    {
        string correctPassword;
        public bool success;

        public inputPassword()
        {
            InitializeComponent();
            success = false;
            correctPassword = "1";
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (passwordBox.Text == correctPassword)
            {
                success = true;
                Close();
            }
            else
            {
                falseLabel.Text = "Неверно";
                passwordBox.Text = "";
            }
        }

        private void inputPassword_Load(object sender, EventArgs e)
        {
            
        }
    }
}
