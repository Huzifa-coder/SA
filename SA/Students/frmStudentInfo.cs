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
    public partial class frmStudentInfo : Form
    {
        int _StudentID = -1;
        public frmStudentInfo(int studentID)
        {
            InitializeComponent();
            _StudentID = studentID;
        }

        private void frmStudentInfo_Load(object sender, EventArgs e)
        {
            ctrlStudentInfo1.LoadStudentInfo(_StudentID);
        }

    }
}
