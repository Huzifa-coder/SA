using BusinessLayer;
using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace SA.Courses
{
    public partial class frmAddEditProgram : Form
    {
        enum enMode { Add, Update }
        enMode _Mode = enMode.Add;

        clsProgram _Program;
        int _ProgramID = -1;

        public frmAddEditProgram()
        {
            InitializeComponent();
            _Mode = enMode.Add;
        }

        public frmAddEditProgram(int ProgramID)
        {
            InitializeComponent();

            _ProgramID = ProgramID; 
            _Mode = enMode.Update;
        }

        private void frmAddEditProgram_Load(object sender, EventArgs e)
        {
            _ResetDefualtValues();

            if(_Mode == enMode.Update)
            {
                _LoadData();
            }
        }

        private void _ResetDefualtValues()
        {
            _Program = new clsProgram();

            lbProgramID.Text = "N/A";
            tbProgramName.Text = string.Empty;
            tbDuration.Text = string.Empty;

            _LoadDomainTypesListInComboBox();
            
            cbDomainType.SelectedIndex = 0;
            lbTitle.Text = ((_Mode == enMode.Add) ? "Add" : "Edit") + " Program";
            this.Text = ((_Mode == enMode.Add) ? "Add" : "Edit") + " Program";
        }

        private void _LoadDomainTypesListInComboBox()
        {
            DataTable dt = clsDomainType.GetDomainTypes();

            foreach(DataRow dr in dt.Rows)
            {
                cbDomainType.Items.Add(dr["DomainTypeName"].ToString());
            }
        }

        private void _LoadData()
        {
            _Program = clsProgram.Find(_ProgramID);

            if (_Program == null)
            {
                MessageBox.Show($"There Are No Program Found With ID : {_ProgramID}");
                return;
            }

            lbProgramID.Text = _Program.ProgramID.ToString();
            tbProgramName.Text = _Program.ProgramName;
            tbDuration.Text = _Program.Duration.ToString();

            
            cbDomainType.SelectedText = _Program.DomainInfo.DomainTpyeInfo.DomainTypeName;
            cbDomain.SelectedText = _Program.DomainInfo.DomainName;

        }

        private void TextBox_Validating(object sender, CancelEventArgs e)
        {
            TextBox temp = (TextBox)sender;

            if (temp.Text == "")
            {
                e.Cancel = true;
                temp.Focus();
                errorProvider1.SetError(temp, "Please Fill This Empty Area");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(temp, "");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Please Complate All Failds.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _Program.ProgramName = tbProgramName.Text.Trim();
            _Program.Duration = tbDuration.Text;

            int DomainTypeID = clsDomainType.Find(cbDomainType.Text).DomainTypeID;
            _Program.DomainID = clsDomain.Find(cbDomain.Text, DomainTypeID).DomainID;

            if (_Program.Save())
            {
                MessageBox.Show("Program Info Saved Successfully.");
                lbProgramID.Text = _Program.ProgramID.ToString();
                btnSave.Enabled = false;

                btnCancel.PerformClick();
            }
            else
            {
                MessageBox.Show("Erorr : Program Info Not Saved.", "Faild", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void cbDomainType_SelectedIndexChanged(object sender, EventArgs e)
        {
            _LoadDomainsForTypeInComboBox((string)cbDomainType.SelectedItem);
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

    }
}
