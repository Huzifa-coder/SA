using BusinessLayer;
using SA.Payments;
using SA.People;
using SA.Students;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SA.Batches
{
    public partial class frmListBatches : Form
    {
        DataTable _dtBatchesList = new DataTable();

        public frmListBatches()
        {
            InitializeComponent();
        }

        private void frmListBatches_Load(object sender, EventArgs e)
        {
            _dtBatchesList = clsBatch.GetBatches();


            if (_dtBatchesList != null)
            {
                dgvBatches.DataSource = _dtBatchesList;
                lbRecords.Text = dgvBatches.Rows.Count.ToString();
                cbFilterBy.SelectedIndex = 0;
                dgvBatches.Rows[0].DefaultCellStyle.BackColor = Color.Black;
                _ChangeRowColorDependenceOnStatus();
            }
        }

        private void _ChangeRowColorDependenceOnStatus()
        {
            foreach(DataGridViewRow row in dgvBatches.Rows)
            {
                switch(row.Cells["Status"].Value)
                {
                    case "TBD":
                        dgvBatches.Rows[row.Index].DefaultCellStyle.BackColor = Color.White;
                        break;

                    case "To Be Started":
                        dgvBatches.Rows[row.Index].DefaultCellStyle.BackColor = Color.LightSkyBlue;
                        break;

                    case "Complated":
                        dgvBatches.Rows[row.Index].DefaultCellStyle.BackColor = Color.LightGreen;
                        break;

                    case "Cancelled":
                        dgvBatches.Rows[row.Index].DefaultCellStyle.BackColor = Color.OrangeRed;
                        break;

                    case "On Going":
                        dgvBatches.Rows[row.Index].DefaultCellStyle.BackColor = Color.Yellow;
                        break;

                }
            }
        }

        private void btnAddNewBatch_Click(object sender, EventArgs e)
        {
            frmAddEditBatch frm = new frmAddEditBatch();
            frm.ShowDialog();

            frmListBatches_Load(null, null);
        }

        private void tbFilterValue_TextChanged(object sender, EventArgs e)
        {
            if (dgvBatches.RowCount <= 0)
                return;

            string filterColumn = "";

            switch ((string)cbFilterBy.SelectedItem)
            {

                case "Batch Name":
                    filterColumn = "BatchName";

                    break;

                case "Tutor":
                    filterColumn = "TutorName";

                    break;

                case "Type":
                    filterColumn = "Type";

                    break;
                default:
                    filterColumn = "None";
                    break;
            }

            if (filterColumn == "None" || tbFilterValue.Text.Trim() == "")
            {

                _dtBatchesList.DefaultView.RowFilter = "";
                lbRecords.Text = dgvBatches.Rows.Count.ToString();
                return;
            }

            _dtBatchesList.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", filterColumn, tbFilterValue.Text.Trim());

            lbRecords.Text = dgvBatches.Rows.Count.ToString();
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

        private void editPersonInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddEditBatch frm = new frmAddEditBatch((int)dgvBatches.CurrentRow.Cells["BatchID"].Value);
            frm.ShowDialog();

            frmListBatches_Load(null, null);
        }

        private void deletePersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int id = (int)dgvBatches.CurrentRow.Cells[0].Value;

            if (MessageBox.Show("Are Do You Want To Delete This Batch : \n" + id, "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {

                if (clsBatch.Delete(id))
                {
                    MessageBox.Show("Batch Deleted Successfully.");

                    frmListBatches_Load(null, null);
                }
                else
                {
                    MessageBox.Show("Faild To delete This Batch", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void batchInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int id = (int)dgvBatches.CurrentRow.Cells["BatchID"].Value;

            frmBatchInfo frm = new frmBatchInfo(id);
            frm.ShowDialog();
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListBatches_Load(null, null);

        }

        private void programInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsBatch b = clsBatch.Find((int)dgvBatches.CurrentRow.Cells["BatchID"].Value);

            frmProgramInfo frm = new frmProgramInfo(b.ProgramID);
            frm.ShowDialog();
        }

        private void studentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int id = (int)dgvBatches.CurrentRow.Cells["BatchID"].Value;

            frmListStudents frm = new frmListStudents(id);
            frm.ShowDialog();
        }

        private void allocationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int id = (int)dgvBatches.CurrentRow.Cells["BatchID"].Value;

            frmAddEditBatchAllocation frm = new frmAddEditBatchAllocation(id);
            frm.ShowDialog();

            frmListBatches_Load(null, null);
        }

        private void cmsBatches_Opening(object sender, CancelEventArgs e)
        {
            bool enable = dgvBatches.RowCount >= 1; 
           
            allocationToolStripMenuItem.Enabled = enable;
                
            studentsToolStripMenuItem.Enabled = enable;
            batchInfoToolStripMenuItem.Enabled = enable;
            editBatchInfoToolStripMenuItem.Enabled = enable;
                
            programInfoToolStripMenuItem.Enabled = enable;
                
            deleteToolStripMenuItem.Enabled = enable;  

            
        }
    }
}
