
using BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static BusinessLayer.clsUser;

namespace SA.Users
{
    public partial class frmAddEditUser : Form
    {
        enum enMode { Add, Update }

        enMode _Mode = enMode.Add;

        private string _UserID = string.Empty;
        private clsUser _User = new clsUser();

        public frmAddEditUser()
        {
            InitializeComponent();
            _Mode = enMode.Add;
        }

        public frmAddEditUser(string UserID)
        {
            InitializeComponent();
            _Mode = enMode.Update;
            _UserID = UserID;
        }

        private void frmAddEditUser_Load(object sender, EventArgs e)
        {
            _ResetDefualtValues();

            if (_Mode == enMode.Update)
            {
                _LoadData();
            }
        }

        private void _LoadData()
        {
            _User = clsUser.Find(_UserID);

            if(_User == null)
            {
                MessageBox.Show($"No User With ID {_UserID}");
                return;
            }

            tbUserID.Enabled = false;
            
            tbUserID.Text = _UserID;
            tbPassword.Text = _User.Password;

            ctrlPersonInfoWithFilter1.FilterEnabled = false;
            ctrlPersonInfoWithFilter1.LoadPersonInfo(_User.PersonID);
        }

        private void _ResetDefualtValues()
        {
            tpUser.Enabled = false;

            tbUserID.Text = string.Empty;
            tbPassword.Text = string.Empty;
            ctrlPersonInfoWithFilter1.FoucustbPersonID();

            lbTitle.Text = ((_Mode == enMode.Add) ? "Add New" : "Update") + " User";
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            tcUser.SelectedIndex = 1;
            tpUser.Enabled = true;
        }

        private void ctrlPersonInfoWithFilter1_OnPersonSelected(int obj)
        {
            if(clsUser.Find(obj) != null && _Mode == enMode.Add)
            {
                MessageBox.Show($"This Person Has An User ID Already With UserID : {clsUser.Find(obj).UserID}");
                ctrlPersonInfoWithFilter1.FoucustbPersonID();
                tpUser.Enabled = false;
                btnNext.Enabled = false;
                _ResetDefualtValues();
                return;
            }

            btnNext.Enabled = true;
        }

        private void tbUserID_Validating(object sender, CancelEventArgs e)
        {
            if(tbUserID.Text == "")
            {
                e.Cancel = true;
                tbUserID.Focus();
                errorProvider1.SetError(tbUserID, "Please Enter An User ID.");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(tbUserID, "");
            }

            if (clsUser.IsExist(tbUserID.Text) && _Mode == enMode.Add)
            {
                e.Cancel = true;
                tbUserID.Focus();
                errorProvider1.SetError(tbUserID, "This User ID is Exist, Please Choice Anthor ID.");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(tbUserID, "");
            }
        }

        private void tbPassword_Validating(object sender, CancelEventArgs e)
        {
            if (tbPassword.Text == "")
            {
                e.Cancel = true;
                tbPassword.Focus();
                errorProvider1.SetError(tbPassword, "Please Enter Your Password.");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(tbPassword, "");
            }
        }

        short _GetPermissions()
        {

            if (rbAdmin.Checked)
            {
                return 0;
            }
            else if (rbSaleman.Checked)
            {
                return (short)enPermissions.StudentList + (short)enPermissions.PaymentList + 
                        (short)enPermissions.BatchesList + (short)enPermissions.PeopleList;
            }
            else
            {
                return (short)enPermissions.ProgramsList + (short)enPermissions.BatchesList +
                        (short)enPermissions.DomainList + (short)enPermissions.TutorList;
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Please Complate All Fields.", "Waring", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; 
            }

            _User.UserID = tbUserID.Text.ToString().Trim();
            _User.PersonID = ctrlPersonInfoWithFilter1.PersonID;
            _User.Password = tbPassword.Text;
            _User.Permissions = _GetPermissions();

            if (_User.Save())
            {
                MessageBox.Show("User Info Saved Successfully.");
                
                btnCancel.PerformClick();
            }
            else
            {
                MessageBox.Show("Erorr : User Info Not Saved.", "Faild", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void cbUsers_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
