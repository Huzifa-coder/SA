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

namespace SA.Batches
{
    public partial class frmAddEditBatchAllocation : Form
    {
        enum enMode { Add, Update }
        enMode _Mode;

        int _BatchID = -1;
        
        int _BatchAllocationID = -1;
        clsBatchAllocation _BatchAllocation;


        public frmAddEditBatchAllocation(int batchID)
        {
            InitializeComponent();

            _BatchID = batchID;
            _Mode = (clsBatchAllocation.IsExistByBatchID(batchID)) ? enMode.Update : enMode.Add;
        }

        private void frmAddEditBatchAllocation_Load(object sender, EventArgs e)
        {
            _ResetDefualtInfo();

            if (_Mode == enMode.Update)
            {
                _LoadData();
            }
        }

        private void _LoadData()
        {
            _BatchAllocation  = clsBatchAllocation.FindByBatchID(_BatchID);

            if (_BatchAllocation == null)
            {
                MessageBox.Show($"This Batch Allocation ID Is Not Exist : {_BatchAllocationID}");
                return;
            }

            _BatchAllocationID = _BatchAllocation.BatchesAllocationID;
            lbBatchAllocationID.Text = _BatchAllocationID.ToString();
            //dtpStart.Value. = _BatchAllocation.StartTimeO
            //dtpEnd.Value = Convert.ToDateTime(_BatchAllocation.EndTime);

        }

        private void _ResetDefualtInfo()
        {
            _BatchAllocation = new clsBatchAllocation();

            lbBatchAllocationID.Text = "N/A";

            this.Text = (_Mode == enMode.Update) ? "Update" : "Add " + " Batch Allocation";
            lbTitle.Text =  (_Mode == enMode.Update)?"Update":"Add " + " Batch Allocation";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            
            if (dtpStart.Value.TimeOfDay > dtpEnd.Value.TimeOfDay)
            {
                MessageBox.Show("The Start Time Must Be Before End Time.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!clsTutor.IsTutorEmptyForBatch(_BatchID, dtpStart.Value.TimeOfDay, dtpEnd.Value.TimeOfDay))
            {
                MessageBox.Show("This Tutor Has Allocation In This Time.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _BatchAllocation.BatchID = _BatchID;
            _BatchAllocation.StartTime = dtpStart.Value.TimeOfDay;
            _BatchAllocation.EndTime = dtpEnd.Value.TimeOfDay;

            if (_BatchAllocation.Save())
            {
                MessageBox.Show("Batch Allocation Saved Successfully.");
                lbBatchAllocationID.Text = _BatchAllocation.BatchesAllocationID.ToString();

                btnCancel.PerformClick();
            }
            else
            {
                MessageBox.Show("Error : Batch Allocation Does Not Saved", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
