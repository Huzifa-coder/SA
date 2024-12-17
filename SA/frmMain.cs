using BusinessLayer;
using SA.Batches;
using SA.Batches.Batches_Allocation;
using SA.Courses;
using SA.Domains.Domain_Types;
using SA.Domains.Domains;
using SA.Globle;
using SA.Login;
using SA.Payments;
using SA.People;
using SA.Students;
using SA.Tutors;
using SA.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SA
{
    public partial class frmMain : Form
    {
        frmLogin _Login;

        public frmMain(frmLogin login)
        {
            InitializeComponent();
            _Login = login;
        }

        private bool _UserHasPermission(clsUser.enPermissions permission)
        {
            if (!clsGloble.CurrentUser.HasPermission(permission))
            {
                MessageBox.Show("You Do Not Have Permissions To Access This Field, Please Contact Your Admin.");
                return false;
            }

            return true;
        }

        private void peopleListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!_UserHasPermission(clsUser.enPermissions.PeopleList)) return;

            frmListPeople frm = new frmListPeople();
            frm.MdiParent = this;
            frm.Show();
        }

        private void usersListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!_UserHasPermission(clsUser.enPermissions.UsersList)) return;


            frmListUsers frm = new frmListUsers();
            frm.MdiParent = this;
            frm.Show();
        }

        private void programsListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!_UserHasPermission(clsUser.enPermissions.ProgramsList)) return;


            frmListPrograms frm = new frmListPrograms();
            frm.MdiParent = this;
            frm.Show();
        }

        private void paymentsListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!_UserHasPermission(clsUser.enPermissions.PaymentList)) return;


            frmListPayments frm = new frmListPayments();
            frm.MdiParent = this;
            frm.Show();
        }

        private void studentListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!_UserHasPermission(clsUser.enPermissions.StudentList)) return;

            frmListStudents frm = new frmListStudents();
            frm.MdiParent = this;
            frm.Show();
        }

        private void accountSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {

            frmChangeUserPassword frm = new frmChangeUserPassword(clsGloble.CurrentUser.UserID);    
            frm.MdiParent = this;
            frm.Show();
        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            clsGloble.CurrentUser = null;
            _Login.ShowDialog();
        }

        private void domainTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!_UserHasPermission(clsUser.enPermissions.TypesList)) return;

            frmListDomainTypes frm = new frmListDomainTypes();  
            frm.MdiParent = this;
            frm.Show();
        }

        private void domainsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!_UserHasPermission(clsUser.enPermissions.DomainList)) return;

            frmLIstDomainas frm = new frmLIstDomainas();
            frm.MdiParent = this;
            frm.Show();

        }

        private void tutorsListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!_UserHasPermission(clsUser.enPermissions.TutorList)) return;

            frmListTutor frm = new frmListTutor();  
            frm.MdiParent = this;
            frm.Show();
        }

        private void batchListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!_UserHasPermission(clsUser.enPermissions.BatchesList)) return;

            frmListBatches frm = new frmListBatches();
            frm.MdiParent = this;
            frm.Show();
        }

        private void frmMain_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ((char)Keys.Escape))
            {
                this.Close();
            }
        }

        
    }
}
