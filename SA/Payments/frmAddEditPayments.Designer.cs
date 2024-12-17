namespace SA.Payments
{
    partial class frmAddEditPayments
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
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.tbPaidAmount = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lbCourseID = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.lbTitle = new System.Windows.Forms.Label();
            this.dtpDuaDate = new System.Windows.Forms.DateTimePicker();
            this.tbCourseFees = new System.Windows.Forms.TextBox();
            this.lbCourseFees = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.SuspendLayout();
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // tbPaidAmount
            // 
            this.tbPaidAmount.Location = new System.Drawing.Point(167, 196);
            this.tbPaidAmount.Name = "tbPaidAmount";
            this.tbPaidAmount.Size = new System.Drawing.Size(289, 20);
            this.tbPaidAmount.TabIndex = 2;
            this.tbPaidAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbPaidAmount_KeyPress);
            this.tbPaidAmount.Validating += new System.ComponentModel.CancelEventHandler(this.tbPaidAmount_Validating);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Image = global::SA.Properties.Resources.Close_32;
            this.btnCancel.Location = new System.Drawing.Point(252, 309);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(99, 50);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Image = global::SA.Properties.Resources.Save_32;
            this.btnSave.Location = new System.Drawing.Point(357, 309);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(99, 50);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Save";
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label3.Location = new System.Drawing.Point(8, 139);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 20);
            this.label3.TabIndex = 113;
            this.label3.Text = "Course Fees : ";
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::SA.Properties.Resources.money_32;
            this.pictureBox3.Location = new System.Drawing.Point(125, 133);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(32, 32);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 114;
            this.pictureBox3.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label2.Location = new System.Drawing.Point(34, 255);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 20);
            this.label2.TabIndex = 111;
            this.label2.Text = "Dua Date :";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::SA.Properties.Resources.Calendar_32;
            this.pictureBox2.Location = new System.Drawing.Point(125, 249);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(32, 32);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox2.TabIndex = 112;
            this.pictureBox2.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.Location = new System.Drawing.Point(8, 197);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 20);
            this.label1.TabIndex = 109;
            this.label1.Text = "Paid Amount : ";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::SA.Properties.Resources.money_32;
            this.pictureBox1.Location = new System.Drawing.Point(125, 191);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 32);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 110;
            this.pictureBox1.TabStop = false;
            // 
            // lbCourseID
            // 
            this.lbCourseID.AutoSize = true;
            this.lbCourseID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lbCourseID.Location = new System.Drawing.Point(167, 81);
            this.lbCourseID.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lbCourseID.Name = "lbCourseID";
            this.lbCourseID.Size = new System.Drawing.Size(35, 20);
            this.lbCourseID.TabIndex = 108;
            this.lbCourseID.Text = "N/A";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label8.Location = new System.Drawing.Point(16, 81);
            this.label8.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(104, 20);
            this.label8.TabIndex = 106;
            this.label8.Text = "Payment ID : ";
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::SA.Properties.Resources.Number_32;
            this.pictureBox4.Location = new System.Drawing.Point(125, 75);
            this.pictureBox4.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(32, 32);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox4.TabIndex = 107;
            this.pictureBox4.TabStop = false;
            // 
            // lbTitle
            // 
            this.lbTitle.AutoSize = true;
            this.lbTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F);
            this.lbTitle.ForeColor = System.Drawing.Color.Red;
            this.lbTitle.Location = new System.Drawing.Point(131, 9);
            this.lbTitle.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(209, 37);
            this.lbTitle.TabIndex = 105;
            this.lbTitle.Text = "Add Payment";
            // 
            // dtpDuaDate
            // 
            this.dtpDuaDate.Checked = false;
            this.dtpDuaDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDuaDate.Location = new System.Drawing.Point(167, 261);
            this.dtpDuaDate.Name = "dtpDuaDate";
            this.dtpDuaDate.Size = new System.Drawing.Size(289, 20);
            this.dtpDuaDate.TabIndex = 3;
            // 
            // tbCourseFees
            // 
            this.tbCourseFees.Location = new System.Drawing.Point(167, 139);
            this.tbCourseFees.Name = "tbCourseFees";
            this.tbCourseFees.Size = new System.Drawing.Size(289, 20);
            this.tbCourseFees.TabIndex = 1;
            // 
            // lbCourseFees
            // 
            this.lbCourseFees.AutoSize = true;
            this.lbCourseFees.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lbCourseFees.Location = new System.Drawing.Point(167, 139);
            this.lbCourseFees.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lbCourseFees.Name = "lbCourseFees";
            this.lbCourseFees.Size = new System.Drawing.Size(35, 20);
            this.lbCourseFees.TabIndex = 116;
            this.lbCourseFees.Text = "N/A";
            // 
            // frmAddEditPayments
            // 
            this.AcceptButton = this.btnSave;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(492, 365);
            this.Controls.Add(this.lbCourseFees);
            this.Controls.Add(this.tbCourseFees);
            this.Controls.Add(this.dtpDuaDate);
            this.Controls.Add(this.tbPaidAmount);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lbCourseID);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.lbTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmAddEditPayments";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add Payment";
            this.Load += new System.EventHandler(this.frmAddEditPayments_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.TextBox tbPaidAmount;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lbCourseID;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Label lbTitle;
        private System.Windows.Forms.DateTimePicker dtpDuaDate;
        private System.Windows.Forms.TextBox tbCourseFees;
        private System.Windows.Forms.Label lbCourseFees;
    }
}