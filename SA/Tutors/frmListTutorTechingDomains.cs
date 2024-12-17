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
    public partial class frmListTutorTechingDomains : Form
    {
        DataTable _dtTutorTeachingDomain;

        int _TutorID = -1;

        public frmListTutorTechingDomains(int TutorID)
        {
            InitializeComponent();

            _TutorID = TutorID;
        }

        private void frmListTutorTechingDomains_Load(object sender, EventArgs e)
        {
            _dtTutorTeachingDomain = clsTeachingDomain.GetTeachingDomains(_TutorID);

            if(_dtTutorTeachingDomain.Rows.Count > 0)
            {
                dgvTutorTeachingDomains.DataSource = _dtTutorTeachingDomain;
                lbRecords.Text = dgvTutorTeachingDomains.RowCount.ToString();
            }

        }

        private void btnAddNewDomainType_Click(object sender, EventArgs e)
        {
            frmAddTeachingDomain frm = new frmAddTeachingDomain(_TutorID);
            frm.ShowDialog();

            frmListTutorTechingDomains_Load(null, null);
        }

        private void deletePersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int id = (int)dgvTutorTeachingDomains.CurrentRow.Cells[0].Value;

            if (!(MessageBox.Show("Are Do You Want To Delete Tutor Teaching Domain : \n" + id, "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK))
            {
                return;
            }

            if (!clsTeachingDomain.Delete(id))
            {
                MessageBox.Show("Faild To delete This Tutor Teaching Domain", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            MessageBox.Show("Tutor Teaching Domain Deleted Successfully.");
            frmListTutorTechingDomains_Load(null, null);
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListTutorTechingDomains_Load(null, null);
        }

        private void cmsTutorTeachingDomains_Opening(object sender, CancelEventArgs e)
        {
            bool enable = dgvTutorTeachingDomains.RowCount >= 1;

            deleteToolStripMenuItem.Enabled = enable;          
        }
    }
}
