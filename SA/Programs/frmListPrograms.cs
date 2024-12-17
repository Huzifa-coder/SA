using BusinessLayer;
using SA.Payments;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SA.Courses
{
    public partial class frmListPrograms : Form
    {

        DataTable _dtProgramsList = new DataTable();

        public frmListPrograms()
        {
            InitializeComponent();
        }


        private void frmListPrograms_Load(object sender, EventArgs e)
        {
            _dtProgramsList = clsProgram.GetPrograms();

            if (_dtProgramsList != null)
            {
                dgvProgram.DataSource = _dtProgramsList;
                lbRecords.Text = dgvProgram.Rows.Count.ToString();
                cbFilterBy.SelectedIndex = 0;
            }
        }


        private void tbFilterValue_TextChanged(object sender, EventArgs e)
        {
            if (dgvProgram.RowCount <= 0)
                return;

            string filterColumn = "";

            switch ((string)cbFilterBy.SelectedItem)
            {

               case "Program Name":
                    filterColumn = "ProgramName";

                    break;

                
                default:
                    filterColumn = "None";
                    break;

            }

            if (filterColumn == "None" || tbFilterValue.Text.Trim() == "")
            {

                _dtProgramsList.DefaultView.RowFilter = "";
                lbRecords.Text = dgvProgram.Rows.Count.ToString();
                return;
            }

            _dtProgramsList.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", filterColumn, tbFilterValue.Text.Trim());

            lbRecords.Text = dgvProgram.Rows.Count.ToString();
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

        private void deleteCourseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int id = (int)dgvProgram.CurrentRow.Cells[0].Value;

            if (MessageBox.Show("Are Do You Want To Delete This Course : \n" + id, "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {

                if (clsCourse.Delete(id))
                {
                    MessageBox.Show("Course Deleted Successfully.");

                    frmListPrograms_Load(null, null);
                }
                else
                {
                    MessageBox.Show("Faild To delete This Course", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void editPersonInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int id = (int)dgvProgram.CurrentRow.Cells[0].Value;

            frmAddEditProgram frm = new frmAddEditProgram(id);
            frm.ShowDialog();

            frmListPrograms_Load(null, null);
        }

        private void btnAddNewCourse_Click(object sender, EventArgs e)
        {
            frmAddEditProgram frm = new frmAddEditProgram();
            frm.ShowDialog();

            frmListPrograms_Load(null, null);
        }

        private void courseInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int id = (int)dgvProgram.CurrentRow.Cells[0].Value;

            frmProgramInfo frm = new frmProgramInfo(id);
            frm.ShowDialog();
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListPrograms_Load(null, null);

        }

        private void cmsBatches_Opening(object sender, CancelEventArgs e)
        {
            bool enable = dgvProgram.RowCount >= 1;

            programInfoToolStripMenuItem.Enabled = enable;
            editInfoToolStripMenuItem.Enabled = enable;     
            deleteToolStripMenuItem.Enabled = enable;
            
        }
    }
}
