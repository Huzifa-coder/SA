namespace SA.People.Controls
{
    partial class ctrlPersonInfoWithFilter
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.gbFilter = new System.Windows.Forms.GroupBox();
            this.btnAddNewPerson = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.tbPersonID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ctrlPersonInfo1 = new SA.People.Controls.ctrlPersonInfo();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.gbFilter.SuspendLayout();
            this.SuspendLayout();
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // gbFilter
            // 
            this.gbFilter.Controls.Add(this.btnAddNewPerson);
            this.gbFilter.Controls.Add(this.btnSearch);
            this.gbFilter.Controls.Add(this.tbPersonID);
            this.gbFilter.Controls.Add(this.label2);
            this.gbFilter.Location = new System.Drawing.Point(4, 3);
            this.gbFilter.Name = "gbFilter";
            this.gbFilter.Size = new System.Drawing.Size(430, 87);
            this.gbFilter.TabIndex = 1;
            this.gbFilter.TabStop = false;
            this.gbFilter.Text = "Filter : ";
            // 
            // btnAddNewPerson
            // 
            this.btnAddNewPerson.Image = global::SA.Properties.Resources.Add_Person_40;
            this.btnAddNewPerson.Location = new System.Drawing.Point(370, 23);
            this.btnAddNewPerson.Margin = new System.Windows.Forms.Padding(2);
            this.btnAddNewPerson.Name = "btnAddNewPerson";
            this.btnAddNewPerson.Size = new System.Drawing.Size(50, 47);
            this.btnAddNewPerson.TabIndex = 47;
            this.btnAddNewPerson.UseVisualStyleBackColor = true;
            this.btnAddNewPerson.Click += new System.EventHandler(this.btnAddNewPerson_Click_1);
            // 
            // btnSearch
            // 
            this.btnSearch.Image = global::SA.Properties.Resources.SearchPerson;
            this.btnSearch.Location = new System.Drawing.Point(316, 23);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(2);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(50, 47);
            this.btnSearch.TabIndex = 46;
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // tbPersonID
            // 
            this.tbPersonID.Location = new System.Drawing.Point(119, 35);
            this.tbPersonID.Name = "tbPersonID";
            this.tbPersonID.Size = new System.Drawing.Size(193, 26);
            this.tbPersonID.TabIndex = 44;
            this.tbPersonID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbPersonID_KeyPress);
            this.tbPersonID.Validating += new System.ComponentModel.CancelEventHandler(this.tbPersonID_Validating);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label2.Location = new System.Drawing.Point(6, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 29);
            this.label2.TabIndex = 45;
            this.label2.Text = "Person ID : ";
            // 
            // ctrlPersonInfo1
            // 
            this.ctrlPersonInfo1.AutoSize = true;
            this.ctrlPersonInfo1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ctrlPersonInfo1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.ctrlPersonInfo1.Location = new System.Drawing.Point(4, 97);
            this.ctrlPersonInfo1.Margin = new System.Windows.Forms.Padding(4);
            this.ctrlPersonInfo1.Name = "ctrlPersonInfo1";
            this.ctrlPersonInfo1.Size = new System.Drawing.Size(581, 168);
            this.ctrlPersonInfo1.TabIndex = 0;
            // 
            // ctrlPersonInfoWithFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.gbFilter);
            this.Controls.Add(this.ctrlPersonInfo1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ctrlPersonInfoWithFilter";
            this.Size = new System.Drawing.Size(589, 269);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.gbFilter.ResumeLayout(false);
            this.gbFilter.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private ctrlPersonInfo ctrlPersonInfo1;
        private System.Windows.Forms.GroupBox gbFilter;
        private System.Windows.Forms.TextBox tbPersonID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnAddNewPerson;
    }
}
