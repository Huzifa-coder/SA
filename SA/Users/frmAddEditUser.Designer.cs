namespace SA.Users
{
    partial class frmAddEditUser
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
            this.lbTitle = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.tpUser = new System.Windows.Forms.TabPage();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.tbUserID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label8 = new System.Windows.Forms.Label();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.tpPerson = new System.Windows.Forms.TabPage();
            this.ctrlPersonInfoWithFilter1 = new SA.People.Controls.ctrlPersonInfoWithFilter();
            this.btnNext = new System.Windows.Forms.Button();
            this.tcUser = new System.Windows.Forms.TabControl();
            this.rbAdmin = new System.Windows.Forms.RadioButton();
            this.rbSaleman = new System.Windows.Forms.RadioButton();
            this.rbTutor = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.tpUser.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.tpPerson.SuspendLayout();
            this.tcUser.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbTitle
            // 
            this.lbTitle.AutoSize = true;
            this.lbTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F);
            this.lbTitle.ForeColor = System.Drawing.Color.Red;
            this.lbTitle.Location = new System.Drawing.Point(210, 35);
            this.lbTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(151, 37);
            this.lbTitle.TabIndex = 23;
            this.lbTitle.Text = "Add User";
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Image = global::SA.Properties.Resources.Close_32;
            this.btnCancel.Location = new System.Drawing.Point(416, 457);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(99, 50);
            this.btnCancel.TabIndex = 25;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Image = global::SA.Properties.Resources.Save_32;
            this.btnSave.Location = new System.Drawing.Point(521, 457);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(99, 50);
            this.btnSave.TabIndex = 24;
            this.btnSave.Text = "Save";
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // tpUser
            // 
            this.tpUser.Controls.Add(this.rbTutor);
            this.tpUser.Controls.Add(this.rbSaleman);
            this.tpUser.Controls.Add(this.rbAdmin);
            this.tpUser.Controls.Add(this.pictureBox2);
            this.tpUser.Controls.Add(this.label2);
            this.tpUser.Controls.Add(this.tbPassword);
            this.tpUser.Controls.Add(this.tbUserID);
            this.tpUser.Controls.Add(this.label1);
            this.tpUser.Controls.Add(this.pictureBox1);
            this.tpUser.Controls.Add(this.label8);
            this.tpUser.Controls.Add(this.pictureBox4);
            this.tpUser.Location = new System.Drawing.Point(4, 25);
            this.tpUser.Name = "tpUser";
            this.tpUser.Padding = new System.Windows.Forms.Padding(3);
            this.tpUser.Size = new System.Drawing.Size(600, 347);
            this.tpUser.TabIndex = 1;
            this.tpUser.Tag = "5";
            this.tpUser.Text = "User Info";
            this.tpUser.UseVisualStyleBackColor = true;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::SA.Properties.Resources.PersonDetails_32;
            this.pictureBox2.Location = new System.Drawing.Point(139, 190);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(32, 32);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox2.TabIndex = 62;
            this.pictureBox2.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label2.Location = new System.Drawing.Point(25, 196);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 20);
            this.label2.TabIndex = 61;
            this.label2.Text = "Permissions : ";
            // 
            // tbPassword
            // 
            this.tbPassword.Location = new System.Drawing.Point(179, 117);
            this.tbPassword.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.PasswordChar = '*';
            this.tbPassword.Size = new System.Drawing.Size(277, 23);
            this.tbPassword.TabIndex = 60;
            this.tbPassword.Validating += new System.ComponentModel.CancelEventHandler(this.tbPassword_Validating);
            // 
            // tbUserID
            // 
            this.tbUserID.Location = new System.Drawing.Point(179, 38);
            this.tbUserID.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbUserID.Name = "tbUserID";
            this.tbUserID.Size = new System.Drawing.Size(277, 23);
            this.tbUserID.TabIndex = 55;
            this.tbUserID.Validating += new System.ComponentModel.CancelEventHandler(this.tbUserID_Validating);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.Location = new System.Drawing.Point(41, 118);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 20);
            this.label1.TabIndex = 58;
            this.label1.Text = "Password : ";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::SA.Properties.Resources.Password_32;
            this.pictureBox1.Location = new System.Drawing.Point(139, 112);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 32);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 59;
            this.pictureBox1.TabStop = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label8.Location = new System.Drawing.Point(55, 38);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(76, 20);
            this.label8.TabIndex = 52;
            this.label8.Text = "User ID : ";
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::SA.Properties.Resources.Number_32;
            this.pictureBox4.Location = new System.Drawing.Point(139, 32);
            this.pictureBox4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(32, 32);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox4.TabIndex = 53;
            this.pictureBox4.TabStop = false;
            // 
            // tpPerson
            // 
            this.tpPerson.Controls.Add(this.ctrlPersonInfoWithFilter1);
            this.tpPerson.Controls.Add(this.btnNext);
            this.tpPerson.Location = new System.Drawing.Point(4, 25);
            this.tpPerson.Name = "tpPerson";
            this.tpPerson.Padding = new System.Windows.Forms.Padding(3);
            this.tpPerson.Size = new System.Drawing.Size(600, 347);
            this.tpPerson.TabIndex = 0;
            this.tpPerson.Text = "Person Info";
            this.tpPerson.UseVisualStyleBackColor = true;
            // 
            // ctrlPersonInfoWithFilter1
            // 
            this.ctrlPersonInfoWithFilter1.AutoSize = true;
            this.ctrlPersonInfoWithFilter1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ctrlPersonInfoWithFilter1.BtnAddEnabled = true;
            this.ctrlPersonInfoWithFilter1.BtnSearchEnabled = true;
            this.ctrlPersonInfoWithFilter1.FilterEnabled = true;
            this.ctrlPersonInfoWithFilter1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.ctrlPersonInfoWithFilter1.Location = new System.Drawing.Point(0, 0);
            this.ctrlPersonInfoWithFilter1.Margin = new System.Windows.Forms.Padding(4);
            this.ctrlPersonInfoWithFilter1.Name = "ctrlPersonInfoWithFilter1";
            this.ctrlPersonInfoWithFilter1.Size = new System.Drawing.Size(589, 269);
            this.ctrlPersonInfoWithFilter1.TabIndex = 1;
            this.ctrlPersonInfoWithFilter1.OnPersonSelected += new System.Action<int>(this.ctrlPersonInfoWithFilter1_OnPersonSelected);
            // 
            // btnNext
            // 
            this.btnNext.Enabled = false;
            this.btnNext.Image = global::SA.Properties.Resources.Next_32;
            this.btnNext.Location = new System.Drawing.Point(495, 284);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(99, 50);
            this.btnNext.TabIndex = 0;
            this.btnNext.Text = "Next";
            this.btnNext.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // tcUser
            // 
            this.tcUser.Controls.Add(this.tpPerson);
            this.tcUser.Controls.Add(this.tpUser);
            this.tcUser.Location = new System.Drawing.Point(12, 75);
            this.tcUser.Name = "tcUser";
            this.tcUser.SelectedIndex = 0;
            this.tcUser.Size = new System.Drawing.Size(608, 376);
            this.tcUser.TabIndex = 26;
            // 
            // rbAdmin
            // 
            this.rbAdmin.AutoSize = true;
            this.rbAdmin.Location = new System.Drawing.Point(178, 196);
            this.rbAdmin.Name = "rbAdmin";
            this.rbAdmin.Size = new System.Drawing.Size(65, 21);
            this.rbAdmin.TabIndex = 68;
            this.rbAdmin.TabStop = true;
            this.rbAdmin.Text = "Admin";
            this.rbAdmin.UseVisualStyleBackColor = true;
            // 
            // rbSaleman
            // 
            this.rbSaleman.AutoSize = true;
            this.rbSaleman.Location = new System.Drawing.Point(250, 196);
            this.rbSaleman.Name = "rbSaleman";
            this.rbSaleman.Size = new System.Drawing.Size(81, 21);
            this.rbSaleman.TabIndex = 69;
            this.rbSaleman.TabStop = true;
            this.rbSaleman.Text = "Saleman";
            this.rbSaleman.UseVisualStyleBackColor = true;
            // 
            // rbTutor
            // 
            this.rbTutor.AutoSize = true;
            this.rbTutor.Location = new System.Drawing.Point(338, 196);
            this.rbTutor.Name = "rbTutor";
            this.rbTutor.Size = new System.Drawing.Size(60, 21);
            this.rbTutor.TabIndex = 70;
            this.rbTutor.TabStop = true;
            this.rbTutor.Text = "Tutor";
            this.rbTutor.UseVisualStyleBackColor = true;
            // 
            // frmAddEditUser
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(632, 521);
            this.Controls.Add(this.tcUser);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lbTitle);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmAddEditUser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add User";
            this.Load += new System.EventHandler(this.frmAddEditUser_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.tpUser.ResumeLayout(false);
            this.tpUser.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.tpPerson.ResumeLayout(false);
            this.tpPerson.PerformLayout();
            this.tcUser.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lbTitle;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.TabControl tcUser;
        private System.Windows.Forms.TabPage tpPerson;
        private People.Controls.ctrlPersonInfoWithFilter ctrlPersonInfoWithFilter1;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.TabPage tpUser;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.TextBox tbUserID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.RadioButton rbTutor;
        private System.Windows.Forms.RadioButton rbSaleman;
        private System.Windows.Forms.RadioButton rbAdmin;
    }
}