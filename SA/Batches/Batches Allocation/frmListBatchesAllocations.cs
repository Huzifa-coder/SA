using BusinessLayer;
using SA.Payments;
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

namespace SA.Batches.Batches_Allocation
{
    public partial class frmListBatchesAllocations : Form
    {

        DataTable _dtBatchesAllocationList = new DataTable();

        public frmListBatchesAllocations()
        {
            InitializeComponent();
        }

        private void frmBatchesAllocationList_Load(object sender, EventArgs e)
        {
            _dtBatchesAllocationList = clsBatchAllocation.GetBatchAllocations();


            if (_dtBatchesAllocationList != null)
            {
                dgvBatchesAllocation.DataSource = _dtBatchesAllocationList;
                lbRecords.Text = dgvBatchesAllocation.Rows.Count.ToString();
                cbFilterBy.SelectedIndex = 0;
            }
        }

        private void tbFilterValue_TextChanged(object sender, EventArgs e)
        {
            if (dgvBatchesAllocation.RowCount <= 0)
                return;

            string filterColumn = "";

            switch ((string)cbFilterBy.SelectedItem)
            {

                case "Batch Name":
                    filterColumn = "BatchName";

                    break;

                case "Tutor Name":
                    filterColumn = "Tutor";

                    break;

                case "Start Time":
                    filterColumn = "StartTime";

                    break;
                default:
                    filterColumn = "None";
                    break;
            }

            if (filterColumn == "None" || tbFilterValue.Text.Trim() == "")
            {

                _dtBatchesAllocationList.DefaultView.RowFilter = "";
                lbRecords.Text = dgvBatchesAllocation.Rows.Count.ToString();
                return;
            }

            _dtBatchesAllocationList.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", filterColumn, tbFilterValue.Text.Trim());

            lbRecords.Text = dgvBatchesAllocation.Rows.Count.ToString();
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

        private void batchInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int id = (int)dgvBatchesAllocation.CurrentRow.Cells["BatchID"].Value;

            frmBatchInfo frm = new frmBatchInfo(id);
            frm.ShowDialog();
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBatchesAllocationList_Load(null, null);

        }

        private void programInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsBatch b = clsBatch.Find((int)dgvBatchesAllocation.CurrentRow.Cells["BatchID"].Value);

            frmProgramInfo frm = new frmProgramInfo(b.ProgramID);
            frm.ShowDialog();
        }

        private void deletePersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int id = (int)dgvBatchesAllocation.CurrentRow.Cells[0].Value;

            if (MessageBox.Show("Are Do You Want To Delete This Batch Allocation : \n" + id, "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {

                if (clsBatchAllocation.Delete(id))
                {
                    MessageBox.Show("Batch Allocation Deleted Successfully.");

                    frmBatchesAllocationList_Load(null, null);
                }
                else
                {
                    MessageBox.Show("Faild To delete This Batch Allocation", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void cmsBatches_Opening(object sender, CancelEventArgs e)
        {
            bool enable = dgvBatchesAllocation.RowCount >= 1;
            
            batchInfoToolStripMenuItem.Enabled = enable;
            programInfoToolStripMenuItem.Enabled = enable;
            deleteToolStripMenuItem.Enabled = enable;

            
        }
    }
}
