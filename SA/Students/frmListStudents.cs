using BusinessLayer;
using SA.Batches;
using SA.Globle;
using SA.Payments;
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
    public partial class frmListStudents : Form
    {
        DataTable _dtStudentsList;
        int _BatchID = -1;

        public frmListStudents()
        {
            InitializeComponent();
        }

        public frmListStudents(int batchID)
        {
            InitializeComponent();

            _BatchID = batchID;
        }

        private void frmListStudents_Load(object sender, EventArgs e)
        {
            cbFilterBy.SelectedIndex = 0;

            if(clsGloble.CurrentUser.HasPermission(BusinessLayer.clsUser.enPermissions.All))
                _dtStudentsList = clsStudent.GetStudents(); 
            else
                _dtStudentsList = clsGloble.CurrentUser.GetStudentsList();

            if (_dtStudentsList.Rows.Count < 0)
            {
                return;
            }

            dgvStudents.DataSource = _dtStudentsList;

            if (_BatchID < 0)
                return;

            clsBatch batch = clsBatch.Find(_BatchID);

            cbFilterBy.SelectedIndex = 2;
            tbFilterValue.Text = batch.Name;

            cbFilterBy.Visible = false; 
            tbFilterValue.Visible = false;
            lbfilterText.Visible = false;

        }

        private void btnAddNewUser_Click(object sender, EventArgs e)
        {
            frmAddEditStudent frm = new frmAddEditStudent();
            frm.ShowDialog();

            frmListStudents_Load(null,null);
        }

        private void addPaymentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int id = (int)dgvStudents.CurrentRow.Cells["StudentID"].Value;          
            
            frmAddEditPayments frm = new frmAddEditPayments(id);
            frm.ShowDialog();

            frmListStudents_Load(null, null);
        }

        private void editPaymentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int student = (int)dgvStudents.CurrentRow.Cells["StudentID"].Value;
            int payment = clsPayment.FindByStudentID(student).PaymentID;

            frmAddEditPayments frm = new frmAddEditPayments(student, payment);
            frm.ShowDialog();

            frmListStudents_Load(null, null);
        }

        private void batchInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int id = clsBatch.Find(dgvStudents.CurrentRow.Cells["BatchName"].Value.ToString()).BatchID;

            frmBatchInfo frm = new frmBatchInfo(id);
            frm.ShowDialog();
        }

        private void progarmInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int id = clsBatch.Find(dgvStudents.CurrentRow.Cells["BatchName"].Value.ToString()).ProgramID;

            frmProgramInfo frm = new frmProgramInfo(id);
            frm.ShowDialog();
        }

        private void cmsStudents_Opening(object sender, CancelEventArgs e)
        {
            bool enable = dgvStudents.RowCount >= 1;
            
            addPaymentToolStripMenuItem.Enabled = enable;
            editPaymentToolStripMenuItem.Enabled = enable;
            paymentInfoToolStripMenuItem.Enabled = enable;

            batchInfoToolStripMenuItem.Enabled = enable;
            progarmInfoToolStripMenuItem.Enabled = enable;

            editStudentInfoToolStripMenuItem.Enabled = enable;
            deleteStudentToolStripMenuItem.Enabled = enable;

            if (!enable)
                return;


            bool hasPayment = clsPayment.IsExistByStudentID((int)dgvStudents.CurrentRow.Cells["StudentID"].Value);

            addPaymentToolStripMenuItem.Enabled = !hasPayment;
            editPaymentToolStripMenuItem.Enabled = hasPayment;
            paymentInfoToolStripMenuItem.Enabled = hasPayment;
        }

        private void paymentInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int id = clsPayment.FindByStudentID((int)dgvStudents.CurrentRow.Cells["StudentID"].Value).PaymentID;

            frmPaymentInfo frm = new frmPaymentInfo(id);
            frm.ShowDialog();
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {

            frmListStudents_Load(null, null);
        }

        private void editUserInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int student = (int)dgvStudents.CurrentRow.Cells["StudentID"].Value;
            
            frmAddEditStudent frm  = new frmAddEditStudent(student);
            frm.ShowDialog();

            frmListStudents_Load(null, null);
        }

        private void deletePersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int student = (int)dgvStudents.CurrentRow.Cells["StudentID"].Value;

            if (MessageBox.Show("Are You Sure To Delete This Student", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) != DialogResult.OK)
            {
                return;
            }

            if (clsStudent.Delete(student))
            {
                MessageBox.Show("Student Deleted Successfully", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                frmListStudents_Load(null, null);
               
            }
            else
            {
                MessageBox.Show("Erorr : The Student Has Not Delete", "Feild", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void tbFilterValue_TextChanged(object sender, EventArgs e)
        {
            if (dgvStudents.RowCount <= 0)
                return;

            string filterColumn = "";

            switch ((string)cbFilterBy.SelectedItem)
            {
                case "Full Name":
                    filterColumn = "fullName";

                    break;

                case "Batch Name":
                    filterColumn = "BatchName";

                    break;

                default:
                    filterColumn = "None";
                    break;
            }

            if (filterColumn == "None" || tbFilterValue.Text.Trim() == "")
            {

                _dtStudentsList.DefaultView.RowFilter = "";
                lbRecords.Text = dgvStudents.Rows.Count.ToString();
                return;
            }

            _dtStudentsList.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", filterColumn, tbFilterValue.Text.Trim());

            lbRecords.Text = dgvStudents.Rows.Count.ToString();
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbFilterValue.Visible = ((string)cbFilterBy.SelectedItem != "None");

            if ((string)cbFilterBy.SelectedItem != "None")
            {
                tbFilterValue.Text = "";
                tbFilterValue.Focus();
            }
        }

    }
}
