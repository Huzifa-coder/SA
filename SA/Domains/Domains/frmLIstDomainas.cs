using BusinessLayer;
using SA.Domains.Domain_Types;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SA.Domains.Domains
{
    public partial class frmLIstDomainas : Form
    {
        DataTable _dtDomainsList = new DataTable();

        public frmLIstDomainas()
        {
            InitializeComponent();
        }

        private void frmListDomainTypes_Load(object sender, EventArgs e)
        {
            _dtDomainsList = clsDomain.GetDomains();


            if (_dtDomainsList != null)
            {
                dgvDomains.DataSource = _dtDomainsList;
                lbRecords.Text = dgvDomains.Rows.Count.ToString();
                cbFilterBy.SelectedIndex = 0;
            }
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            frmAddEditDomainType frm = new frmAddEditDomainType();
            frm.ShowDialog();

            frmListDomainTypes_Load(null, null);
        }

        private void tbFilterValue_TextChanged(object sender, EventArgs e)
        {
            if (dgvDomains.RowCount <= 0)
                return;

            string filterColumn = "";

            switch ((string)cbFilterBy.SelectedItem)
            {

                case "Domain Name":
                    filterColumn = "DomainName";

                    break;

                case "Domain Type":
                    filterColumn = "DomainTypeName";

                    break;

                default:
                    filterColumn = "None";
                    break;
            }

            if (filterColumn == "None" || tbFilterValue.Text.Trim() == "")
            {

                _dtDomainsList.DefaultView.RowFilter = "";
                lbRecords.Text = dgvDomains.Rows.Count.ToString();
                return;
            }

            _dtDomainsList.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", filterColumn, tbFilterValue.Text.Trim());

            lbRecords.Text = dgvDomains.Rows.Count.ToString();
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
            frmAddEditDomain frm = new frmAddEditDomain((int)dgvDomains.CurrentRow.Cells[0].Value);
            frm.ShowDialog();

            frmListDomainTypes_Load(null, null);
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int id = (int)dgvDomains.CurrentRow.Cells[0].Value;

            if (MessageBox.Show("Are Do You Want To Delete This Domain : \n" + id, "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {

                if (clsDomain.Delete(id))
                {
                    MessageBox.Show("Domain Deleted Successfully.");

                    frmListDomainTypes_Load(null, null);
                }
                else
                {
                    MessageBox.Show("Faild To delete This Domain", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListDomainTypes_Load(null, null);

        }

        private void cmsDomain_Opening(object sender, CancelEventArgs e)
        {
            bool enable = dgvDomains.RowCount >= 1;
            
            editInfoToolStripMenuItem.Enabled = enable;
            deleteToolStripMenuItem.Enabled = enable;
            
        }
    }
}
