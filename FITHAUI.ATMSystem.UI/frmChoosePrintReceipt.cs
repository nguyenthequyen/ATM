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
    public partial class frmChoosePrintReceipt : Form
    {
        private static string _cardNo;
        public string CardNo { get => _cardNo; set => _cardNo = value; }

        public frmChoosePrintReceipt()
        {
            InitializeComponent();
        }

        private void btnChoosePrintReceipt_Click(object sender, EventArgs e)
        {
            frmPayTransactionInBank frmPayTransactionInBank = new frmPayTransactionInBank();
            frmPayTransactionInBank.CardNo = CardNo;
            frmPayTransactionInBank.Show();
            this.Hide();
        }

        private void btnChooseDontPrintReceipt_Click(object sender, EventArgs e)
        {
            frmPayTransactionInBank frmPayTransactionInBank = new frmPayTransactionInBank();
            frmPayTransactionInBank.Show();
            this.Hide();
        }
    }
}
