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
    public partial class frmAddEditBatch : Form
    {
        enum enMode { Add, Update }
        enMode _Mode = enMode.Add;

        private int _BatchID = -1;
        private clsBatch _Batch;

        public frmAddEditBatch()
        {
            InitializeComponent();

            _Mode = enMode.Add;
        }

        public frmAddEditBatch(int BatchID)
        {
            InitializeComponent();

            _BatchID = BatchID;
            _Mode = enMode.Update;
        }

        private void frmAddEditBatch_Load(object sender, EventArgs e)
        {
            _RestDefultValues();

            if(_Mode == enMode.Update)
            {
                _LoadDate();
            }
        }

        private void _LoadDate()
        {
            _Batch = clsBatch.Find(_BatchID);

            if(_Batch == null)
            {
                MessageBox.Show($"There No Batch Found With ID : {_BatchID}");
                return;
            }

            _BatchID = _Batch.BatchID;

            lbBatchID.Text = _BatchID.ToString();
            tbBatchName.Text = _Batch.Name.Trim();
            dtpStartDate.Value = _Batch.StartDate;
            dtpEndDate.Value = _Batch.EndDate;
            tbOnGoingTopic.Text = _Batch.OnGoingTopic;
            tbCapacity.Text = _Batch.Capacity.ToString();
            cbMode.SelectedIndex = (int)_Batch.Mode;
            
            _LoadDomainTypesListInComboBox();

            cbDomainType.SelectedItem = _Batch.ProgramInfo.DomainInfo.DomainTpyeInfo.DomainTypeName;
            cbDomain.SelectedItem = _Batch.ProgramInfo.DomainInfo.DomainName;
            cbPrograms.SelectedItem = _Batch.ProgramInfo.ProgramName;
            cbTutors.SelectedItem = _Batch.TutorInfo.PersonInfo.FullNamee;
            cbStatus.SelectedIndex = (int)_Batch.Status - 1;
        }

        private void _RestDefultValues()
        {
            _LoadDomainTypesListInComboBox();

            lbBatchID.Text = "N/A";
            tbBatchName.Text = string.Empty;
            dtpStartDate.Value = DateTime.Now;
            dtpEndDate.Value = DateTime.Now.AddMonths(3);

            cbMode.SelectedIndex = 0;
            cbStatus.SelectedIndex = 0;
            
            _Batch = new clsBatch();
            lbTitle.Text = ((_Mode == enMode.Add) ? "Add New" : "Edit") + " Batch";
        }

        private void _LoadDomainTypesListInComboBox()
        {
            DataTable dt = clsDomainType.GetDomainTypes();

            foreach (DataRow dr in dt.Rows)
            {
                cbDomainType.Items.Add(dr["DomainTypeName"].ToString());
            }
        }

        private void _LoadDomainsForTypeInComboBox(string DomainTypeName)
        {
            cbDomain.Items.Clear();

            DataTable dt = clsDomain.GetDomains(clsDomainType.Find(DomainTypeName).DomainTypeID);

            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    cbDomain.Items.Add(dr["DomainName"].ToString());
                }
            }
        }

        private void tbBatchName_Validating(object sender, CancelEventArgs e)
        {
            if(tbBatchName.Text == "")
            {
                e.Cancel = true;
                tbBatchName.Focus();
                errorProvider1.SetError(tbBatchName, "Please Choice A Name For Batch");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(tbBatchName, "");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Please Complate All Failds.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if(dtpStartDate.Value > dtpEndDate.Value)
            {
                MessageBox.Show("The Start Date Must Be Before End Date.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cbPrograms.SelectedItem == null)
            {
                MessageBox.Show("Please Choice A Program.", "Warning",MessageBoxButtons.OK, MessageBoxIcon.Warning );
                return;
            }

            if (cbTutors.SelectedItem == null)
            {
                MessageBox.Show("Please Choice A Tutor.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _Batch.Name = tbBatchName.Text.Trim();
            _Batch.TutorID = clsTutor.FindByPersonID(clsPerson.GetPersonID(cbTutors.SelectedItem.ToString())).TutorID;
            _Batch.StartDate = dtpStartDate.Value;
            _Batch.EndDate = dtpEndDate.Value;
            _Batch.ProgramID = clsProgram.Find(cbPrograms.SelectedItem.ToString()).ProgramID;
            _Batch.Capacity = Convert.ToInt32(tbCapacity.Text);
            _Batch.Mode = (clsBatch.enMode)cbMode.SelectedIndex;
            _Batch.OnGoingTopic = tbOnGoingTopic.Text;
            _Batch.Status = _GetStatus();

            if (_Batch.Save())
            {
                MessageBox.Show("Batch Info Saved Successfully.");
                lbBatchID.Text = _Batch.BatchID.ToString();
                btnSave.Enabled = false;

                btnCancel.PerformClick();
            }
            else
            {
                MessageBox.Show("Erorr : Batch Info Not Saved.", "Faild", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private clsBatch.enStatus _GetStatus()
        {
            switch(cbStatus.SelectedItem)
            {
                case "TBD":
                    return clsBatch.enStatus.TBD;
                
                case "To Be Started":
                    return clsBatch.enStatus.ToBeStarted;

                case "On Going":
                    return clsBatch.enStatus.OnGoing;

                case "Complated":
                    return clsBatch.enStatus.Complate;

                case "Cancelled":
                    return clsBatch.enStatus.Cancelled;

                default :
                    return clsBatch.enStatus.ToBeStarted;
            }
        }

        private void cbDomainType_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbDomain.Items.Clear();
            cbPrograms.Items.Clear();
            cbTutors.Items.Clear();

            _LoadDomainsForTypeInComboBox(cbDomainType.SelectedItem.ToString());
        }

        private void cbDomain_SelectedIndexChanged(object sender, EventArgs e)
        { 


            clsDomain domain = clsDomain.Find(cbDomain.SelectedItem.ToString(), clsDomainType.Find(cbDomainType.SelectedItem.ToString()).DomainTypeID);
            
            if (domain == null) return;

            _LoadPorgramsForDomainInComboBox(domain.DomainID);
            _LoadTutorsForDomainInComboBox(domain.DomainID);
        }

        private void _LoadTutorsForDomainInComboBox(int domainID)
        {
            cbTutors.Items.Clear();

            DataTable dt = clsTutor.GetTutors(domainID);

            foreach (DataRow dr in dt.Rows)
            {
                cbTutors.Items.Add(dr["FullName"].ToString());
            }
        }

        private void _LoadPorgramsForDomainInComboBox(int DomainID)
        {
            cbPrograms.Items.Clear();

            DataTable dt = clsProgram.GetPrograms(DomainID);

            foreach (DataRow dr in dt.Rows)
            {
                cbPrograms.Items.Add(dr["ProgramName"].ToString());
            }

        }

        private void tbCapacity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
            (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void tbCapacity_Validating(object sender, CancelEventArgs e)
        {
            if (tbCapacity.Text == "")
            {
                e.Cancel = true;
                tbBatchName.Focus();
                errorProvider1.SetError(tbCapacity, "Please Put A Capacity For The Batch.");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(tbCapacity, "");
            }
        }

    }
}
