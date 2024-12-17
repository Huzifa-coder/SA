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
    public partial class frmLisTutorFreeTime : Form
    {
        int _TutorID;
        DataTable _dtTutorFreeTimeList;

        public frmLisTutorFreeTime(int TutorID)
        {
            InitializeComponent();

            _TutorID = TutorID;
        }

        private void frmLisTutorFreeTime_Load(object sender, EventArgs e)
        {
            _dtTutorFreeTimeList = clsTutor.GetAvalableTime(_TutorID);

            if(_dtTutorFreeTimeList != null)
            {
                dgvTutors.DataSource = _dtTutorFreeTimeList;
            }
        }
    }
}
