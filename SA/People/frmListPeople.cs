using BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SA.People
{
    public partial class frmListPeople : Form
    {
        DataTable _dtPeopleList = null;

        public frmListPeople()
        {
            InitializeComponent();
        }

        private void frmPersonsList_Load(object sender, EventArgs e)
        {
            _dtPeopleList = clsPerson.GetPeople();


            if (_dtPeopleList != null)
            {
                dgvPeople.DataSource = _dtPeopleList;
                lbRecords.Text = dgvPeople.Rows.Count.ToString();
                cbFilterBy.SelectedIndex = 0;
            }

        }

        private void btnAddNewPerson_Click(object sender, EventArgs e)
        {
            frmAddEditPerson frm = new frmAddEditPerson();
            frm.ShowDialog();

            frmPersonsList_Load(null, null);
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddEditPerson frm = new frmAddEditPerson((int)dgvPeople.CurrentRow.Cells[0].Value);
            frm.ShowDialog();

            frmPersonsList_Load(null, null);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tbFilterValue_TextChanged(object sender, EventArgs e)
        {
            if (dgvPeople.RowCount <= 0)
                return;

            string filterColumn = "";

            switch ((string)cbFilterBy.SelectedItem)
            {
                case "ID":
                    filterColumn = "ID";
                    break;

                case "Full Name":
                    filterColumn = "FirstName";

                    break;

                case "Last Name":
                    filterColumn = "LastName";

                    break;

                default:
                    filterColumn = "None";
                    break;
            }

            if (filterColumn == "None" || tbFilterValue.Text.Trim() == "")
            {

                _dtPeopleList.DefaultView.RowFilter = "";
                lbRecords.Text = dgvPeople.Rows.Count.ToString();
                return;
            }

            _dtPeopleList.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", filterColumn, tbFilterValue.Text.Trim());

            lbRecords.Text = dgvPeople.Rows.Count.ToString();
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

        private void deletePersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are Do You Want To Delete This Person : \n" + (int)dgvPeople.CurrentRow.Cells[0].Value, "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {

                if (clsPerson.Delete((int)dgvPeople.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("Person Deleted Successfully.");
                    frmPersonsList_Load(null, null);
                }
                else
                {
                    MessageBox.Show("Faild To delete This Person", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPersonsList_Load(null, null);

        }

        private void cmsPeople_Opening(object sender, CancelEventArgs e)
        {
            bool enable = dgvPeople.RowCount >= 1; 
            
            editPersonInfoToolStripMenuItem.Enabled = enable;
            deletePersonToolStripMenuItem.Enabled = enable;                  
        }

    }
}