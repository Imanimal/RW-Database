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
    public partial class insertBox : Form
    {
        public bool success;
        public List<string> insertData;
        List<MainForm.SqlColumn> sqlColumns;

        public insertBox(string nameTable, List<MainForm.SqlColumn> columns)
        {
            InitializeComponent();

            Text = nameTable + ": добавить запись";
            insertData = new List<string>();

            sqlColumns = columns;
            foreach (MainForm.SqlColumn currentColumn in sqlColumns)
            {
                if (currentColumn.name != "Id")
                    insertDataGridView.Columns.Add(currentColumn.name, currentColumn.name);
            }
            insertDataGridView.RowCount = 1;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < insertDataGridView.ColumnCount; i++)
            {
                insertData.Add(insertDataGridView.Rows[0].Cells[i].Value.ToString());
            }
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
