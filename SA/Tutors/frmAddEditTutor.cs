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

namespace SA.Tutors
{
    public partial class frmAddEditTutor : Form
    {
        enum enMode { Add, Update }
        enMode _Mode ;

        int _TutorID = -1;
        clsTutor _Tutor;

        public frmAddEditTutor()
        {
            InitializeComponent();

            _Mode = enMode.Add;
        }

        public frmAddEditTutor(int TutorID)
        {
            InitializeComponent();

            _Mode = enMode.Update;
            _TutorID = TutorID;
        }

        private void frmAddEditTutor_Load(object sender, EventArgs e)
        {
            _ResetDefualtValues();

            if( _Mode == enMode.Update )
            {
                _LoadData();
            }
        }

        private void _LoadData()
        {
            _Tutor = clsTutor.FindByTutorID(_TutorID);
            
            if( _Tutor == null )
            {
                MessageBox.Show($"There Are No Tutor With ID {_TutorID}");
                this.Close();
            }

            lbTutorID.Text = _TutorID.ToString();
            tbPhone.Text = _Tutor.Phone;

            ctrlPersonInfoWithFilter1.LoadPersonInfo(_Tutor.PersonID);
            ctrlPersonInfoWithFilter1.FilterEnabled = false;

        }

        private void _ResetDefualtValues()
        {
            _Tutor = new clsTutor();

            lbTitle.Text = (_Mode == enMode.Add) ? "Add" : "Update" + " Tutor";
            this.Text = lbTitle.Text;

            lbTutorID.Text = "N/A";
            tbPhone.Text= string.Empty;

            tpTutor.Enabled = false;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            tpTutor.Enabled = true;
            tabControl1.SelectedIndex = 1;
        }

        private void ctrlPersonInfoWithFilter1_OnPersonSelected(int obj)
        {
            if (clsTutor.IsExistByPersonID(obj) && _Mode == enMode.Add)
            {
                MessageBox.Show("This Person is Already A Tutor, Please Choice Anthor One.");
                return;
            }

            btnNext.Enabled = true;
        }

        private void tbPhone_Validating(object sender, CancelEventArgs e)
        {
            if (tbPhone.Text == "")
            {
                e.Cancel = true;
                tbPhone.Focus();
                errorProvider1.SetError(tbPhone, "Please Enter The Phone Number.");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(tbPhone, "");
            }


            if (tbPhone.Text.Length != 10)
            {
                e.Cancel = true;
                tbPhone.Focus();
                errorProvider1.SetError(tbPhone, (tbPhone.Text.Length>10)? "The number Above 10" : "The Number Under 10");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(tbPhone, "");
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Please Fill All Fields To Complate.");
                return;
            }

            _Tutor.Phone = tbPhone.Text.Trim();
            _Tutor.PersonID = ctrlPersonInfoWithFilter1.PersonID;

            if (_Tutor.Save())
            {
                MessageBox.Show("Tutro Info Saved Successfully.");
                lbTutorID.Text = _Tutor.TutorID.ToString(); 

                btnClose.PerformClick();
            }
            else
            {
                MessageBox.Show("Error : Faild To Save Tutor Info.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tbPhone_KeyPress(object sender, KeyPressEventArgs e)
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
    }
}
