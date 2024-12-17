using BusinessLayer;
using SA.Courses;
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
    public partial class frmListPayments : Form
    {

        DataTable _dtPaymentList = new DataTable();

        public frmListPayments()
        {
            InitializeComponent();
        }

        private void frmListPayments_Load(object sender, EventArgs e)
        {
            _dtPaymentList = clsPayment.GetPayments();


            if (_dtPaymentList != null)
            {
                dgvPayments.DataSource = _dtPaymentList;
                lbRecords.Text = dgvPayments.Rows.Count.ToString();
                cbFilterBy.SelectedIndex = 0;
            }
        }

        private void tbFilterValue_TextChanged(object sender, EventArgs e)
        {
            if (dgvPayments.RowCount <= 0)
                return;

            string filterColumn = "";

            switch ((string)cbFilterBy.SelectedItem)
            {

                case "Full Name":
                    filterColumn = "FullName";

                    break;

                case "Created By":
                    filterColumn = "CreatedBy";

                    break;

                default:
                    filterColumn = "None";
                    break;

            }

            if (filterColumn == "None" || tbFilterValue.Text.Trim() == "")
            {

                _dtPaymentList.DefaultView.RowFilter = "";
                lbRecords.Text = dgvPayments.Rows.Count.ToString();
                return;
            }

            _dtPaymentList.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", filterColumn, tbFilterValue.Text.Trim());

            lbRecords.Text = dgvPayments.Rows.Count.ToString();
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbFilterValue.Visible = ((string)cbFilterBy.SelectedItem != "None");

            if (tbFilterValue.Visible)
            {
                tbFilterValue.Text = "";
                tbFilterValue.Focus();
            }

        }

        private void deletePaymentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int id = (int)dgvPayments.CurrentRow.Cells[0].Value;

            if (MessageBox.Show("Are Do You Want To Delete This Payment : \n" + id, "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {

                if (clsPayment.Delete(id))
                {
                    MessageBox.Show("Payment Deleted Successfully.");

                    frmListPayments_Load(null, null);
                }
                else
                {
                    MessageBox.Show("Faild To delete This Payment", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void editPersonInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int paymentID = (int)dgvPayments.CurrentRow.Cells[0].Value;
            int studentID = (int)dgvPayments.CurrentRow.Cells[1].Value;

            frmAddEditPayments frm = new frmAddEditPayments(studentID, paymentID);
            frm.ShowDialog();

            frmListPayments_Load(null, null);
        }

        private void paymentInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int paymentID = (int)dgvPayments.CurrentRow.Cells[0].Value;

            frmPaymentInfo frm = new frmPaymentInfo(paymentID);
            frm.ShowDialog();
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListPayments_Load(null, null);

        }

        private void cmsPayments_Opening(object sender, CancelEventArgs e)
        {
            bool enable = dgvPayments.RowCount >= 1;
           
            paymentInfoToolStripMenuItem.Enabled = enable;   
            editInfoToolStripMenuItem.Enabled = enable;    
            deleteToolStripMenuItem.Enabled = enable;
            
        }
    }
}
