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

namespace SA.Payments
{
    public partial class frmAddEditPayments : Form
    {
        enum enMode { Add, Update }
        enMode _Mode = enMode.Add;

        int _StudentID = -1;
        clsStudent _Student;

        private int _PaymentID = -1;
        private clsPayment _Payment;

        public frmAddEditPayments(int StudentID)
        {
            InitializeComponent();
            this._StudentID = StudentID;

            _Mode = enMode.Add;
        }

        public frmAddEditPayments(int StudentID, int PaymentID)
        {
            InitializeComponent();

            this._StudentID = StudentID;
            _PaymentID = PaymentID;

            _Mode = enMode.Update;
        }

        private void tbPaidAmount_KeyPress(object sender, KeyPressEventArgs e)
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

        private void tbPaidAmount_Validating(object sender, CancelEventArgs e)
        {

            if (tbPaidAmount.Text == "")
            {
                e.Cancel = true;
                tbPaidAmount.Focus();
                errorProvider1.SetError(tbPaidAmount, "Please Fill This Empty Area");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(tbPaidAmount, "");
            }

            if (Convert.ToInt32(tbPaidAmount.Text.ToString()) > GetFullAmount())
            {
                e.Cancel = true;
                tbPaidAmount.Focus();
                errorProvider1.SetError(tbPaidAmount, "Paid Amount Is Bigger then Fees");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(tbPaidAmount, "");
            }

        }

        private int GetFullAmount()
        {
            return _Mode == enMode.Add ? Convert.ToInt32(tbCourseFees.Text) : _Payment.Amount;
        }

        private void frmAddEditPayments_Load(object sender, EventArgs e)
        {
            _RestDefualtValues();

            if(_Mode == enMode.Update)
            {
                _LoadData();
            }
            
        }

        private void _LoadData()
        {
            _Payment = clsPayment.Find(_PaymentID);

            lbCourseID.Text = _PaymentID.ToString();
            dtpDuaDate.MinDate = _Payment.DueDate;
            dtpDuaDate.Value = _Payment.DueDate;
            tbPaidAmount.Text = _Payment.PaidAmount.ToString();

            lbCourseFees.Visible = true;
            tbCourseFees.Visible = false;
            lbCourseFees.Text = _Payment.Amount.ToString();


        }

        private void _RestDefualtValues()
        {
            _Payment = new clsPayment();

            _Student = clsStudent.FindByStudentID(_StudentID);

            dtpDuaDate.MinDate = DateTime.Now;

            lbCourseFees.Visible= false;
            tbCourseFees.Visible = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Please Complate All Faileds.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _Payment.Amount = Convert.ToInt32(tbCourseFees.Text);
            _Payment.PaidAmount = Convert.ToInt32(tbPaidAmount.Text);
            _Payment.DueDate = dtpDuaDate.Value;
            _Payment.StudentID = _StudentID;

            if (_Payment.Save())
            {
                MessageBox.Show("Payment Info Saved Successfully.");

                btnCancel.PerformClick();
            }
            else
            {
                MessageBox.Show("Erorr : Payment Info Not Saved.", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
