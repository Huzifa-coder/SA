using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SA.Batches
{
    public partial class frmBatchInfo : Form
    {
        int BatchID = -1;

        public frmBatchInfo(int batchID)
        {
            InitializeComponent();
            BatchID = batchID;
        }

        private void frmBatchInfo_Load(object sender, EventArgs e)
        {
            ctrlBatchInfo1.LoadBatchInfo(BatchID);
        }
    }
}
