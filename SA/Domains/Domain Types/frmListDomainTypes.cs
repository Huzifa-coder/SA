using BusinessLayer;
using SA.Batches;
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
    public partial class frmListDomainTypes : Form
    {
        DataTable _dtDomainTypes = new DataTable();

        public frmListDomainTypes()
        {
            InitializeComponent();
        }

        private void frmListDomains_Load(object sender, EventArgs e)
        {
            _dtDomainTypes = clsDomainType.GetDomainTypes();


            if (_dtDomainTypes != null)
            {
                dgvDomainTypes.DataSource = _dtDomainTypes;
                lbRecords.Text = dgvDomainTypes.Rows.Count.ToString();
                cbFilterBy.SelectedIndex = 0;
            }
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            frmAddEditDomainType frm = new frmAddEditDomainType();
            frm.ShowDialog();

            frmListDomains_Load(null, null);
        }

        private void tbFilterValue_TextChanged(object sender, EventArgs e)
        {
            if (dgvDomainTypes.RowCount <= 0)
                return;

            string filterColumn = "";

            switch ((string)cbFilterBy.SelectedItem)
            {

                case "Name":
                    filterColumn = "DomainTypeName";

                    break;

                default:
                    filterColumn = "None";
                    break;
            }

            if (filterColumn == "None" || tbFilterValue.Text.Trim() == "")
            {

                _dtDomainTypes.DefaultView.RowFilter = "";
                lbRecords.Text = dgvDomainTypes.Rows.Count.ToString();
                return;
            }

            _dtDomainTypes.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", filterColumn, tbFilterValue.Text.Trim());

            lbRecords.Text = dgvDomainTypes.Rows.Count.ToString();
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

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddEditDomainType frm = new frmAddEditDomainType((int)dgvDomainTypes.CurrentRow.Cells[0].Value);
            frm.ShowDialog();

            frmListDomains_Load(null, null);
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int id = (int)dgvDomainTypes.CurrentRow.Cells[0].Value;

            if (MessageBox.Show("Are Do You Want To Delete This Domain Type : \n" + id, "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {

                if (clsDomainType.Delete(id))
                {
                    MessageBox.Show("Domain Type Deleted Successfully.");

                    frmListDomains_Load(null, null);
                }
                else
                {
                    MessageBox.Show("Faild To delete This Domain Type", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListDomains_Load(null, null);

        }

        private void cmsDomainTypes_Opening(object sender, CancelEventArgs e)
        {
            bool enable = dgvDomainTypes.RowCount >= 1;
            
            editInfoToolStripMenuItem.Enabled = enable;
            deleteToolStripMenuItem.Enabled = enable; 
        }
    }
}
