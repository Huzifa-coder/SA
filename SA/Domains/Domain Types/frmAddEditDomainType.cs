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

namespace SA.Domains.Domain_Types
{
    public partial class frmAddEditDomainType : Form
    {
        enum enMode { Add,  Update }
        enMode _Mode;

        clsDomainType _DomainType;
        int _DomainTypeID = -1;

        public frmAddEditDomainType()
        {
            InitializeComponent();

            _Mode = enMode.Add;
        }

        public frmAddEditDomainType(int DomainTypeID)
        {
            InitializeComponent();

            _DomainTypeID = DomainTypeID;
            _Mode = enMode.Update;
        }

        private void frmAddEditDomainType_Load(object sender, EventArgs e)
        {
            _ResetDefualtValues();

            if(_Mode == enMode.Update)
            {
                _LoadData();
            }
        }

        private void _LoadData()
        {
            _DomainType = clsDomainType.Find(_DomainTypeID);

            if(_DomainType == null)
            {
                MessageBox.Show($"There No Domain Type With ID : {_DomainTypeID}");
                return;
            }

            lbDomainTypeID.Text = _DomainTypeID.ToString();
            tbName.Text = _DomainType.DomainTypeName.Trim();
        }

        private void _ResetDefualtValues()
        {
            lbTitle.Text = (_Mode == enMode.Add) ? "Add" : "Update" + " Domain Type";
            this.Text = lbTitle.Text;

            _DomainType = new clsDomainType();

            lbDomainTypeID.Text = "N/A";
            tbName.Text= string.Empty;
        }

        private void tbName_Validating(object sender, CancelEventArgs e)
        {
            if (tbName.Equals(""))
            {
                e.Cancel = true;
                tbName.Focus();
                errorProvider1.SetError(tbName, "Pleace Fill this Field");
            }
            else
            {
                e.Cancel= false;
                errorProvider1.SetError(tbName, "");

            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Pleace Fill All Feilds.");
                return;
            }

            _DomainType.DomainTypeName = tbName.Text.Trim();

            if (_DomainType.Save())
            {
                MessageBox.Show("Type Info Saved Successfully.");
                lbDomainTypeID.Text = _DomainType.DomainTypeID.ToString();

                btnCancel.PerformClick();
            }
            else
            {
                MessageBox.Show("Error : Type Info Failed To Save", "ERORR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
