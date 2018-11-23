using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FITHAUI.ATMSystem.UI
{
    public partial class frmPayTransactionInBank : Form
    {
        public frmPayTransactionInBank()
        {
            InitializeComponent();
        }

        private void btnChooseYes_Click(object sender, EventArgs e)
        {
            frmWaitCashTransfer frmWaitCashTransfer = new frmWaitCashTransfer();
            frmWaitCashTransfer.Show();
            this.Hide();
        }
    }
}
