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
    public partial class frmChooseKindTransfer : Form
    {
        public frmChooseKindTransfer()
        {
            InitializeComponent();
        }

        private void btnTransferInBank_Click(object sender, EventArgs e)
        {
            var frmInputAccountReceiver = new frmInputAccountReceiver();
            frmInputAccountReceiver.Show();
            this.Hide();
        }

        private void btnChooseTransferOtherBank_Click_1(object sender, EventArgs e)
        {
            var frmInputAccountOtherBank = new frmInputAccountOtherBank();
            frmInputAccountOtherBank.Show();
            this.Hide();
        }
    }
}
