namespace SA.Students
{
    partial class frmListStudents
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
            this.components = new System.ComponentModel.Container();
            this.tbFilterValue = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lbRecords = new System.Windows.Forms.Label();
            this.cbFilterBy = new System.Windows.Forms.ComboBox();
            this.lbfilterText = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvStudents = new System.Windows.Forms.DataGridView();
            this.cmsStudents = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addPaymentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editPaymentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.paymentInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.batchInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.progarmInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.editStudentInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteStudentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnAddNewUser = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudents)).BeginInit();
            this.cmsStudents.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tbFilterValue
            // 
            this.tbFilterValue.Location = new System.Drawing.Point(248, 230);
            this.tbFilterValue.Margin = new System.Windows.Forms.Padding(2);
            this.tbFilterValue.Name = "tbFilterValue";
            this.tbFilterValue.Size = new System.Drawing.Size(139, 20);
            this.tbFilterValue.TabIndex = 67;
            this.tbFilterValue.TextChanged += new System.EventHandler(this.tbFilterValue_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label4.Location = new System.Drawing.Point(16, 597);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 24);
            this.label4.TabIndex = 66;
            this.label4.Text = "# Records : ";
            // 
            // lbRecords
            // 
            this.lbRecords.AutoSize = true;
            this.lbRecords.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.lbRecords.Location = new System.Drawing.Point(127, 597);
            this.lbRecords.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbRecords.Name = "lbRecords";
            this.lbRecords.Size = new System.Drawing.Size(30, 24);
            this.lbRecords.TabIndex = 65;
            this.lbRecords.Text = "00";
            // 
            // cbFilterBy
            // 
            this.cbFilterBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilterBy.FormattingEnabled = true;
            this.cbFilterBy.Items.AddRange(new object[] {
            "None",
            "Full Name",
            "Batch Name"});
            this.cbFilterBy.Location = new System.Drawing.Point(105, 230);
            this.cbFilterBy.Margin = new System.Windows.Forms.Padding(2);
            this.cbFilterBy.Name = "cbFilterBy";
            this.cbFilterBy.Size = new System.Drawing.Size(139, 21);
            this.cbFilterBy.TabIndex = 63;
            this.cbFilterBy.SelectedIndexChanged += new System.EventHandler(this.cbFilterBy_SelectedIndexChanged);
            // 
            // lbfilterText
            // 
            this.lbfilterText.AutoSize = true;
            this.lbfilterText.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.lbfilterText.Location = new System.Drawing.Point(16, 228);
            this.lbfilterText.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbfilterText.Name = "lbfilterText";
            this.lbfilterText.Size = new System.Drawing.Size(87, 24);
            this.lbfilterText.TabIndex = 62;
            this.lbfilterText.Text = "Filter By :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(467, 187);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(172, 31);
            this.label1.TabIndex = 61;
            this.label1.Text = "Students List";
            // 
            // dgvStudents
            // 
            this.dgvStudents.AllowUserToAddRows = false;
            this.dgvStudents.AllowUserToDeleteRows = false;
            this.dgvStudents.AllowUserToResizeColumns = false;
            this.dgvStudents.AllowUserToResizeRows = false;
            this.dgvStudents.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvStudents.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvStudents.BackgroundColor = System.Drawing.Color.White;
            this.dgvStudents.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvStudents.ColumnHeadersHeight = 29;
            this.dgvStudents.ContextMenuStrip = this.cmsStudents;
            this.dgvStudents.Location = new System.Drawing.Point(20, 268);
            this.dgvStudents.Margin = new System.Windows.Forms.Padding(2);
            this.dgvStudents.MultiSelect = false;
            this.dgvStudents.Name = "dgvStudents";
            this.dgvStudents.ReadOnly = true;
            this.dgvStudents.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvStudents.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dgvStudents.RowTemplate.Height = 24;
            this.dgvStudents.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvStudents.Size = new System.Drawing.Size(1067, 308);
            this.dgvStudents.StandardTab = true;
            this.dgvStudents.TabIndex = 60;
            // 
            // cmsStudents
            // 
            this.cmsStudents.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addPaymentToolStripMenuItem,
            this.editPaymentToolStripMenuItem,
            this.paymentInfoToolStripMenuItem,
            this.toolStripMenuItem2,
            this.batchInfoToolStripMenuItem,
            this.progarmInfoToolStripMenuItem,
            this.toolStripMenuItem1,
            this.editStudentInfoToolStripMenuItem,
            this.deleteStudentToolStripMenuItem,
            this.toolStripSeparator1,
            this.refreshToolStripMenuItem});
            this.cmsStudents.Name = "contextMenuStrip1";
            this.cmsStudents.Size = new System.Drawing.Size(203, 396);
            this.cmsStudents.Opening += new System.ComponentModel.CancelEventHandler(this.cmsStudents_Opening);
            // 
            // addPaymentToolStripMenuItem
            // 
            this.addPaymentToolStripMenuItem.Image = global::SA.Properties.Resources.money_32;
            this.addPaymentToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.addPaymentToolStripMenuItem.Name = "addPaymentToolStripMenuItem";
            this.addPaymentToolStripMenuItem.Size = new System.Drawing.Size(202, 44);
            this.addPaymentToolStripMenuItem.Text = "Add Payment";
            this.addPaymentToolStripMenuItem.Click += new System.EventHandler(this.addPaymentToolStripMenuItem_Click);
            // 
            // editPaymentToolStripMenuItem
            // 
            this.editPaymentToolStripMenuItem.Image = global::SA.Properties.Resources.payment_edit;
            this.editPaymentToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.editPaymentToolStripMenuItem.Name = "editPaymentToolStripMenuItem";
            this.editPaymentToolStripMenuItem.Size = new System.Drawing.Size(202, 44);
            this.editPaymentToolStripMenuItem.Text = "Edit Payment";
            this.editPaymentToolStripMenuItem.Click += new System.EventHandler(this.editPaymentToolStripMenuItem_Click);
            // 
            // paymentInfoToolStripMenuItem
            // 
            this.paymentInfoToolStripMenuItem.Image = global::SA.Properties.Resources.payment_info;
            this.paymentInfoToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.paymentInfoToolStripMenuItem.Name = "paymentInfoToolStripMenuItem";
            this.paymentInfoToolStripMenuItem.Size = new System.Drawing.Size(202, 44);
            this.paymentInfoToolStripMenuItem.Text = "Payment Info";
            this.paymentInfoToolStripMenuItem.Click += new System.EventHandler(this.paymentInfoToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(199, 6);
            // 
            // batchInfoToolStripMenuItem
            // 
            this.batchInfoToolStripMenuItem.Image = global::SA.Properties.Resources.batch_32;
            this.batchInfoToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.batchInfoToolStripMenuItem.Name = "batchInfoToolStripMenuItem";
            this.batchInfoToolStripMenuItem.Size = new System.Drawing.Size(202, 44);
            this.batchInfoToolStripMenuItem.Text = "Batch Info";
            this.batchInfoToolStripMenuItem.Click += new System.EventHandler(this.batchInfoToolStripMenuItem_Click);
            // 
            // progarmInfoToolStripMenuItem
            // 
            this.progarmInfoToolStripMenuItem.Image = global::SA.Properties.Resources.coursee_32;
            this.progarmInfoToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.progarmInfoToolStripMenuItem.Name = "progarmInfoToolStripMenuItem";
            this.progarmInfoToolStripMenuItem.Size = new System.Drawing.Size(202, 44);
            this.progarmInfoToolStripMenuItem.Text = "Progarm Info";
            this.progarmInfoToolStripMenuItem.Click += new System.EventHandler(this.progarmInfoToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(199, 6);
            // 
            // editStudentInfoToolStripMenuItem
            // 
            this.editStudentInfoToolStripMenuItem.Image = global::SA.Properties.Resources.edit_32;
            this.editStudentInfoToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.editStudentInfoToolStripMenuItem.Name = "editStudentInfoToolStripMenuItem";
            this.editStudentInfoToolStripMenuItem.Size = new System.Drawing.Size(202, 44);
            this.editStudentInfoToolStripMenuItem.Text = "Edit";
            this.editStudentInfoToolStripMenuItem.Click += new System.EventHandler(this.editUserInfoToolStripMenuItem_Click);
            // 
            // deleteStudentToolStripMenuItem
            // 
            this.deleteStudentToolStripMenuItem.Image = global::SA.Properties.Resources.Delete_32_2;
            this.deleteStudentToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.deleteStudentToolStripMenuItem.Name = "deleteStudentToolStripMenuItem";
            this.deleteStudentToolStripMenuItem.Size = new System.Drawing.Size(202, 44);
            this.deleteStudentToolStripMenuItem.Text = "Delete";
            this.deleteStudentToolStripMenuItem.Click += new System.EventHandler(this.deletePersonToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(199, 6);
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Image = global::SA.Properties.Resources.refresh;
            this.refreshToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(202, 44);
            this.refreshToolStripMenuItem.Text = "Refresh";
            this.refreshToolStripMenuItem.Click += new System.EventHandler(this.refreshToolStripMenuItem_Click);
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnClose.Image = global::SA.Properties.Resources.Close_32;
            this.btnClose.Location = new System.Drawing.Point(964, 586);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(123, 48);
            this.btnClose.TabIndex = 68;
            this.btnClose.Text = "Close";
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // btnAddNewUser
            // 
            this.btnAddNewUser.Image = global::SA.Properties.Resources.Add_Person_40;
            this.btnAddNewUser.Location = new System.Drawing.Point(1025, 217);
            this.btnAddNewUser.Margin = new System.Windows.Forms.Padding(2);
            this.btnAddNewUser.Name = "btnAddNewUser";
            this.btnAddNewUser.Size = new System.Drawing.Size(62, 45);
            this.btnAddNewUser.TabIndex = 64;
            this.btnAddNewUser.UseVisualStyleBackColor = true;
            this.btnAddNewUser.Click += new System.EventHandler(this.btnAddNewUser_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Image = global::SA.Properties.Resources.Students;
            this.pictureBox1.Location = new System.Drawing.Point(469, 11);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(168, 174);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 59;
            this.pictureBox1.TabStop = false;
            // 
            // frmListStudents
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(1095, 649);
            this.Controls.Add(this.tbFilterValue);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lbRecords);
            this.Controls.Add(this.cbFilterBy);
            this.Controls.Add(this.lbfilterText);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvStudents);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnAddNewUser);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmListStudents";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Studnets List";
            this.Load += new System.EventHandler(this.frmListStudents_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudents)).EndInit();
            this.cmsStudents.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbFilterValue;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbRecords;
        private System.Windows.Forms.ComboBox cbFilterBy;
        private System.Windows.Forms.Label lbfilterText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvStudents;
        private System.Windows.Forms.ContextMenuStrip cmsStudents;
        private System.Windows.Forms.ToolStripMenuItem editStudentInfoToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem deleteStudentToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnAddNewUser;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripMenuItem addPaymentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editPaymentToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem batchInfoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem progarmInfoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem paymentInfoToolStripMenuItem;
    }
}