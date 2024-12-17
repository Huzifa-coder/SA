using BusinessLayer;
using SA.Globle;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SA.Login
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            string UserID = null, Password = null;

            if (clsGloble.GetUsreIDAndPassword(ref UserID, ref Password))
            {
                cbSaveLoginInfo.Checked = true;

                tbUserID.Text = UserID;
                tbPassword.Text = Password;

            }
        }

        private void btnSave_Click(object sender, EventArgs e)  
        {
            clsUser user = clsUser.Find(tbUserID.Text);

            if (user != null && user.Password == tbPassword.Text)
            {

                clsGloble.CurrentUser = user;

                if (cbSaveLoginInfo.Checked)
                    clsGloble.SaveUserIdAndPassword(user.UserID, user.Password);
                else
                    clsGloble.DeleteUserSavedInfo();

                this.Hide();
                frmMain frm = new frmMain(this);
                frm.ShowDialog();

                

            }
            else
            {
                MessageBox.Show("Please Try Again User ID/Password Is Wrong", "Faild", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
