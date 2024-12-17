namespace SA.Batches.Batches_Allocation
{
    partial class frmListBatchesAllocations
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
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.cmsBatches = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.batchInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.programInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tbFilterValue = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lbRecords = new System.Windows.Forms.Label();
            this.cbFilterBy = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvBatchesAllocation = new System.Windows.Forms.DataGridView();
            this.btnClose = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.cmsBatches.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBatchesAllocation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(193, 6);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(193, 6);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(193, 6);
            // 
            // cmsBatches
            // 
            this.cmsBatches.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.batchInfoToolStripMenuItem,
            this.toolStripMenuItem1,
            this.programInfoToolStripMenuItem,
            this.toolStripMenuItem3,
            this.deleteToolStripMenuItem,
            this.toolStripMenuItem2,
            this.refreshToolStripMenuItem});
            this.cmsBatches.Name = "contextMenuStrip1";
            this.cmsBatches.Size = new System.Drawing.Size(197, 196);
            this.cmsBatches.Opening += new System.ComponentModel.CancelEventHandler(this.cmsBatches_Opening);
            // 
            // batchInfoToolStripMenuItem
            // 
            this.batchInfoToolStripMenuItem.Image = global::SA.Properties.Resources.batch_32;
            this.batchInfoToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.batchInfoToolStripMenuItem.Name = "batchInfoToolStripMenuItem";
            this.batchInfoToolStripMenuItem.Size = new System.Drawing.Size(196, 38);
            this.batchInfoToolStripMenuItem.Text = "Batch Info";
            this.batchInfoToolStripMenuItem.Click += new System.EventHandler(this.batchInfoToolStripMenuItem_Click);
            // 
            // programInfoToolStripMenuItem
            // 
            this.programInfoToolStripMenuItem.Image = global::SA.Properties.Resources.coursee_32;
            this.programInfoToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.programInfoToolStripMenuItem.Name = "programInfoToolStripMenuItem";
            this.programInfoToolStripMenuItem.Size = new System.Drawing.Size(196, 38);
            this.programInfoToolStripMenuItem.Text = "Program Info";
            this.programInfoToolStripMenuItem.Click += new System.EventHandler(this.programInfoToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Image = global::SA.Properties.Resources.Delete_32_2;
            this.deleteToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(196, 38);
            this.deleteToolStripMenuItem.Text = "Delete Allocation";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deletePersonToolStripMenuItem_Click);
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Image = global::SA.Properties.Resources.refresh;
            this.refreshToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(196, 38);
            this.refreshToolStripMenuItem.Text = "Refresh";
            this.refreshToolStripMenuItem.Click += new System.EventHandler(this.refreshToolStripMenuItem_Click);
            // 
            // tbFilterValue
            // 
            this.tbFilterValue.Location = new System.Drawing.Point(257, 230);
            this.tbFilterValue.Margin = new System.Windows.Forms.Padding(2);
            this.tbFilterValue.Name = "tbFilterValue";
            this.tbFilterValue.Size = new System.Drawing.Size(139, 26);
            this.tbFilterValue.TabIndex = 67;
            this.tbFilterValue.TextChanged += new System.EventHandler(this.tbFilterValue_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label4.Location = new System.Drawing.Point(14, 597);
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
            this.lbRecords.Location = new System.Drawing.Point(125, 597);
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
            "Batch Name",
            "Tutor Name"});
            this.cbFilterBy.Location = new System.Drawing.Point(103, 230);
            this.cbFilterBy.Margin = new System.Windows.Forms.Padding(2);
            this.cbFilterBy.Name = "cbFilterBy";
            this.cbFilterBy.Size = new System.Drawing.Size(150, 28);
            this.cbFilterBy.TabIndex = 63;
            this.cbFilterBy.SelectedIndexChanged += new System.EventHandler(this.cbFilterBy_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label2.Location = new System.Drawing.Point(14, 228);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 24);
            this.label2.TabIndex = 62;
            this.label2.Text = "Filter By :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(423, 187);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(288, 31);
            this.label1.TabIndex = 61;
            this.label1.Text = "Batches Allocation List";
            // 
            // dgvBatchesAllocation
            // 
            this.dgvBatchesAllocation.AllowUserToAddRows = false;
            this.dgvBatchesAllocation.AllowUserToDeleteRows = false;
            this.dgvBatchesAllocation.AllowUserToResizeColumns = false;
            this.dgvBatchesAllocation.AllowUserToResizeRows = false;
            this.dgvBatchesAllocation.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBatchesAllocation.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvBatchesAllocation.BackgroundColor = System.Drawing.Color.White;
            this.dgvBatchesAllocation.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvBatchesAllocation.ColumnHeadersHeight = 29;
            this.dgvBatchesAllocation.ContextMenuStrip = this.cmsBatches;
            this.dgvBatchesAllocation.Location = new System.Drawing.Point(18, 268);
            this.dgvBatchesAllocation.Margin = new System.Windows.Forms.Padding(2);
            this.dgvBatchesAllocation.MultiSelect = false;
            this.dgvBatchesAllocation.Name = "dgvBatchesAllocation";
            this.dgvBatchesAllocation.ReadOnly = true;
            this.dgvBatchesAllocation.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvBatchesAllocation.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dgvBatchesAllocation.RowTemplate.Height = 24;
            this.dgvBatchesAllocation.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBatchesAllocation.Size = new System.Drawing.Size(1098, 308);
            this.dgvBatchesAllocation.StandardTab = true;
            this.dgvBatchesAllocation.TabIndex = 60;
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnClose.Image = global::SA.Properties.Resources.Close_32;
            this.btnClose.Location = new System.Drawing.Point(993, 583);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(123, 48);
            this.btnClose.TabIndex = 68;
            this.btnClose.Text = "Close";
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Image = global::SA.Properties.Resources.batch_allocation_72;
            this.pictureBox1.Location = new System.Drawing.Point(483, 11);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(168, 174);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 59;
            this.pictureBox1.TabStop = false;
            // 
            // frmListBatchesAllocations
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1129, 633);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.tbFilterValue);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lbRecords);
            this.Controls.Add(this.cbFilterBy);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvBatchesAllocation);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmListBatchesAllocations";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Batches Allocations List";
            this.Load += new System.EventHandler(this.frmBatchesAllocationList_Load);
            this.cmsBatches.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBatchesAllocation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem programInfoToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem batchInfoToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip cmsBatches;
        private System.Windows.Forms.TextBox tbFilterValue;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbRecords;
        private System.Windows.Forms.ComboBox cbFilterBy;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvBatchesAllocation;
    }
}