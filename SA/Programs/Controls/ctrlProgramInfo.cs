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

namespace SA.Courses.Controls
{
    public partial class ctrlProgramInfo : UserControl
    {

        int _ProgramID = -1;
        clsProgram _Program;

        public int ProgramID { get { return _ProgramID; } }
        public clsProgram Program { get { return _Program; } }


        public ctrlProgramInfo()
        {
            InitializeComponent();
        }

        public void LoadCourseInfo(int ProgramID)
        {
            _Program = clsProgram.Find(ProgramID);

            if( _Program == null )
            {
                MessageBox.Show($"There Are No Course Wiht ID : {ProgramID}");
                return;
            }

            _ProgramID = ProgramID;

            lbCourseID.Text = ProgramID.ToString();  
            lbCourseName.Text = _Program.ProgramName;
            lbDuration.Text = _Program.Duration;
            lbDomain.Text  = _Program.DomainInfo.DomainName;
            lbDomainType.Text = _Program.DomainInfo.DomainTpyeInfo.DomainTypeName;

        }

    }
}
