using BusinessLayer;
using SA.People;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SA.Users
{
    public partial class frmChangeUserPassword : Form
    {
        string _UserID = string.Empty;
        clsUser _User;

        public frmChangeUserPassword(string UserID)
        {
            InitializeComponent();
            _UserID = UserID;
        }

        
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmAddEditPerson frm = new frmAddEditPerson(_User.PersonID);
            frm.ShowDialog();
        }

        private void frmEmployeeAccountSetting_Load(object sender, EventArgs e)
        {
            lbUserID.Text = _UserID.ToString();
            _User = clsUser.Find(_UserID);

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tbPassword_Validating(object sender, CancelEventArgs e)
        {
            if (tbPassword.Text != _User.Password)
            {
                e.Cancel = true;
                tbPassword.Focus();
                errorProvider1.SetError(tbPassword, "The Password Is Not Correct.");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(tbPassword, "");
            }
        }

        private void tbConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            if (tbNewPassword.Text != tbConfirmPassword.Text)
            {
                e.Cancel = true;
                tbPassword.Focus();
                errorProvider1.SetError(tbConfirmPassword, "The Password Is Not Matches.");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(tbConfirmPassword, "");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Pleace Complate Empty Failds.");
                return;
            }

            _User.Password = tbNewPassword.Text;

            if (_User.Save())
            {
                MessageBox.Show("The Password Changed Successfully.");
            }
            else
            {
                MessageBox.Show("Error : The Password Is Not Changed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
