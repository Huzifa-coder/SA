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
    public partial class frmListUsers : Form
    {
        DataTable _dtUsersList = null;
        public frmListUsers()
        {
            InitializeComponent();
        }

        private void frmListUsers_Load(object sender, EventArgs e)
        {
            _dtUsersList = clsUser.GetUsers();


            if (_dtUsersList != null)
            {
                dgvUsers.DataSource = _dtUsersList;
                lbRecords.Text = dgvUsers.Rows.Count.ToString();
                cbFilterBy.SelectedIndex = 0;
            }
        }

        private void btnAddNewUser_Click(object sender, EventArgs e)
        {
            frmAddEditUser frm = new frmAddEditUser();
            frm.ShowDialog();

            frmListUsers_Load(null, null);
        }

        private void tbFilterValue_TextChanged(object sender, EventArgs e)
        {

            if (dgvUsers.RowCount <= 0)
                return;

            string filterColumn = "";

            switch ((string)cbFilterBy.SelectedItem)
            {
                case "ID":
                    filterColumn = "UserID";
                    break;

                case "Full Name":
                    filterColumn = "FirstName";

                    break;

                default:
                    filterColumn = "None";
                    break;
            }

            if (filterColumn == "None" || tbFilterValue.Text.Trim() == "")
            {

                _dtUsersList.DefaultView.RowFilter = "";
                lbRecords.Text = dgvUsers.Rows.Count.ToString();
                return;
            }

            _dtUsersList.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", filterColumn, tbFilterValue.Text.Trim());

            lbRecords.Text = dgvUsers.Rows.Count.ToString();
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbFilterValue.Visible = ((string)cbFilterBy.SelectedItem != "None");

            if (tbFilterValue.Visible)
            {
                tbFilterValue.Text = "";
                tbFilterValue.Focus();
            }

        }

        private void editUserInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string id = dgvUsers.CurrentRow.Cells[0].Value.ToString();

            frmAddEditUser frm = new frmAddEditUser(id);
            frm.ShowDialog();

            frmListUsers_Load(null,null);
        }

        private void deletePersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string id = dgvUsers.CurrentRow.Cells[0].Value.ToString().Trim();
            
            if (MessageBox.Show("Are Do You Want To Delete This User : \n" + id, "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {

                if (clsUser.Delete(id))
                {
                    MessageBox.Show("User Deleted Successfully.");
                    frmListUsers_Load(null, null);
                }
                else
                {
                    MessageBox.Show("Faild To delete This Person", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListUsers_Load(null, null);

        }

        private void cmsPeople_Opening(object sender, CancelEventArgs e)
        {
            bool enable = dgvUsers.RowCount >= 1;

            editUserInfoToolStripMenuItem.Enabled = enable;  
            deletePersonToolStripMenuItem.Enabled = enable;  
            
        }
    }
}
