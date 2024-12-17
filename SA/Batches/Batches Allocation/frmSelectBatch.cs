using BusinessLayer;
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
    public partial class frmSelectBatch : Form
    {

        public delegate void DatabackEventHandler(object sender, int BatchID);

        public event DatabackEventHandler DataBack;

        DataTable _dtBatches;

        public frmSelectBatch()
        {
            InitializeComponent();
        }

        private void frmSelectBatch_Load(object sender, EventArgs e)
        {
            _dtBatches = clsBatch.GetBatches();

            if(_dtBatches.Rows.Count > 0 )
            {
                dgvBatches.DataSource = _dtBatches;
            }
        }

        private void btnAddNewBatch_Click(object sender, EventArgs e)
        {
            frmAddEditBatch frm = new frmAddEditBatch();
            frm.ShowDialog();

            frmSelectBatch_Load(null, null); 
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if ((int)dgvBatches.SelectedRows[0].Cells["Capacity"].Value > (int)dgvBatches.SelectedRows[0].Cells["StudentsCount"].Value) 
            {
                int id = (int)dgvBatches.SelectedRows[0].Cells["BatchID"].Value;

                DataBack?.Invoke(this, id);

                Close();
            }
            else
            {
                MessageBox.Show("This Batch Is Full, Please Choice Anthor Bathc", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dgvBatches_DoubleClick(object sender, EventArgs e)
        {
            int id = (int)dgvBatches.SelectedRows[0].Cells["BatchID"].Value;

            frmListStudents frm = new frmListStudents(id);
            frm.ShowDialog();
        }
    }
}
