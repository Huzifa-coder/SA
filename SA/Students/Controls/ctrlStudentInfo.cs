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

namespace SA.Students.Controls
{
    public partial class ctrlStudentInfo : UserControl
    {
        int _StudentID = -1;
        clsStudent _Student;

        public int StudentID { get { return _StudentID; } }
        public clsStudent Student { get { return _Student; } }

        public ctrlStudentInfo()
        {
            InitializeComponent();
        }

        public void LoadStudentInfo(int StudentID)
        {
            _Student = clsStudent.FindByStudentID(StudentID);

            if(_Student == null)
            {
                MessageBox.Show($"There Are No Student With {StudentID}.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _StudentID = StudentID;
            ctrlPersonInfo1.LoadPersonInfo(_Student.PersonID);

            lbStudentID.Text = Student.StudentID.ToString();
            lbEmail.Text = Student.Email.ToString();
            lbPhone.Text = Student.Phone.ToString();
            lbJoinDate.Text = Student.JoinDate.ToShortDateString();
            lbCreatedBy.Text = Student.UserCreateByInfo.UserID;

        }
    }
}
