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
    public partial class ctrlPersonInfo : UserControl
    {
        private int _PersonID = -1;
        private clsPerson _Person;

        public int PersonID { get { return _PersonID; } }
        public clsPerson Person { get { return _Person; } }


        public ctrlPersonInfo()
        {
            InitializeComponent();
        }

        public void LoadPersonInfo(int PersonID)
        {
            _Person = clsPerson.Find(PersonID);

            if (_Person == null)
            {
                MessageBox.Show($"No Person With ID : {PersonID} Is Found", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _PersonID = PersonID;

            lbPersonID.Text = PersonID.ToString();
            lbFullName.Text = Person.FullNamee;

        }

    }
}
