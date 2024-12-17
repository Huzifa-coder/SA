namespace SA.Tutors
{
    partial class frmAddEditTutor
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpPerson = new System.Windows.Forms.TabPage();
            this.btnNext = new System.Windows.Forms.Button();
            this.ctrlPersonInfoWithFilter1 = new SA.People.Controls.ctrlPersonInfoWithFilter();
            this.tpTutor = new System.Windows.Forms.TabPage();
            this.tbPhone = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.lbTutorID = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.lbTitle = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.tabControl1.SuspendLayout();
            this.tpPerson.SuspendLayout();
            this.tpTutor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tpPerson);
            this.tabControl1.Controls.Add(this.tpTutor);
            this.tabControl1.Location = new System.Drawing.Point(13, 95);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(607, 365);
            this.tabControl1.TabIndex = 0;
            // 
            // tpPerson
            // 
            this.tpPerson.Controls.Add(this.btnNext);
            this.tpPerson.Controls.Add(this.ctrlPersonInfoWithFilter1);
            this.tpPerson.Location = new System.Drawing.Point(4, 29);
            this.tpPerson.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tpPerson.Name = "tpPerson";
            this.tpPerson.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tpPerson.Size = new System.Drawing.Size(599, 332);
            this.tpPerson.TabIndex = 0;
            this.tpPerson.Text = "Person Info";
            this.tpPerson.UseVisualStyleBackColor = true;
            // 
            // btnNext
            // 
            this.btnNext.Enabled = false;
            this.btnNext.Image = global::SA.Properties.Resources.Next_32;
            this.btnNext.Location = new System.Drawing.Point(490, 276);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(99, 50);
            this.btnNext.TabIndex = 27;
            this.btnNext.Text = "Next";
            this.btnNext.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // ctrlPersonInfoWithFilter1
            // 
            this.ctrlPersonInfoWithFilter1.AutoSize = true;
            this.ctrlPersonInfoWithFilter1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ctrlPersonInfoWithFilter1.BtnAddEnabled = true;
            this.ctrlPersonInfoWithFilter1.BtnSearchEnabled = true;
            this.ctrlPersonInfoWithFilter1.FilterEnabled = true;
            this.ctrlPersonInfoWithFilter1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.ctrlPersonInfoWithFilter1.Location = new System.Drawing.Point(5, 6);
            this.ctrlPersonInfoWithFilter1.Margin = new System.Windows.Forms.Padding(4);
            this.ctrlPersonInfoWithFilter1.Name = "ctrlPersonInfoWithFilter1";
            this.ctrlPersonInfoWithFilter1.Size = new System.Drawing.Size(589, 269);
            this.ctrlPersonInfoWithFilter1.TabIndex = 1;
            this.ctrlPersonInfoWithFilter1.OnPersonSelected += new System.Action<int>(this.ctrlPersonInfoWithFilter1_OnPersonSelected);
            // 
            // tpTutor
            // 
            this.tpTutor.Controls.Add(this.tbPhone);
            this.tpTutor.Controls.Add(this.label3);
            this.tpTutor.Controls.Add(this.pictureBox2);
            this.tpTutor.Controls.Add(this.lbTutorID);
            this.tpTutor.Controls.Add(this.label8);
            this.tpTutor.Controls.Add(this.pictureBox4);
            this.tpTutor.Location = new System.Drawing.Point(4, 29);
            this.tpTutor.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tpTutor.Name = "tpTutor";
            this.tpTutor.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tpTutor.Size = new System.Drawing.Size(599, 332);
            this.tpTutor.TabIndex = 1;
            this.tpTutor.Text = "Tutor Info";
            this.tpTutor.UseVisualStyleBackColor = true;
            // 
            // tbPhone
            // 
            this.tbPhone.Location = new System.Drawing.Point(165, 115);
            this.tbPhone.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbPhone.Name = "tbPhone";
            this.tbPhone.Size = new System.Drawing.Size(277, 26);
            this.tbPhone.TabIndex = 4;
            this.tbPhone.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbPhone_KeyPress);
            this.tbPhone.Validating += new System.ComponentModel.CancelEventHandler(this.tbPhone_Validating);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label3.Location = new System.Drawing.Point(50, 118);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 20);
            this.label3.TabIndex = 67;
            this.label3.Text = "Phone : ";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::SA.Properties.Resources.Password_32;
            this.pictureBox2.Location = new System.Drawing.Point(125, 112);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(32, 32);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox2.TabIndex = 68;
            this.pictureBox2.TabStop = false;
            // 
            // lbTutorID
            // 
            this.lbTutorID.AutoSize = true;
            this.lbTutorID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lbTutorID.Location = new System.Drawing.Point(165, 49);
            this.lbTutorID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbTutorID.Name = "lbTutorID";
            this.lbTutorID.Size = new System.Drawing.Size(35, 20);
            this.lbTutorID.TabIndex = 66;
            this.lbTutorID.Text = "N/A";
            this.lbTutorID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label8.Location = new System.Drawing.Point(38, 49);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(79, 20);
            this.label8.TabIndex = 61;
            this.label8.Text = "Tutor ID : ";
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::SA.Properties.Resources.Number_32;
            this.pictureBox4.Location = new System.Drawing.Point(125, 43);
            this.pictureBox4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(32, 32);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox4.TabIndex = 62;
            this.pictureBox4.TabStop = false;
            // 
            // lbTitle
            // 
            this.lbTitle.AutoSize = true;
            this.lbTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F);
            this.lbTitle.ForeColor = System.Drawing.Color.Red;
            this.lbTitle.Location = new System.Drawing.Point(236, 38);
            this.lbTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(160, 37);
            this.lbTitle.TabIndex = 14;
            this.lbTitle.Text = "Add Tutor";
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Image = global::SA.Properties.Resources.Close_32;
            this.btnClose.Location = new System.Drawing.Point(412, 468);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(99, 50);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "Close";
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Image = global::SA.Properties.Resources.Save_32;
            this.btnSave.Location = new System.Drawing.Point(517, 468);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(99, 50);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Save";
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // frmAddEditTutor
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(635, 530);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lbTitle);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmAddEditTutor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add Tutor";
            this.Load += new System.EventHandler(this.frmAddEditTutor_Load);
            this.tabControl1.ResumeLayout(false);
            this.tpPerson.ResumeLayout(false);
            this.tpPerson.PerformLayout();
            this.tpTutor.ResumeLayout(false);
            this.tpTutor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpPerson;
        private System.Windows.Forms.TabPage tpTutor;
        private System.Windows.Forms.Label lbTitle;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnNext;
        private People.Controls.ctrlPersonInfoWithFilter ctrlPersonInfoWithFilter1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lbTutorID;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.TextBox tbPhone;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}