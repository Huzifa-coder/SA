namespace SA.Batches
{
    partial class frmSelectBatch
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
            this.dgvBatches = new System.Windows.Forms.DataGridView();
            this.btnAddNewBatch = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSelect = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBatches)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvBatches
            // 
            this.dgvBatches.AllowUserToAddRows = false;
            this.dgvBatches.AllowUserToDeleteRows = false;
            this.dgvBatches.AllowUserToResizeColumns = false;
            this.dgvBatches.AllowUserToResizeRows = false;
            this.dgvBatches.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBatches.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvBatches.BackgroundColor = System.Drawing.Color.White;
            this.dgvBatches.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvBatches.ColumnHeadersHeight = 29;
            this.dgvBatches.Location = new System.Drawing.Point(6, 102);
            this.dgvBatches.Margin = new System.Windows.Forms.Padding(2);
            this.dgvBatches.MultiSelect = false;
            this.dgvBatches.Name = "dgvBatches";
            this.dgvBatches.ReadOnly = true;
            this.dgvBatches.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvBatches.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dgvBatches.RowTemplate.Height = 24;
            this.dgvBatches.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBatches.Size = new System.Drawing.Size(1413, 414);
            this.dgvBatches.StandardTab = true;
            this.dgvBatches.TabIndex = 51;
            this.dgvBatches.DoubleClick += new System.EventHandler(this.dgvBatches_DoubleClick);
            // 
            // btnAddNewBatch
            // 
            this.btnAddNewBatch.Image = global::SA.Properties.Resources.batch_add;
            this.btnAddNewBatch.Location = new System.Drawing.Point(1357, 53);
            this.btnAddNewBatch.Margin = new System.Windows.Forms.Padding(2);
            this.btnAddNewBatch.Name = "btnAddNewBatch";
            this.btnAddNewBatch.Size = new System.Drawing.Size(62, 45);
            this.btnAddNewBatch.TabIndex = 55;
            this.btnAddNewBatch.UseVisualStyleBackColor = true;
            this.btnAddNewBatch.Click += new System.EventHandler(this.btnAddNewBatch_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F);
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(479, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(467, 37);
            this.label1.TabIndex = 56;
            this.label1.Text = "Select A Batch For The Student";
            // 
            // btnSelect
            // 
            this.btnSelect.Image = global::SA.Properties.Resources.Save_32;
            this.btnSelect.Location = new System.Drawing.Point(1320, 522);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(99, 50);
            this.btnSelect.TabIndex = 57;
            this.btnSelect.Text = "Select";
            this.btnSelect.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // frmSelectBatch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1430, 584);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAddNewBatch);
            this.Controls.Add(this.dgvBatches);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmSelectBatch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmSelectBatch";
            this.Load += new System.EventHandler(this.frmSelectBatch_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBatches)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvBatches;
        private System.Windows.Forms.Button btnAddNewBatch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSelect;
    }
}