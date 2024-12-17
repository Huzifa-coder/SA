namespace SA.Students
{
    partial class frmAddEditStudent
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
            this.tcStudent = new System.Windows.Forms.TabControl();
            this.tpPersonInfo = new System.Windows.Forms.TabPage();
            this.btnNext = new System.Windows.Forms.Button();
            this.ctrlPersonInfoWithFilter1 = new SA.People.Controls.ctrlPersonInfoWithFilter();
            this.tpStudentInfo = new System.Windows.Forms.TabPage();
            this.btnSelectBatch = new System.Windows.Forms.Button();
            this.lbCreatedBy = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.lbStudentID = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tbEmail = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.tbPhone = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.tcStudent.SuspendLayout();
            this.tpPersonInfo.SuspendLayout();
            this.tpStudentInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // tcStudent
            // 
            this.tcStudent.Controls.Add(this.tpPersonInfo);
            this.tcStudent.Controls.Add(this.tpStudentInfo);
            this.tcStudent.Location = new System.Drawing.Point(7, 92);
            this.tcStudent.Margin = new System.Windows.Forms.Padding(4);
            this.tcStudent.Name = "tcStudent";
            this.tcStudent.SelectedIndex = 0;
            this.tcStudent.Size = new System.Drawing.Size(607, 398);
            this.tcStudent.TabIndex = 0;
            // 
            // tpPersonInfo
            // 
            this.tpPersonInfo.Controls.Add(this.btnNext);
            this.tpPersonInfo.Controls.Add(this.ctrlPersonInfoWithFilter1);
            this.tpPersonInfo.Location = new System.Drawing.Point(4, 25);
            this.tpPersonInfo.Margin = new System.Windows.Forms.Padding(4);
            this.tpPersonInfo.Name = "tpPersonInfo";
            this.tpPersonInfo.Padding = new System.Windows.Forms.Padding(4);
            this.tpPersonInfo.Size = new System.Drawing.Size(599, 369);
            this.tpPersonInfo.TabIndex = 0;
            this.tpPersonInfo.Text = "Person Info";
            this.tpPersonInfo.UseVisualStyleBackColor = true;
            // 
            // btnNext
            // 
            this.btnNext.Enabled = false;
            this.btnNext.Image = global::SA.Properties.Resources.Next_32;
            this.btnNext.Location = new System.Drawing.Point(493, 312);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(99, 50);
            this.btnNext.TabIndex = 7;
            this.btnNext.Text = "Next";
            this.btnNext.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // ctrlPersonInfoWithFilter1
            // 
            this.ctrlPersonInfoWithFilter1.AutoSize = true;
            this.ctrlPersonInfoWithFilter1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ctrlPersonInfoWithFilter1.FilterEnabled = true;
            this.ctrlPersonInfoWithFilter1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.ctrlPersonInfoWithFilter1.Location = new System.Drawing.Point(8, 36);
            this.ctrlPersonInfoWithFilter1.Margin = new System.Windows.Forms.Padding(4);
            this.ctrlPersonInfoWithFilter1.Name = "ctrlPersonInfoWithFilter1";
            this.ctrlPersonInfoWithFilter1.Size = new System.Drawing.Size(589, 269);
            this.ctrlPersonInfoWithFilter1.TabIndex = 0;
            this.ctrlPersonInfoWithFilter1.OnPersonSelected += new System.Action<int>(this.ctrlPersonInfoWithFilter1_OnPersonSelected);
            // 
            // tpStudentInfo
            // 
            this.tpStudentInfo.Controls.Add(this.btnSelectBatch);
            this.tpStudentInfo.Controls.Add(this.lbCreatedBy);
            this.tpStudentInfo.Controls.Add(this.label9);
            this.tpStudentInfo.Controls.Add(this.label6);
            this.tpStudentInfo.Controls.Add(this.pictureBox5);
            this.tpStudentInfo.Controls.Add(this.lbStudentID);
            this.tpStudentInfo.Controls.Add(this.label5);
            this.tpStudentInfo.Controls.Add(this.tbEmail);
            this.tpStudentInfo.Controls.Add(this.label4);
            this.tpStudentInfo.Controls.Add(this.pictureBox3);
            this.tpStudentInfo.Controls.Add(this.tbPhone);
            this.tpStudentInfo.Controls.Add(this.label8);
            this.tpStudentInfo.Controls.Add(this.pictureBox4);
            this.tpStudentInfo.Location = new System.Drawing.Point(4, 25);
            this.tpStudentInfo.Margin = new System.Windows.Forms.Padding(4);
            this.tpStudentInfo.Name = "tpStudentInfo";
            this.tpStudentInfo.Padding = new System.Windows.Forms.Padding(4);
            this.tpStudentInfo.Size = new System.Drawing.Size(599, 369);
            this.tpStudentInfo.TabIndex = 1;
            this.tpStudentInfo.Text = "Student Info";
            this.tpStudentInfo.UseVisualStyleBackColor = true;
            // 
            // btnSelectBatch
            // 
            this.btnSelectBatch.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSelectBatch.Location = new System.Drawing.Point(123, 179);
            this.btnSelectBatch.Name = "btnSelectBatch";
            this.btnSelectBatch.Size = new System.Drawing.Size(277, 23);
            this.btnSelectBatch.TabIndex = 65;
            this.btnSelectBatch.Text = "Select Batch";
            this.btnSelectBatch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSelectBatch.UseVisualStyleBackColor = true;
            this.btnSelectBatch.Click += new System.EventHandler(this.btnSelectBatch_Click);
            // 
            // lbCreatedBy
            // 
            this.lbCreatedBy.AutoSize = true;
            this.lbCreatedBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lbCreatedBy.Location = new System.Drawing.Point(114, 238);
            this.lbCreatedBy.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbCreatedBy.Name = "lbCreatedBy";
            this.lbCreatedBy.Size = new System.Drawing.Size(35, 20);
            this.lbCreatedBy.TabIndex = 79;
            this.lbCreatedBy.Text = "N/A";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label9.Location = new System.Drawing.Point(15, 238);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(100, 20);
            this.label9.TabIndex = 78;
            this.label9.Text = "Created By : ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label6.Location = new System.Drawing.Point(13, 179);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 20);
            this.label6.TabIndex = 76;
            this.label6.Text = "Batch : ";
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = global::SA.Properties.Resources.batch;
            this.pictureBox5.Location = new System.Drawing.Point(83, 173);
            this.pictureBox5.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(32, 32);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox5.TabIndex = 77;
            this.pictureBox5.TabStop = false;
            // 
            // lbStudentID
            // 
            this.lbStudentID.AutoSize = true;
            this.lbStudentID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lbStudentID.Location = new System.Drawing.Point(107, 23);
            this.lbStudentID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbStudentID.Name = "lbStudentID";
            this.lbStudentID.Size = new System.Drawing.Size(35, 20);
            this.lbStudentID.TabIndex = 74;
            this.lbStudentID.Text = "N/A";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label5.Location = new System.Drawing.Point(8, 23);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(99, 20);
            this.label5.TabIndex = 73;
            this.label5.Text = "Student ID : ";
            // 
            // tbEmail
            // 
            this.tbEmail.Location = new System.Drawing.Point(123, 124);
            this.tbEmail.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbEmail.Name = "tbEmail";
            this.tbEmail.Size = new System.Drawing.Size(277, 23);
            this.tbEmail.TabIndex = 64;
            this.tbEmail.Validating += new System.ComponentModel.CancelEventHandler(this.tbEmail_Validating);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label4.Location = new System.Drawing.Point(15, 125);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 20);
            this.label4.TabIndex = 67;
            this.label4.Text = "Email : ";
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::SA.Properties.Resources.Email;
            this.pictureBox3.Location = new System.Drawing.Point(83, 119);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(32, 32);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 68;
            this.pictureBox3.TabStop = false;
            // 
            // tbPhone
            // 
            this.tbPhone.Location = new System.Drawing.Point(123, 70);
            this.tbPhone.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbPhone.Name = "tbPhone";
            this.tbPhone.Size = new System.Drawing.Size(277, 23);
            this.tbPhone.TabIndex = 63;
            this.tbPhone.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbPhone_KeyPress);
            this.tbPhone.Validating += new System.ComponentModel.CancelEventHandler(this.tbPhone_Validating);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label8.Location = new System.Drawing.Point(8, 71);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(67, 20);
            this.label8.TabIndex = 61;
            this.label8.Text = "Phone : ";
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::SA.Properties.Resources.Number_32;
            this.pictureBox4.Location = new System.Drawing.Point(83, 65);
            this.pictureBox4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(32, 32);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox4.TabIndex = 62;
            this.pictureBox4.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F);
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(169, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(267, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "Add New Student";
            // 
            // btnSave
            // 
            this.btnSave.Image = global::SA.Properties.Resources.Save_32;
            this.btnSave.Location = new System.Drawing.Point(511, 497);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(99, 50);
            this.btnSave.TabIndex = 67;
            this.btnSave.Text = "Save";
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Image = global::SA.Properties.Resources.Close_32;
            this.btnCancel.Location = new System.Drawing.Point(406, 497);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(99, 50);
            this.btnCancel.TabIndex = 66;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // frmAddEditStudent
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(621, 559);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tcStudent);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmAddEditStudent";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add Student";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmAddEditStudent_FormClosing);
            this.Load += new System.EventHandler(this.frmAddEditStudent_Load);
            this.tcStudent.ResumeLayout(false);
            this.tpPersonInfo.ResumeLayout(false);
            this.tpPersonInfo.PerformLayout();
            this.tpStudentInfo.ResumeLayout(false);
            this.tpStudentInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tcStudent;
        private System.Windows.Forms.TabPage tpPersonInfo;
        private People.Controls.ctrlPersonInfoWithFilter ctrlPersonInfoWithFilter1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TabPage tpStudentInfo;
        private System.Windows.Forms.TextBox tbEmail;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.TextBox tbPhone;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Label lbStudentID;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnSelectBatch;
        private System.Windows.Forms.Label lbCreatedBy;
    }
}