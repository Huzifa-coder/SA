namespace SA
{
    partial class frmMain
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
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.msMain = new System.Windows.Forms.MenuStrip();
            this.studentListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usersListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.peopleListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tutorsListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.batchListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.coursesListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.domainToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.domainTypesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.domainsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.paymentsListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.accountSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.msMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(22, 19);
            this.toolStripMenuItem1.Text = " ";
            // 
            // msMain
            // 
            this.msMain.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.msMain.Dock = System.Windows.Forms.DockStyle.Left;
            this.msMain.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.msMain.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.msMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.studentListToolStripMenuItem,
            this.usersListToolStripMenuItem,
            this.peopleListToolStripMenuItem,
            this.tutorsListToolStripMenuItem,
            this.batchListToolStripMenuItem,
            this.coursesListToolStripMenuItem,
            this.domainToolStripMenuItem,
            this.paymentsListToolStripMenuItem,
            this.toolStripMenuItem1,
            this.accountSettingsToolStripMenuItem});
            this.msMain.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Table;
            this.msMain.Location = new System.Drawing.Point(0, 0);
            this.msMain.Name = "msMain";
            this.msMain.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.msMain.Size = new System.Drawing.Size(177, 749);
            this.msMain.TabIndex = 1;
            this.msMain.Text = "menuStrip1";
            // 
            // studentListToolStripMenuItem
            // 
            this.studentListToolStripMenuItem.Image = global::SA.Properties.Resources.Students;
            this.studentListToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.studentListToolStripMenuItem.Name = "studentListToolStripMenuItem";
            this.studentListToolStripMenuItem.Size = new System.Drawing.Size(129, 52);
            this.studentListToolStripMenuItem.Text = "Student List";
            this.studentListToolStripMenuItem.Click += new System.EventHandler(this.studentListToolStripMenuItem_Click);
            // 
            // usersListToolStripMenuItem
            // 
            this.usersListToolStripMenuItem.Image = global::SA.Properties.Resources.Users;
            this.usersListToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.usersListToolStripMenuItem.Name = "usersListToolStripMenuItem";
            this.usersListToolStripMenuItem.Size = new System.Drawing.Size(140, 76);
            this.usersListToolStripMenuItem.Text = "Users List";
            this.usersListToolStripMenuItem.Click += new System.EventHandler(this.usersListToolStripMenuItem_Click);
            // 
            // peopleListToolStripMenuItem
            // 
            this.peopleListToolStripMenuItem.Image = global::SA.Properties.Resources.People_64;
            this.peopleListToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.peopleListToolStripMenuItem.Name = "peopleListToolStripMenuItem";
            this.peopleListToolStripMenuItem.Size = new System.Drawing.Size(140, 68);
            this.peopleListToolStripMenuItem.Text = "People List";
            this.peopleListToolStripMenuItem.Click += new System.EventHandler(this.peopleListToolStripMenuItem_Click);
            // 
            // tutorsListToolStripMenuItem
            // 
            this.tutorsListToolStripMenuItem.Image = global::SA.Properties.Resources.Tutors;
            this.tutorsListToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tutorsListToolStripMenuItem.Name = "tutorsListToolStripMenuItem";
            this.tutorsListToolStripMenuItem.Size = new System.Drawing.Size(146, 76);
            this.tutorsListToolStripMenuItem.Text = "Tutors List";
            this.tutorsListToolStripMenuItem.Click += new System.EventHandler(this.tutorsListToolStripMenuItem_Click);
            // 
            // batchListToolStripMenuItem
            // 
            this.batchListToolStripMenuItem.Image = global::SA.Properties.Resources.batch;
            this.batchListToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.batchListToolStripMenuItem.Name = "batchListToolStripMenuItem";
            this.batchListToolStripMenuItem.Size = new System.Drawing.Size(132, 76);
            this.batchListToolStripMenuItem.Text = "Batches";
            this.batchListToolStripMenuItem.Click += new System.EventHandler(this.batchListToolStripMenuItem_Click);
            // 
            // coursesListToolStripMenuItem
            // 
            this.coursesListToolStripMenuItem.Image = global::SA.Properties.Resources.Courses;
            this.coursesListToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.coursesListToolStripMenuItem.Name = "coursesListToolStripMenuItem";
            this.coursesListToolStripMenuItem.Size = new System.Drawing.Size(163, 76);
            this.coursesListToolStripMenuItem.Text = "Programs List";
            this.coursesListToolStripMenuItem.Click += new System.EventHandler(this.programsListToolStripMenuItem_Click);
            // 
            // domainToolStripMenuItem
            // 
            this.domainToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.domainTypesToolStripMenuItem,
            this.domainsToolStripMenuItem});
            this.domainToolStripMenuItem.Image = global::SA.Properties.Resources.field;
            this.domainToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.domainToolStripMenuItem.Name = "domainToolStripMenuItem";
            this.domainToolStripMenuItem.Size = new System.Drawing.Size(133, 76);
            this.domainToolStripMenuItem.Text = "Domain";
            // 
            // domainTypesToolStripMenuItem
            // 
            this.domainTypesToolStripMenuItem.Image = global::SA.Properties.Resources.domain_type;
            this.domainTypesToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.domainTypesToolStripMenuItem.Name = "domainTypesToolStripMenuItem";
            this.domainTypesToolStripMenuItem.Size = new System.Drawing.Size(177, 78);
            this.domainTypesToolStripMenuItem.Text = "Types";
            this.domainTypesToolStripMenuItem.Click += new System.EventHandler(this.domainTypesToolStripMenuItem_Click);
            // 
            // domainsToolStripMenuItem
            // 
            this.domainsToolStripMenuItem.Image = global::SA.Properties.Resources.domains;
            this.domainsToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.domainsToolStripMenuItem.Name = "domainsToolStripMenuItem";
            this.domainsToolStripMenuItem.Size = new System.Drawing.Size(177, 78);
            this.domainsToolStripMenuItem.Text = "Domains";
            this.domainsToolStripMenuItem.Click += new System.EventHandler(this.domainsToolStripMenuItem_Click);
            // 
            // paymentsListToolStripMenuItem
            // 
            this.paymentsListToolStripMenuItem.Image = global::SA.Properties.Resources.payment;
            this.paymentsListToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.paymentsListToolStripMenuItem.Name = "paymentsListToolStripMenuItem";
            this.paymentsListToolStripMenuItem.Size = new System.Drawing.Size(164, 76);
            this.paymentsListToolStripMenuItem.Text = "Payments List";
            this.paymentsListToolStripMenuItem.Click += new System.EventHandler(this.paymentsListToolStripMenuItem_Click);
            // 
            // accountSettingsToolStripMenuItem
            // 
            this.accountSettingsToolStripMenuItem.Image = global::SA.Properties.Resources.settings;
            this.accountSettingsToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.accountSettingsToolStripMenuItem.Name = "accountSettingsToolStripMenuItem";
            this.accountSettingsToolStripMenuItem.Size = new System.Drawing.Size(174, 67);
            this.accountSettingsToolStripMenuItem.Text = "Account Settings";
            this.accountSettingsToolStripMenuItem.Click += new System.EventHandler(this.accountSettingsToolStripMenuItem_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1227, 749);
            this.Controls.Add(this.msMain);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.msMain;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMain_FormClosed);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmMain_KeyPress);
            this.msMain.ResumeLayout(false);
            this.msMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripMenuItem usersListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem peopleListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem batchListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem coursesListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem paymentsListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.MenuStrip msMain;
        private System.Windows.Forms.ToolStripMenuItem studentListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem accountSettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem domainToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem domainTypesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem domainsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tutorsListToolStripMenuItem;
    }
}

