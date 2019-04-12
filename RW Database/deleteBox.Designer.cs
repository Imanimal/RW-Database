namespace RW_Database
{
    partial class deleteBox
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.nameField = new System.Windows.Forms.Label();
            this.valueField = new System.Windows.Forms.TextBox();
            this.groupBoxField = new System.Windows.Forms.GroupBox();
            this.cancelButton = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.groupBoxField.SuspendLayout();
            this.SuspendLayout();
            // 
            // nameField
            // 
            this.nameField.AutoSize = true;
            this.nameField.Location = new System.Drawing.Point(6, 16);
            this.nameField.Name = "nameField";
            this.nameField.Size = new System.Drawing.Size(147, 13);
            this.nameField.TabIndex = 0;
            this.nameField.Text = "Id (Идентификатор записи):";
            // 
            // valueField
            // 
            this.valueField.Location = new System.Drawing.Point(9, 32);
            this.valueField.Name = "valueField";
            this.valueField.Size = new System.Drawing.Size(391, 20);
            this.valueField.TabIndex = 1;
            // 
            // groupBoxField
            // 
            this.groupBoxField.Controls.Add(this.nameField);
            this.groupBoxField.Controls.Add(this.valueField);
            this.groupBoxField.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBoxField.Location = new System.Drawing.Point(0, 0);
            this.groupBoxField.Name = "groupBoxField";
            this.groupBoxField.Size = new System.Drawing.Size(412, 60);
            this.groupBoxField.TabIndex = 2;
            this.groupBoxField.TabStop = false;
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.Location = new System.Drawing.Point(244, 73);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 3;
            this.cancelButton.Text = "Отмена";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.Location = new System.Drawing.Point(325, 73);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 4;
            this.okButton.Text = "Удалить";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // deleteBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(412, 108);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.groupBoxField);
            this.MaximumSize = new System.Drawing.Size(428, 324);
            this.MinimumSize = new System.Drawing.Size(428, 147);
            this.Name = "deleteBox";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Окно удаления";
            this.groupBoxField.ResumeLayout(false);
            this.groupBoxField.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label nameField;
        private System.Windows.Forms.TextBox valueField;
        private System.Windows.Forms.GroupBox groupBoxField;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button okButton;
    }
}