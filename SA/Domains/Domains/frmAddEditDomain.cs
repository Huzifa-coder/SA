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

namespace SA.Domains.Domains
{
    public partial class frmAddEditDomain : Form
    {

        enum enMode { Add, Update }
        enMode _Mode;

        clsDomain _Domain;
        int _DomainID;

        public frmAddEditDomain()
        {
            InitializeComponent();

            _Mode = enMode.Add;
        }

        public frmAddEditDomain(int domainID)
        {
            InitializeComponent();

            _DomainID = domainID;
            _Mode = enMode.Update;
        }

        private void frmAddEditDomain_Load(object sender, EventArgs e)
        {
            _ResetDefualtValues();
            
            if(_Mode == enMode.Update)
            {
                _LoadData();
            }
        }

        private void _LoadData()
        {
            _Domain = clsDomain.Find(_DomainID);

            if(_Domain == null)
            {
                MessageBox.Show($"There No Domain With ID : {_DomainID}");
                return;
            }

            lbDomainD.Text = _DomainID.ToString();
            tbName.Text = _Domain.DomainName;
            cbDomainTypes.SelectedItem = clsDomainType.Find(_Domain.DomainTypeID).DomainTypeName;

        }

        private void _ResetDefualtValues()
        {
            lbTitle.Text = (_Mode == enMode.Add) ? "Add" : "Update" + " Domain";
            this.Text = lbTitle.Text;

            _Domain = new clsDomain();

            lbDomainD.Text = "N/A";
            tbName.Text = string.Empty;

            _LoadDomainTypesInComboBox();
        }

        private void _LoadDomainTypesInComboBox()
        {
            DataTable dt = clsDomainType.GetDomainTypes();

            foreach (DataRow dataRow in dt.Rows)
            {
                cbDomainTypes.Items.Add(dataRow[1].ToString().Trim());
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Please Fill All Fields.. ");
                return;
            }

            if(cbDomainTypes.SelectedItem == null)
            {
                MessageBox.Show("Please Choice A Domain Type.");
                return;
            }


            _Domain.DomainName = tbName.Text.Trim();
            _Domain.DomainTypeID = clsDomainType.Find((string)cbDomainTypes.SelectedItem).DomainTypeID;

            if (_Domain.Save())
            {
                MessageBox.Show("Domain Info Saved Successfully.");
                lbDomainD.Text = _Domain.DomainID.ToString();
                
                btnCancel.PerformClick();
            }
            else
            {
                MessageBox.Show("Error : Domain Info Failed To Save", "ERORR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
