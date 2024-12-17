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

namespace SA.People.Controls
{
    public partial class ctrlPersonInfoWithFilter : UserControl
    {
        public event Action<int> OnPersonSelected;
        // Create a protected method to raise the event with a parameter
        protected virtual void PersonSelected(int PersonID)
        {
            Action<int> handler = OnPersonSelected;
            if (handler != null)
            {
                handler(PersonID); // Raise the event with the parameter
            }
        }


        public clsPerson Person { get { return ctrlPersonInfo1.Person; } }
        public int PersonID { get { return ctrlPersonInfo1.PersonID; } }

        public bool FilterEnabled
        {
            get { return gbFilter.Enabled; }

            set
            {
                gbFilter.Enabled = value;
            }
        }

        public bool BtnAddEnabled
        {
            get { return btnAddNewPerson.Enabled; }

            set 
            { 
                btnAddNewPerson.Enabled = value;
            }
        }

        public bool BtnSearchEnabled
        {
            get { return btnSearch.Enabled; }

            set
            {
                btnSearch.Enabled = value; 
            }
        }
        

        public ctrlPersonInfoWithFilter()
        {
            InitializeComponent();
        }

        public void FoucustbPersonID()
        {
            tbPersonID.Focus();
        }

        private void tbPersonID_Validating(object sender, CancelEventArgs e)
        {
            if (tbPersonID.Text.Equals(""))
            {
                e.Cancel = true;
                tbPersonID.Focus();
                errorProvider1.SetError(tbPersonID, "Please Enter Person ID");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(tbPersonID, "");
            }
        }

        private void btnAddNewPerson_Click_1(object sender, EventArgs e)
        {
            frmAddEditPerson frm = new frmAddEditPerson();
            frm.DataBack += DataBack;
            frm.ShowDialog();

        }

        private void DataBack(object sender, int PersonID)
        {

            if (clsPerson.IsExist(PersonID))
            {
                ctrlPersonInfo1.LoadPersonInfo(PersonID);
                tbPersonID.Text = PersonID.ToString();

                if (OnPersonSelected != null)
                    // Raise the event with a parameter
                    OnPersonSelected(ctrlPersonInfo1.PersonID);
            }

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if(!this.ValidateChildren()) return;

            int id = Convert.ToInt32(tbPersonID.Text.ToString());

            if (!clsPerson.IsExist(id))
            {
                MessageBox.Show($"No Person Found With ID : {id}", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbPersonID.Focus();
                return;
            }

            ctrlPersonInfo1.LoadPersonInfo(id);

            if (OnPersonSelected != null)
                // Raise the event with a parameter
                OnPersonSelected(ctrlPersonInfo1.PersonID);
        }

        public void LoadPersonInfo(int PersonID)
        {
            if(!clsPerson.IsExist(PersonID))
            {
                MessageBox.Show($"No Person With ID : {PersonID} Is Found", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            tbPersonID.Text = PersonID.ToString();
            ctrlPersonInfo1.LoadPersonInfo(PersonID);

            if (OnPersonSelected != null)
                // Raise the event with a parameter
                OnPersonSelected(PersonID);
        }

        private void tbPersonID_KeyPress(object sender, KeyPressEventArgs e)
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
    }
}
