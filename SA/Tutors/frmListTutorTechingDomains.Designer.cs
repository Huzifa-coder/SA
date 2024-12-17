namespace SA.Tutors
{
    partial class frmListTutorTechingDomains
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
            this.label4 = new System.Windows.Forms.Label();
            this.lbRecords = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvTutorTeachingDomains = new System.Windows.Forms.DataGridView();
            this.cmsTutorTeachingDomains = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnAddNewDomainType = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTutorTeachingDomains)).BeginInit();
            this.cmsTutorTeachingDomains.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label4.Location = new System.Drawing.Point(9, 597);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 24);
            this.label4.TabIndex = 86;
            this.label4.Text = "# Records : ";
            // 
            // lbRecords
            // 
            this.lbRecords.AutoSize = true;
            this.lbRecords.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.lbRecords.Location = new System.Drawing.Point(120, 597);
            this.lbRecords.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbRecords.Name = "lbRecords";
            this.lbRecords.Size = new System.Drawing.Size(30, 24);
            this.lbRecords.TabIndex = 85;
            this.lbRecords.Text = "00";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(200, 187);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(361, 31);
            this.label1.TabIndex = 81;
            this.label1.Text = "Tutor Teaching Domains List";
            // 
            // dgvTutorTeachingDomains
            // 
            this.dgvTutorTeachingDomains.AllowUserToAddRows = false;
            this.dgvTutorTeachingDomains.AllowUserToDeleteRows = false;
            this.dgvTutorTeachingDomains.AllowUserToResizeColumns = false;
            this.dgvTutorTeachingDomains.AllowUserToResizeRows = false;
            this.dgvTutorTeachingDomains.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTutorTeachingDomains.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvTutorTeachingDomains.BackgroundColor = System.Drawing.Color.White;
            this.dgvTutorTeachingDomains.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvTutorTeachingDomains.ColumnHeadersHeight = 29;
            this.dgvTutorTeachingDomains.ContextMenuStrip = this.cmsTutorTeachingDomains;
            this.dgvTutorTeachingDomains.Location = new System.Drawing.Point(13, 268);
            this.dgvTutorTeachingDomains.Margin = new System.Windows.Forms.Padding(2);
            this.dgvTutorTeachingDomains.MultiSelect = false;
            this.dgvTutorTeachingDomains.Name = "dgvTutorTeachingDomains";
            this.dgvTutorTeachingDomains.ReadOnly = true;
            this.dgvTutorTeachingDomains.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvTutorTeachingDomains.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dgvTutorTeachingDomains.RowTemplate.Height = 24;
            this.dgvTutorTeachingDomains.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTutorTeachingDomains.Size = new System.Drawing.Size(734, 308);
            this.dgvTutorTeachingDomains.StandardTab = true;
            this.dgvTutorTeachingDomains.TabIndex = 80;
            // 
            // cmsTutorTeachingDomains
            // 
            this.cmsTutorTeachingDomains.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteToolStripMenuItem,
            this.toolStripMenuItem2,
            this.refreshToolStripMenuItem});
            this.cmsTutorTeachingDomains.Name = "contextMenuStrip1";
            this.cmsTutorTeachingDomains.Size = new System.Drawing.Size(130, 86);
            this.cmsTutorTeachingDomains.Opening += new System.ComponentModel.CancelEventHandler(this.cmsTutorTeachingDomains_Opening);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Image = global::SA.Properties.Resources.Delete_32_2;
            this.deleteToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(129, 38);
            this.deleteToolStripMenuItem.Text = "Delete ";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deletePersonToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(126, 6);
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Image = global::SA.Properties.Resources.refresh;
            this.refreshToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(129, 38);
            this.refreshToolStripMenuItem.Text = "Refresh";
            this.refreshToolStripMenuItem.Click += new System.EventHandler(this.refreshToolStripMenuItem_Click);
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnClose.Image = global::SA.Properties.Resources.Close_32;
            this.btnClose.Location = new System.Drawing.Point(624, 586);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(123, 48);
            this.btnClose.TabIndex = 88;
            this.btnClose.Text = "Close";
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // btnAddNewDomainType
            // 
            this.btnAddNewDomainType.Image = global::SA.Properties.Resources.add_Tutor_Teaching_Domain;
            this.btnAddNewDomainType.Location = new System.Drawing.Point(685, 219);
            this.btnAddNewDomainType.Margin = new System.Windows.Forms.Padding(2);
            this.btnAddNewDomainType.Name = "btnAddNewDomainType";
            this.btnAddNewDomainType.Size = new System.Drawing.Size(62, 45);
            this.btnAddNewDomainType.TabIndex = 84;
            this.btnAddNewDomainType.UseVisualStyleBackColor = true;
            this.btnAddNewDomainType.Click += new System.EventHandler(this.btnAddNewDomainType_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Image = global::SA.Properties.Resources.teaching_Domains;
            this.pictureBox1.Location = new System.Drawing.Point(296, 11);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(168, 174);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 79;
            this.pictureBox1.TabStop = false;
            // 
            // frmListTutorTechingDomains
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(763, 644);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lbRecords);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvTutorTeachingDomains);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnAddNewDomainType);
            this.Controls.Add(this.pictureBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmListTutorTechingDomains";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tutor Teching Domains";
            this.Load += new System.EventHandler(this.frmListTutorTechingDomains_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTutorTeachingDomains)).EndInit();
            this.cmsTutorTeachingDomains.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbRecords;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvTutorTeachingDomains;
        private System.Windows.Forms.ContextMenuStrip cmsTutorTeachingDomains;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnAddNewDomainType;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}