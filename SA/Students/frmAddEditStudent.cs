using BusinessLayer;
using SA.Batches;
using SA.Globle;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SA.Students
{
    public partial class frmAddEditStudent : Form
    {
        enum enMode { Add, Update }
        enMode _Mode;

        private int _StudentId;
        private clsStudent _Student;    


        public frmAddEditStudent()
        {
            InitializeComponent();

            _Mode = enMode.Add;
        }

        public frmAddEditStudent(int StudentID)
        {
            InitializeComponent();

            _StudentId = StudentID;
            _Mode = enMode.Update;
        }

        private void tbPhone_Validating(object sender, CancelEventArgs e)
        {
            if(tbPhone.Text.Equals(""))
            {
                e.Cancel = true;
                tbPhone.Focus();
                errorProvider1.SetError(tbPhone, "Enter Phone Number, Please.");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(tbPhone, "");
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

        private void tbEmail_Validating(object sender, CancelEventArgs e)
        {
            if (!clsGloble.IsValidEmail(tbEmail.Text))
            {
                e.Cancel = true;
                tbEmail.Focus();
                errorProvider1.SetError(tbEmail, "Please Enter Vailed Email.");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(tbEmail, "");
            }
        }

        private void ctrlPersonInfoWithFilter1_OnPersonSelected(int obj)
        {
            if (clsStudent.IsExistByPersonID(obj) && _Mode == enMode.Add)
            {
                MessageBox.Show("This Person is Already Student, Choces Anther Person", "Exist", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            btnNext.Enabled = true;
            tpStudentInfo.Enabled = true;
        }

        private void frmAddEditStudent_Load(object sender, EventArgs e)
        {

            _RestDefualtValues();

            if(_Mode == enMode.Update)
            {
                _LoadData();
            }

        }

        private void _LoadData()
        {
            _Student = clsStudent.FindByStudentID(_StudentId);

            if (_Student != null)
            {
                ctrlPersonInfoWithFilter1.LoadPersonInfo(_Student.PersonID);
                ctrlPersonInfoWithFilter1.FilterEnabled = false;

                lbStudentID.Text = _Student.StudentID.ToString();
                tbPhone.Text = _Student.Phone;
                tbEmail.Text = _Student.Email;
                lbCreatedBy.Text = _Student.UserCreateByInfo .UserID;

            }
        }

        private void _RestDefualtValues()
        {
            _Student = new clsStudent();

            tpStudentInfo.Enabled = false;

            lbStudentID.Text = "N/A";

            tbEmail.Text = string.Empty;
            tbPhone.Text = string.Empty;



            lbCreatedBy.Text = clsGloble.CurrentUser.UserID;

            ctrlPersonInfoWithFilter1.BtnSearchEnabled = false;
            ctrlPersonInfoWithFilter1.FoucustbPersonID();
        }
        private void btnNext_Click(object sender, EventArgs e)
        {
            tpStudentInfo.Enabled = true;
            tcStudent.SelectedIndex = 1;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (!this.ValidateChildren())
            {
                MessageBox.Show("Please Complate All Feilds.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if(_Student.BatchID < 0)
            {
                MessageBox.Show("Please Select A Batch For The Student.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _Student.PersonID = ctrlPersonInfoWithFilter1.PersonID;
            _Student.Phone = tbPhone.Text.Trim();
            _Student.Email = tbEmail.Text.Trim();
            _Student.JoinDate = DateTime.Now;
            _Student.CreatedByID = clsGloble.CurrentUser.UserID;

            if (_Student.Save())
            {
                MessageBox.Show($"Student Info Saved Successfully.\nStudent ID : {_Student.StudentID}");
                lbStudentID.Text = _Student.StudentID.ToString();

                btnCancel.PerformClick();   
            }
            else
            {
                MessageBox.Show("Erorr : Course Info Not Saved.", "Faild", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void SecletedBatchDataBack(object sender, int BatchID)
        {
            if (BatchID > 0)
            {
                _Student.BatchID = BatchID;
            }
        }

        private void frmAddEditStudent_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = (e.CloseReason != CloseReason.UserClosing);
            
        }

        private void btnSelectBatch_Click(object sender, EventArgs e)
        {
            frmSelectBatch frm = new frmSelectBatch();
            frm.DataBack += SecletedBatchDataBack;
            frm.ShowDialog();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
