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

namespace SA.Students
{
    public partial class ctrlPaymentInfo : UserControl
    {
        int _PaymentID = -1;
        clsPayment _Payment;

        public int PaymentID { get { return _PaymentID; } }
        public clsPayment Payment { get { return _Payment; } }

        public ctrlPaymentInfo()
        {
            InitializeComponent();
        }

        public void LoadPaymentInfo(int paymentID)
        {
            _Payment = clsPayment.Find(paymentID);

            if(_Payment == null)
            {
                MessageBox.Show($"There Are No Payment Found With ID : {paymentID}");
                return ;
            }

            _PaymentID = paymentID;


            ctrlStudentInfo1.LoadStudentInfo(_Payment.StudentID);

            lbPaymentID.Text = _PaymentID.ToString();
            lbAmount.Text = _Payment.PaidAmount.ToString();
            lbPaidAmount.Text = _Payment.Amount.ToString();
            lbBalance.Text = _Payment.Balance.ToString();
            lbDuaDate.Text = _Payment.DueDate.ToShortDateString();

        }

    }
}
