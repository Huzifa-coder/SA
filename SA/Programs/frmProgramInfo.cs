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
    public partial class frmProgramInfo : Form
    {
        int _ProgramID = -1;

        public frmProgramInfo(int ProgramID)
        {
            InitializeComponent();
            _ProgramID = ProgramID;
        }

        private void frmCourseInfo_Load(object sender, EventArgs e)
        {
            ctrlProgramInfo1.LoadCourseInfo(_ProgramID);
        }

    }
}
