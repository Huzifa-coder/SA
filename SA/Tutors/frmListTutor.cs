using BusinessLayer;
using SA.Domains.Domain_Types;
using SA.Domains.Domains;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SA.Tutors
{
    public partial class frmListTutor : Form
    {
        DataTable _dtTutorsList = new DataTable();

        public frmListTutor()
        {
            InitializeComponent();
        }

        private void frmListTutors_Load(object sender, EventArgs e)
        {
            _dtTutorsList = clsTutor.GetTutors();


            if (_dtTutorsList != null)
            {
                dgvTutors.DataSource = _dtTutorsList;
                lbRecords.Text = dgvTutors.Rows.Count.ToString();
                cbFilterBy.SelectedIndex = 0;
            }
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            frmAddEditTutor frm = new frmAddEditTutor();
            frm.ShowDialog();

            frmListTutors_Load(null, null);
        }

        private void tbFilterValue_TextChanged(object sender, EventArgs e)
        {
            if (dgvTutors.RowCount <= 0)
                return;

            string filterColumn = "";

            switch ((string)cbFilterBy.SelectedItem)
            {

                case "Name":
                    filterColumn = "FullName";

                    break;


                default:
                    filterColumn = "None";
                    break;
            }

            if (filterColumn == "None" || tbFilterValue.Text.Trim() == "")
            {

                _dtTutorsList.DefaultView.RowFilter = "";
                lbRecords.Text = dgvTutors.Rows.Count.ToString();
                return;
            }

            _dtTutorsList.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", filterColumn, tbFilterValue.Text.Trim());

            lbRecords.Text = dgvTutors.Rows.Count.ToString();
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

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddEditTutor frm = new frmAddEditTutor((int)dgvTutors.CurrentRow.Cells[0].Value);
            frm.ShowDialog();

            frmListTutors_Load(null, null);
        }

        private void deleteStripMenuItem_Click(object sender, EventArgs e)
        {
            int id = (int)dgvTutors.CurrentRow.Cells[0].Value;

            if (!(MessageBox.Show("Are Do You Want To Delete This Tutor : \n" + id, "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK))
            {
                return;
            }

            if (!clsTutor.Delete(id))
            {
                MessageBox.Show("Faild To delete This Tutor", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            MessageBox.Show("Tutor Deleted Successfully.");

            frmListTutors_Load(null, null);
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListTutors_Load(null, null);
        }

        private void teachingDomainsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int id = (int)dgvTutors.CurrentRow.Cells[0].Value;

            frmListTutorTechingDomains frm = new frmListTutorTechingDomains(id);
            frm.ShowDialog();
        }

        private void tutorFreeTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int id = (int)dgvTutors.CurrentRow.Cells[0].Value;

            frmLisTutorFreeTime frm = new frmLisTutorFreeTime(id);
            frm.ShowDialog();
        }

        private void cmsTutor_Opening(object sender, CancelEventArgs e)
        {
            bool enable = dgvTutors.RowCount >= 1;

            tutorFreeTimeToolStripMenuItem.Enabled = enable;
            teachingDomainsToolStripMenuItem.Enabled = enable;
            editInfoToolStripMenuItem.Enabled = enable;
            deleteToolStripMenuItem.Enabled = enable;
            
        }
    }
}
