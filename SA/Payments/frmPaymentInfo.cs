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
    public partial class frmPaymentInfo : Form
    {
        int _PaymentID;
        public frmPaymentInfo(int paymentID)
        {
            InitializeComponent();
            _PaymentID = paymentID;
        }

        private void frmPaymentInfo_Load(object sender, EventArgs e)
        {
            ctrlPaymentInfo1.LoadPaymentInfo(_PaymentID);
        }
    }
}
