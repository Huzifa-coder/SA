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
    public partial class frmAddTeachingDomain : Form
    {
        int _TutorID = -1;

        clsTeachingDomain teachingDomain = new clsTeachingDomain();

        public frmAddTeachingDomain(int tutorID)
        {
            InitializeComponent();
            _TutorID = tutorID;
        }

        private void frmAddTeachingDomain_Load(object sender, EventArgs e)
        {
            _LoadDomainTypesListInComboBox();

            cbDomainType.SelectedIndex = 0;
            cbDomain.SelectedIndex = 0;
        }

        private void _LoadDomainTypesListInComboBox()
        {
            DataTable dt = clsDomainType.GetDomainTypes();

            foreach (DataRow dr in dt.Rows)
            {
                cbDomainType.Items.Add(dr["DomainTypeName"].ToString());
            }
        }

        private void _LoadDomainsForTypeInComboBox(string DomainTypeName)
        {
            cbDomain.Items.Clear();

            DataTable dt = clsDomain.GetDomains(clsDomainType.Find(DomainTypeName).DomainTypeID);

            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    cbDomain.Items.Add(dr["DomainName"].ToString());
                }
            }
        }

        private void cbDomainType_SelectedIndexChanged(object sender, EventArgs e)
        {
            _LoadDomainsForTypeInComboBox((string)cbDomainType.SelectedItem);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                return;
            }

            if(cbDomainType.SelectedItem == null)
            {
                MessageBox.Show("Please Choice A Domain Type.");
                return;
            }

            if(cbDomain.SelectedItem == null)
            {
                MessageBox.Show("Please Choice A Domain.");
                return;
            }

            clsDomain Domain = clsDomain.Find(cbDomain.SelectedItem.ToString(), clsDomainType.Find(cbDomainType.SelectedItem.ToString()).DomainTypeID);

            if (clsTeachingDomain.IsExist(_TutorID, Domain.DomainID))
            {
                MessageBox.Show("This Domain Is Already Add To The Tutor, Choice Anther Domain", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
                

            teachingDomain.TutorID = _TutorID;
            teachingDomain.DomainID = Domain.DomainID;

            if (teachingDomain.Save())
            {
                MessageBox.Show("Tutor Teaching Domain Info Saved Successfully.");
                lbTeachingDomain.Text =teachingDomain.TeachingDomainID.ToString();

                btnCancel.PerformClick();
            }
            else
            {
                MessageBox.Show("Erorr : Tutor Teaching Domain Info Not Saved.", "Faild", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

    }
}
