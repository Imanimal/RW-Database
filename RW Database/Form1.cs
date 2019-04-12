using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RW_Database
{
    public partial class MainForm : Form
    {
        // -----------------------------------------------------------------------------------------------
        // Подключения и работа с БД SQL
        // -----------------------------------------------------------------------------------------------
        SqlConnection sqlConnection;
        SqlConnectionStringBuilder sqlConnectionParam;
        SqlCommand sqlCommand;
        SqlDataReader sqlRead;
        bool successOpenDb;

        // -----------------------------------------------------------------------------------------------
        // Протокол UDP
        // -----------------------------------------------------------------------------------------------
        string serverIpAddress;
        int serverPort, thisPort;
        bool isNetwork, changeThisPort;

        string recMessage;
        string[] receiveMessage;

        Thread receiveThreadUDP;

        // -----------------------------------------------------------------------------------------------
        // База данных
        // -----------------------------------------------------------------------------------------------
        string openNameDatabase;

        public struct SqlTable
        {
            public int id;
            public string name;
        }
        public struct SqlColumn
        {
            public string name;
            public int user_type_id;
        }

        string openNameTable;

        List<SqlTable> sqlTables;
        List<SqlColumn> sqlColumns;
        List<string> sqlDataTable;
        
        // -----------------------------------------------------------------------------------------------
        // Нижнее меню статуса
        // -----------------------------------------------------------------------------------------------
        enum ModeOpen
        {
            none = 0,
            read,
            write
        }
        enum ModeOpenConnection
        {
            none = 0,
            local,
            server
        }
        
        ModeOpen modeOpen;
        ModeOpenConnection modeOpenConnection;
       
        // -----------------------------------------------------------------------------------------------
        // Методы Главной формы: создание, загрузка, закрытие
        // -----------------------------------------------------------------------------------------------
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            tablesToolStripMenuItem.DropDownItemClicked += OpenTable;

            sqlConnection = new SqlConnection();
            sqlConnectionParam = new SqlConnectionStringBuilder();
            sqlConnectionParam.DataSource = @"(LocalDB)\MSSQLLocalDB";
            sqlConnectionParam.IntegratedSecurity = true;
            sqlConnectionParam.Pooling = false;
            sqlCommand = new SqlCommand();
            
            successOpenDb = false;

            isNetwork = false;
            changeThisPort = false;
            thisPort = 8080;

            SetStatus(ModeOpen.none, ModeOpenConnection.none);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            changeThisPort = true;
            Thread.Sleep(1000);
            if (receiveThreadUDP.IsAlive)
                receiveThreadUDP.Abort();
            sqlConnection.Close();
        }

        // -----------------------------------------------------------------------------------------------
        // Методы установки нижнего меню статуса
        // -----------------------------------------------------------------------------------------------
        void SetStatus(ModeOpen modeOpenRW)
        {
            switch (modeOpenRW)
            {
                case ModeOpen.none:
                    actionToolStripMenuItem.Enabled = false;
                    modeOpen = ModeOpen.none;
                    statusModeOpenLabelMenu.Text = "-";
                    break;
                case ModeOpen.read:
                    insertActionToolStripMenuItem.Enabled = false;
                    deleteActionToolStripMenuItem.Enabled = false;
                    modeOpen = ModeOpen.read;
                    statusModeOpenLabelMenu.Text = "Режим чтения";
                    break;
                case ModeOpen.write:
                    insertActionToolStripMenuItem.Enabled = true;
                    deleteActionToolStripMenuItem.Enabled = true;
                    modeOpen = ModeOpen.write;
                    statusModeOpenLabelMenu.Text = "Режим записи";
                    break;
            }
        }

        void SetStatus(ModeOpenConnection modeOpenConnectionRW)
        {
            switch (modeOpenConnectionRW)
            {
                case ModeOpenConnection.none:
                    tablesToolStripMenuItem.Enabled = false;
                    modeOpenConnection = ModeOpenConnection.none;
                    statusModeOpenConnectionLabelMenu.Text = "Соединение не установлено";
                    break;
                case ModeOpenConnection.local:
                    tablesToolStripMenuItem.Enabled = true;
                    modeOpenConnection = ModeOpenConnection.local;
                    statusModeOpenConnectionLabelMenu.Text = "Локальное соединение";
                    break;
                case ModeOpenConnection.server:
                    tablesToolStripMenuItem.Enabled = true;
                    modeOpenConnection = ModeOpenConnection.server;
                    statusModeOpenConnectionLabelMenu.Text = "Подключён к серверу";
                    break;
            }
        }

        void SetStatus(ModeOpen modeOpenRW, ModeOpenConnection modeOpenConnectionRW)
        {
            SetStatus(modeOpenRW);
            SetStatus(modeOpenConnectionRW);
        }

        // -----------------------------------------------------------------------------------------------
        // Методы подключения
        // -----------------------------------------------------------------------------------------------

        // Локально - Режим чтения
        private void OpenDatabaseLocalModeReadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            selectDbOpenFileDialog.ShowDialog();
            if (successOpenDb)
            {
                successOpenDb = false;
                SetStatus(ModeOpen.read, ModeOpenConnection.local);
                Text = "RW Database: " + openNameDatabase;
            }
        }

        // Локально - Режим записи
        private void OpenDatabaseLocalModeWriteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            inputPassword inputPassword = new inputPassword();
            inputPassword.ShowDialog();
            if (inputPassword.success)
            {
                selectDbOpenFileDialog.ShowDialog();
                if (successOpenDb)
                {
                    successOpenDb = false;
                    SetStatus(ModeOpen.write, ModeOpenConnection.local);
                    Text = "RW Database: " + openNameDatabase;
                }
            }
        }

        // К серверу - Режим чтения
        private void OpenDatabaseServerModeReadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormConnection formConnectionServer = new FormConnection();
            formConnectionServer.ShowDialog();
            if (formConnectionServer.success)
            {
                SendMessageUDP(formConnectionServer.ip, formConnectionServer.port, thisPort.ToString() + ":;Are u server?");
                for (int i = 0; i < 50; i++)
                {
                    if (isNetwork)
                    {
                        serverIpAddress = formConnectionServer.ip;
                        serverPort = formConnectionServer.port;

                        InitTablesOptionMenu();

                        Text = "RW Database: " + openNameDatabase;
                        SetStatus(ModeOpen.read, ModeOpenConnection.server);
                        break;
                    }
                    Thread.Sleep(100);
                }

                if (!isNetwork)
                {
                    MessageBox.Show("Не удаётся подключиться.");
                }
            }
        }

        // К серверу - Режим записи
        private void OpenDatabaseServerModeWriteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            inputPassword inputPassword = new inputPassword();
            inputPassword.ShowDialog();
            if (inputPassword.success)
            {
                FormConnection formConnectionServer = new FormConnection();
                formConnectionServer.ShowDialog();
                if (formConnectionServer.success)
                {
                    SendMessageUDP(formConnectionServer.ip, formConnectionServer.port, thisPort.ToString() + ":;Are u server?");
                    for (int i = 0; i < 50; i++)
                    {
                        if (isNetwork)
                        {
                            serverIpAddress = formConnectionServer.ip;
                            serverPort = formConnectionServer.port;

                            InitTablesOptionMenu();

                            Text = "RW Database: " + openNameDatabase;
                            SetStatus(ModeOpen.write, ModeOpenConnection.server);
                            break;
                        }
                        Thread.Sleep(100);
                    }

                    if (!isNetwork)
                    {
                        MessageBox.Show("Не удаётся подключиться.");
                    }
                }
            }
        }
        
        // Отключиться
        private void unconnectedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridViewTableDb.Rows.Clear();
            dataGridViewTableDb.Columns.Clear();

            sqlConnection.Close();

            openNameDatabase = "";
            Text = "RW Database";

            openNameTable = "";
            sqlTables = null;
            sqlColumns = null;
            sqlDataTable = null;

            SetStatus(ModeOpen.none, ModeOpenConnection.none);
        }

        // Нажали ОК в окне диалога выбора файла БД
        private void selectDbOpenFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            try
            {
                sqlConnectionParam.AttachDBFilename = selectDbOpenFileDialog.FileName;
                sqlConnection.ConnectionString = sqlConnectionParam.ConnectionString;
                sqlConnection.Open();

                sqlCommand.Connection = sqlConnection;

                GetTables();

                InitTablesOptionMenu();

                openNameDatabase = Path.GetFileNameWithoutExtension(selectDbOpenFileDialog.FileName);
                successOpenDb = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Добавить список таблиц БД в меню
        void InitTablesOptionMenu()
        {
            ToolStripDropDown listTables = new ToolStripDropDown();
            foreach (SqlTable currentTable in sqlTables)
            {
                listTables.Items.Add(currentTable.name);
            }
            tablesToolStripMenuItem.DropDown = listTables;
        }

        // -----------------------------------------------------------------------------------------------
        // Методы работы с таблицами
        // -----------------------------------------------------------------------------------------------
        void OpenTable(object sender, ToolStripItemClickedEventArgs e)
        {
            openNameTable = e.ClickedItem.Text;
            if (modeOpenConnection == ModeOpenConnection.local)
            {
                GetSelectTable(openNameTable);
            }
            else
            {
                SendMessageUDP(serverIpAddress, serverPort, thisPort.ToString() + ":;GiveTable:;" + openNameTable);
                Thread.Sleep(500);
            }

            OpenSelectTable();
            Text = "RW Database: " + openNameDatabase + " - " + openNameTable;
            actionToolStripMenuItem.Enabled = true;
        }
        
        void OpenSelectTable()
        {
            dataGridViewTableDb.Rows.Clear();
            dataGridViewTableDb.Columns.Clear();

            foreach (SqlColumn currentColumn in sqlColumns)
            {
                dataGridViewTableDb.Columns.Add(currentColumn.name, currentColumn.name);
            }

            string[] row = new string[sqlColumns.Count];
            int i = 0;
            foreach (string currentItem in sqlDataTable)
            {
                if (i < dataGridViewTableDb.ColumnCount)
                {
                    row[i] = currentItem;
                    i++;
                    if (i == dataGridViewTableDb.ColumnCount)
                    {
                        i = 0;
                        dataGridViewTableDb.Rows.Add(row);
                    }
                }
            }
        }
        
        string SendTableUDP(string nameTable)
        {
            int idOpenTable = 0;
            foreach (SqlTable currentTable in sqlTables)
            {
                if (currentTable.name == nameTable)
                {
                    idOpenTable = currentTable.id;
                    break;
                }
            }

            sqlRead = null;
            sqlCommand.CommandText = "SELECT name FROM sys.columns WHERE object_id=" + idOpenTable.ToString();
            sqlRead = sqlCommand.ExecuteReader();
            string listColumns = "Columns";

            int columnCount = 0;
            while (sqlRead.Read())
            {
                listColumns += ":;" + sqlRead[0].ToString();
                columnCount++;
            }
            sqlRead.Close();

            sqlRead = null;
            sqlCommand.CommandText = "SELECT * FROM " + nameTable;
            sqlRead = sqlCommand.ExecuteReader();
            string listDataTable = ":;Data";

            while (sqlRead.Read())
            {
                for (int i = 0; i < columnCount; i++)
                    listDataTable += ":;" + sqlRead[i].ToString();
            }
            sqlRead.Close();

            return listColumns + listDataTable;
        }

        void OpenTableUDP(string[] data)
        {
            sqlColumns = new List<SqlColumn>();
            sqlDataTable = new List<string>();

            for (int i = 2; i < data.Length; i++)
            {
                if (data[i] == "Columns")
                {
                    i++;
                    while(data[i] != "Data")
                    {
                        SqlColumn currentColumn;
                        currentColumn.name = data[i];
                        currentColumn.user_type_id = 0;
                        sqlColumns.Add(currentColumn);
                        i++;
                    }
                    i++;
                }
                sqlDataTable.Add(data[i]);
            }
        }
        
        // Получает список таблиц (на сервере)
        void GetTables()
        {
            sqlRead = null;
            sqlCommand.CommandText = "SELECT object_id, name FROM sys.tables WHERE type_desc='USER_TABLE'";

            sqlRead = sqlCommand.ExecuteReader();

            sqlTables = new List<SqlTable>();
            while (sqlRead.Read())
            {
                SqlTable currentItem;
                currentItem.id = (int)sqlRead[0];
                currentItem.name = sqlRead[1].ToString();
                sqlTables.Add(currentItem);
            }
            sqlRead.Close();
        }
        
        // Получает список всех столбцов таблицы и её записи (на сервере)
        void GetSelectTable(string nameTable)
        {
            int idOpenTable = 0;
            foreach (SqlTable currentTable in sqlTables)
            {
                if (currentTable.name == nameTable)
                {
                    idOpenTable = currentTable.id;
                    break;
                }
            }

            sqlRead = null;
            sqlCommand.CommandText = "SELECT name, user_type_id FROM sys.columns WHERE object_id=" + idOpenTable.ToString();
            sqlRead = sqlCommand.ExecuteReader();
            sqlColumns = new List<SqlColumn>();

            while (sqlRead.Read())
            {
                SqlColumn currentColumn;
                currentColumn.name = sqlRead[0].ToString();
                currentColumn.user_type_id = (int)sqlRead[1];
                sqlColumns.Add(currentColumn);
            }
            sqlRead.Close();

            sqlRead = null;
            sqlCommand.CommandText = "SELECT * FROM " + nameTable;
            sqlRead = sqlCommand.ExecuteReader();
            sqlDataTable = new List<string>();

            while (sqlRead.Read())
            {
                for (int i = 0; i < sqlColumns.Count; i++)
                    sqlDataTable.Add(sqlRead[i].ToString());
            }
            sqlRead.Close();
        }

        // -----------------------------------------------------------------------------------------------
        // Методы действий
        // -----------------------------------------------------------------------------------------------
        private void insertActionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            insertBox insertBox = new insertBox(openNameTable, sqlColumns);
            insertBox.ShowDialog();
            if (insertBox.success)
            {
                if (modeOpenConnection == ModeOpenConnection.local)
                {
                    InsertRecordSql(openNameTable, insertBox.insertData);
                }
                else
                {
                    string sendData = "";
                    foreach (string currentData in insertBox.insertData)
                    {
                        sendData += ":;" + currentData;
                    }
                    SendMessageUDP(serverIpAddress, serverPort, thisPort.ToString() + ":;InsertRecord:;" + openNameTable + sendData);
                    Thread.Sleep(500);
                }

                updateTableActionToolStripMenuItem_Click(sender, e);
            }
        }

        private void deleteActionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            deleteBox deleteBox = new deleteBox(openNameTable);
            deleteBox.ShowDialog();
            if (deleteBox.success)
            {
                if (modeOpenConnection == ModeOpenConnection.local)
                {
                    DeleteRecordSql(openNameTable, deleteBox.deleteId);
                }
                else
                {
                    SendMessageUDP(serverIpAddress, serverPort, thisPort.ToString() + ":;DeleteRecord:;" + openNameTable + ":;" + deleteBox.deleteId);
                    Thread.Sleep(500);
                }

                updateTableActionToolStripMenuItem_Click(sender, e);
            }
        }

        private void updateTableActionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridViewTableDb.Rows.Clear();
            if (modeOpenConnection == ModeOpenConnection.local)
                GetSelectTable(openNameTable);
            else
            {
                SendMessageUDP(serverIpAddress, serverPort, thisPort.ToString() + ":;GiveTable:;" + openNameTable);
                Thread.Sleep(500);
            }
            OpenSelectTable();
        }

        void InsertRecordSql(string nameTable, List<string> insertData)
        {
            GetSelectTable(nameTable);
            sqlCommand.CommandText = "INSERT INTO " + nameTable + " (";

            foreach (SqlColumn currentColumn in sqlColumns)
            {
                if (currentColumn.name != "Id")
                    sqlCommand.CommandText += "[" + currentColumn.name + "], ";
            }

            sqlCommand.CommandText = sqlCommand.CommandText.Substring(0, sqlCommand.CommandText.Length - 2);
            sqlCommand.CommandText += ") VALUES (";

            int i = 0;
            foreach (SqlColumn currentColumn in sqlColumns)
            {
                if (currentColumn.name != "Id")
                {
                    if (currentColumn.user_type_id == 239 || currentColumn.user_type_id == 231)
                    {
                        sqlCommand.CommandText += "N'" + insertData[i] + "', ";
                    }
                    else
                    {
                        sqlCommand.CommandText += insertData[i] + ", ";
                    }
                    i++;
                }
            }

            sqlCommand.CommandText = sqlCommand.CommandText.Substring(0, sqlCommand.CommandText.Length - 2);
            sqlCommand.CommandText += ")";

            sqlCommand.ExecuteNonQuery();
        }

        void DeleteRecordSql(string nameTable, string id)
        {
            sqlCommand.CommandText = "DELETE FROM " + nameTable + " WHERE Id = " + id;
            sqlCommand.ExecuteNonQuery();
        }

        // -----------------------------------------------------------------------------------------------
        // Методы сети
        // -----------------------------------------------------------------------------------------------
        private void openPortToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formOpenPort FormOpenPort = new formOpenPort();
            FormOpenPort.ShowDialog();
            if (FormOpenPort.success)
            {
                changeThisPort = true;
                thisPort = FormOpenPort.port;
                receiveThreadUDP = new Thread(new ParameterizedThreadStart(ReceiveMessageUDP));
                receiveThreadUDP.Start(thisPort);
            }
        }
        
        private void infNetworkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("IP-адрес: " + System.Net.Dns.GetHostByName(System.Net.Dns.GetHostName()).AddressList[0].ToString() +
                            "\nОткрытый порт: " + thisPort.ToString(), "Сведения сети", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        // -----------------------------------------------------------------------------------------------
        // Методы справки
        // -----------------------------------------------------------------------------------------------
        private void AboutProgramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("RW Database\n\n" +
                "Программа редактирования таблиц базы данных.\n" +
                "Выполнена в рамках выполнения курсовой работы.\n" +
                "Студент группы 15ВВ1 Жданов Д.М.\n" +
                "ПГУ ФВТ ВТ 2018",
                "О программе", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void exitToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Close();
        }
        
        // -----------------------------------------------------------------------------------------------
        // Протокол UDP
        // -----------------------------------------------------------------------------------------------
        void SendMessageUDP(string ip, int port, string message)
        {
            UdpClient senderUDP = new UdpClient();
            try
            {
                byte[] data = Encoding.Unicode.GetBytes(message);
                senderUDP.Send(data, data.Length, ip, port);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                senderUDP.Close();
            }
        }
        
        void ReceiveMessageUDP(object port)
        {
            changeThisPort = false;
            UdpClient receiverUDP = new UdpClient((int)port);
            IPEndPoint remoteIp = null;
            try
            {
                while (!changeThisPort)
                {
                    byte[] data = receiverUDP.Receive(ref remoteIp);
                    recMessage = Encoding.Unicode.GetString(data);
                    string[] separator = { ":;" };
                    receiveMessage = recMessage.Split(separator, StringSplitOptions.RemoveEmptyEntries);
                    switch (receiveMessage[1])
                    {
                        case "Are u server?":
                            if (modeOpenConnection != ModeOpenConnection.none)
                            {
                                string listTables = "";
                                foreach (var currentTable in sqlTables)
                                {
                                    listTables += ":;" + currentTable.name;
                                }
                                SendMessageUDP(remoteIp.Address.ToString(), int.Parse(receiveMessage[0]), thisPort.ToString() + ":;I'm server:;" + openNameDatabase + listTables);
                            }
                            break;
                        case "I'm server":
                            openNameDatabase = receiveMessage[2];

                            sqlTables = new List<SqlTable>();
                            for (int i = 3; i < receiveMessage.Length; i++)
                            {
                                SqlTable currentItem;
                                currentItem.id = 0;
                                currentItem.name = receiveMessage[i];
                                sqlTables.Add(currentItem);
                            }

                            isNetwork = true;
                            break;
                        case "GiveTable":
                            SendMessageUDP(remoteIp.Address.ToString(), int.Parse(receiveMessage[0]), thisPort.ToString() + ":;Table:;" + SendTableUDP(receiveMessage[2]));
                            break;
                        case "Table":
                            OpenTableUDP(receiveMessage);
                            break;
                        case "InsertRecord":
                            List<string> insertData = new List<string>();
                            for (int i = 3; i < receiveMessage.Length; i++)
                            {
                                insertData.Add(receiveMessage[i]);
                            }
                            InsertRecordSql(receiveMessage[2], insertData);
                            break;
                        case "DeleteRecord":
                            DeleteRecordSql(receiveMessage[2], receiveMessage[3]);
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                receiverUDP.Close();
            }
        }
    }
}
