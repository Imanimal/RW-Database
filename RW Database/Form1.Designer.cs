namespace RW_Database
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.MainMenu = new System.Windows.Forms.MenuStrip();
            this.connectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.localDbToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenDatabaseLocalModeReadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenDatabaseLocalModeWriteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.serverDbToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenDatabaseServerModeReadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenDatabaseServerModeWriteToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.unconnectedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.networkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openPortToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.infNetworkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tablesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.actionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.insertActionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteActionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateTableActionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutProgramToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectDbOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.dataGridViewTableDb = new System.Windows.Forms.DataGridView();
            this.statusConnectionMenu = new System.Windows.Forms.StatusStrip();
            this.statusModeOpenLabelMenu = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusModeOpenConnectionLabelMenu = new System.Windows.Forms.ToolStripStatusLabel();
            this.MainMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTableDb)).BeginInit();
            this.statusConnectionMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainMenu
            // 
            this.MainMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.connectionToolStripMenuItem,
            this.tablesToolStripMenuItem,
            this.actionToolStripMenuItem,
            this.networkToolStripMenuItem,
            this.refToolStripMenuItem});
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Size = new System.Drawing.Size(784, 24);
            this.MainMenu.TabIndex = 0;
            this.MainMenu.Text = "menuStrip1";
            // 
            // connectionToolStripMenuItem
            // 
            this.connectionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.localDbToolStripMenuItem,
            this.serverDbToolStripMenuItem,
            this.unconnectedToolStripMenuItem});
            this.connectionToolStripMenuItem.Name = "connectionToolStripMenuItem";
            this.connectionToolStripMenuItem.Size = new System.Drawing.Size(101, 20);
            this.connectionToolStripMenuItem.Text = "Подключиться";
            // 
            // localDbToolStripMenuItem
            // 
            this.localDbToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpenDatabaseLocalModeReadToolStripMenuItem,
            this.OpenDatabaseLocalModeWriteToolStripMenuItem});
            this.localDbToolStripMenuItem.Name = "localDbToolStripMenuItem";
            this.localDbToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.localDbToolStripMenuItem.Text = "К базе данных";
            // 
            // OpenDatabaseLocalModeReadToolStripMenuItem
            // 
            this.OpenDatabaseLocalModeReadToolStripMenuItem.Name = "OpenDatabaseLocalModeReadToolStripMenuItem";
            this.OpenDatabaseLocalModeReadToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.OpenDatabaseLocalModeReadToolStripMenuItem.Text = "Режим чтения";
            this.OpenDatabaseLocalModeReadToolStripMenuItem.Click += new System.EventHandler(this.OpenDatabaseLocalModeReadToolStripMenuItem_Click);
            // 
            // OpenDatabaseLocalModeWriteToolStripMenuItem
            // 
            this.OpenDatabaseLocalModeWriteToolStripMenuItem.Name = "OpenDatabaseLocalModeWriteToolStripMenuItem";
            this.OpenDatabaseLocalModeWriteToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.OpenDatabaseLocalModeWriteToolStripMenuItem.Text = "Режим записи";
            this.OpenDatabaseLocalModeWriteToolStripMenuItem.Click += new System.EventHandler(this.OpenDatabaseLocalModeWriteToolStripMenuItem_Click);
            // 
            // serverDbToolStripMenuItem
            // 
            this.serverDbToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpenDatabaseServerModeReadToolStripMenuItem,
            this.OpenDatabaseServerModeWriteToolStripMenuItem1});
            this.serverDbToolStripMenuItem.Name = "serverDbToolStripMenuItem";
            this.serverDbToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.serverDbToolStripMenuItem.Text = "К серверу";
            // 
            // OpenDatabaseServerModeReadToolStripMenuItem
            // 
            this.OpenDatabaseServerModeReadToolStripMenuItem.Name = "OpenDatabaseServerModeReadToolStripMenuItem";
            this.OpenDatabaseServerModeReadToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.OpenDatabaseServerModeReadToolStripMenuItem.Text = "Режим чтения";
            this.OpenDatabaseServerModeReadToolStripMenuItem.Click += new System.EventHandler(this.OpenDatabaseServerModeReadToolStripMenuItem_Click);
            // 
            // OpenDatabaseServerModeWriteToolStripMenuItem1
            // 
            this.OpenDatabaseServerModeWriteToolStripMenuItem1.Name = "OpenDatabaseServerModeWriteToolStripMenuItem1";
            this.OpenDatabaseServerModeWriteToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.OpenDatabaseServerModeWriteToolStripMenuItem1.Text = "Режим записи";
            this.OpenDatabaseServerModeWriteToolStripMenuItem1.Click += new System.EventHandler(this.OpenDatabaseServerModeWriteToolStripMenuItem1_Click);
            // 
            // unconnectedToolStripMenuItem
            // 
            this.unconnectedToolStripMenuItem.Name = "unconnectedToolStripMenuItem";
            this.unconnectedToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.unconnectedToolStripMenuItem.Text = "Отключиться";
            this.unconnectedToolStripMenuItem.Click += new System.EventHandler(this.unconnectedToolStripMenuItem_Click);
            // 
            // networkToolStripMenuItem
            // 
            this.networkToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openPortToolStripMenuItem,
            this.infNetworkToolStripMenuItem});
            this.networkToolStripMenuItem.Name = "networkToolStripMenuItem";
            this.networkToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.networkToolStripMenuItem.Text = "Сеть";
            // 
            // openPortToolStripMenuItem
            // 
            this.openPortToolStripMenuItem.Name = "openPortToolStripMenuItem";
            this.openPortToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.openPortToolStripMenuItem.Text = "Открыть порт";
            this.openPortToolStripMenuItem.Click += new System.EventHandler(this.openPortToolStripMenuItem_Click);
            // 
            // infNetworkToolStripMenuItem
            // 
            this.infNetworkToolStripMenuItem.Name = "infNetworkToolStripMenuItem";
            this.infNetworkToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.infNetworkToolStripMenuItem.Text = "Сведения сети";
            this.infNetworkToolStripMenuItem.Click += new System.EventHandler(this.infNetworkToolStripMenuItem_Click);
            // 
            // tablesToolStripMenuItem
            // 
            this.tablesToolStripMenuItem.Enabled = false;
            this.tablesToolStripMenuItem.Name = "tablesToolStripMenuItem";
            this.tablesToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.tablesToolStripMenuItem.Text = "Таблица";
            // 
            // actionToolStripMenuItem
            // 
            this.actionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.insertActionToolStripMenuItem,
            this.deleteActionToolStripMenuItem,
            this.updateTableActionToolStripMenuItem});
            this.actionToolStripMenuItem.Enabled = false;
            this.actionToolStripMenuItem.Name = "actionToolStripMenuItem";
            this.actionToolStripMenuItem.Size = new System.Drawing.Size(70, 20);
            this.actionToolStripMenuItem.Text = "Действие";
            // 
            // insertActionToolStripMenuItem
            // 
            this.insertActionToolStripMenuItem.Enabled = false;
            this.insertActionToolStripMenuItem.Name = "insertActionToolStripMenuItem";
            this.insertActionToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.insertActionToolStripMenuItem.Text = "Добавить запись";
            this.insertActionToolStripMenuItem.Click += new System.EventHandler(this.insertActionToolStripMenuItem_Click);
            // 
            // deleteActionToolStripMenuItem
            // 
            this.deleteActionToolStripMenuItem.Enabled = false;
            this.deleteActionToolStripMenuItem.Name = "deleteActionToolStripMenuItem";
            this.deleteActionToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.deleteActionToolStripMenuItem.Text = "Удалить запись";
            this.deleteActionToolStripMenuItem.Click += new System.EventHandler(this.deleteActionToolStripMenuItem_Click);
            // 
            // updateTableActionToolStripMenuItem
            // 
            this.updateTableActionToolStripMenuItem.Name = "updateTableActionToolStripMenuItem";
            this.updateTableActionToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.updateTableActionToolStripMenuItem.Text = "Обновить таблицу";
            this.updateTableActionToolStripMenuItem.Click += new System.EventHandler(this.updateTableActionToolStripMenuItem_Click);
            // 
            // refToolStripMenuItem
            // 
            this.refToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutProgramToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.refToolStripMenuItem.Name = "refToolStripMenuItem";
            this.refToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.refToolStripMenuItem.Text = "Справка";
            // 
            // aboutProgramToolStripMenuItem
            // 
            this.aboutProgramToolStripMenuItem.Name = "aboutProgramToolStripMenuItem";
            this.aboutProgramToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.aboutProgramToolStripMenuItem.Text = "О программе";
            this.aboutProgramToolStripMenuItem.Click += new System.EventHandler(this.AboutProgramToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exitToolStripMenuItem.Text = "Выход";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click_1);
            // 
            // selectDbOpenFileDialog
            // 
            this.selectDbOpenFileDialog.FileName = "openFileDialog1";
            this.selectDbOpenFileDialog.Filter = "Базы данных|*.mdf|Все файлы|*.*";
            this.selectDbOpenFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.selectDbOpenFileDialog_FileOk);
            // 
            // dataGridViewTableDb
            // 
            this.dataGridViewTableDb.AllowUserToAddRows = false;
            this.dataGridViewTableDb.AllowUserToDeleteRows = false;
            this.dataGridViewTableDb.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewTableDb.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTableDb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewTableDb.Location = new System.Drawing.Point(0, 24);
            this.dataGridViewTableDb.Margin = new System.Windows.Forms.Padding(15);
            this.dataGridViewTableDb.Name = "dataGridViewTableDb";
            this.dataGridViewTableDb.ReadOnly = true;
            this.dataGridViewTableDb.Size = new System.Drawing.Size(784, 337);
            this.dataGridViewTableDb.TabIndex = 1;
            // 
            // statusConnectionMenu
            // 
            this.statusConnectionMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusModeOpenLabelMenu,
            this.statusModeOpenConnectionLabelMenu});
            this.statusConnectionMenu.Location = new System.Drawing.Point(0, 339);
            this.statusConnectionMenu.Name = "statusConnectionMenu";
            this.statusConnectionMenu.Size = new System.Drawing.Size(784, 22);
            this.statusConnectionMenu.TabIndex = 2;
            this.statusConnectionMenu.Text = "statusStrip1";
            // 
            // statusModeOpenLabelMenu
            // 
            this.statusModeOpenLabelMenu.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.statusModeOpenLabelMenu.Name = "statusModeOpenLabelMenu";
            this.statusModeOpenLabelMenu.Size = new System.Drawing.Size(384, 17);
            this.statusModeOpenLabelMenu.Spring = true;
            // 
            // statusModeOpenConnectionLabelMenu
            // 
            this.statusModeOpenConnectionLabelMenu.Name = "statusModeOpenConnectionLabelMenu";
            this.statusModeOpenConnectionLabelMenu.Size = new System.Drawing.Size(384, 17);
            this.statusModeOpenConnectionLabelMenu.Spring = true;
            this.statusModeOpenConnectionLabelMenu.Text = "Соединение не установлено";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 361);
            this.Controls.Add(this.statusConnectionMenu);
            this.Controls.Add(this.dataGridViewTableDb);
            this.Controls.Add(this.MainMenu);
            this.MainMenuStrip = this.MainMenu;
            this.MinimumSize = new System.Drawing.Size(500, 200);
            this.Name = "MainForm";
            this.Text = "RW Database";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTableDb)).EndInit();
            this.statusConnectionMenu.ResumeLayout(false);
            this.statusConnectionMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MainMenu;
        private System.Windows.Forms.ToolStripMenuItem connectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem localDbToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OpenDatabaseLocalModeReadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OpenDatabaseLocalModeWriteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem serverDbToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OpenDatabaseServerModeReadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OpenDatabaseServerModeWriteToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem tablesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem actionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem insertActionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteActionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem refToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog selectDbOpenFileDialog;
        private System.Windows.Forms.DataGridView dataGridViewTableDb;
        private System.Windows.Forms.StatusStrip statusConnectionMenu;
        private System.Windows.Forms.ToolStripStatusLabel statusModeOpenLabelMenu;
        private System.Windows.Forms.ToolStripStatusLabel statusModeOpenConnectionLabelMenu;
        private System.Windows.Forms.ToolStripMenuItem updateTableActionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem unconnectedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem networkToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openPortToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem infNetworkToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutProgramToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
    }
}

