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

namespace SA.Batches.Controls
{
    public partial class ctrlBatchInfo : UserControl
    {
        int _BatchID = -1;
        clsBatch _Batch;

        public int BatchID { get { return _BatchID; } }
        public clsBatch Batch { get { return _Batch; } }

        public ctrlBatchInfo()
        {
            InitializeComponent();
        }

        public  void LoadBatchInfo(int BatchID)
        {
            _Batch = clsBatch.Find(BatchID);

            if( _Batch == null )
            {
                MessageBox.Show($"There Are No Batch With ID : {BatchID} ");
                return;
            }

            _BatchID = BatchID; 

            lbBatchID.Text = _BatchID.ToString();
            lbBatchName.Text = _Batch.Name;
            lbTutor.Text = _Batch.TutorInfo.PersonInfo.FullNamee;
            lbStartDate.Text = _Batch.StartDate.ToShortDateString();
            lbEndDate.Text = _Batch.EndDate.ToShortDateString();
            lbCapacity.Text = _Batch.Capacity.ToString();
            lbMode.Text = _Batch.StringMode;
            lbStatus.Text = _Batch.Status.ToString();
        }
    }
}
