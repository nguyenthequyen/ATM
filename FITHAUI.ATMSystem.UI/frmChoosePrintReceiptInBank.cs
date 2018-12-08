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
    public partial class frmChoosePrintReceiptInBank : Form
    {
        private static string _cardNo;
        public string CardNo { get => _cardNo; set => _cardNo = value; }

        private static string _cardNoAccountReceived;
        public string CardNoAccountReceived { get => _cardNoAccountReceived; set => _cardNoAccountReceived = value; }

        private static string _money;
        public string Money { get => _money; set => _money = value; }

        public frmChoosePrintReceiptInBank()
        {
            InitializeComponent();
        }

        private void btnChoosePrintReceipt_Click_1(object sender, EventArgs e)
        {
            var payTransactionInBank = new frmPayTransactionInBank();
            payTransactionInBank.CardNo = CardNo;
            payTransactionInBank.CardNoAccountReceived = CardNoAccountReceived;
            payTransactionInBank.Money = Money;
            payTransactionInBank.TransferFee = 0;
            payTransactionInBank.Show();
            this.Hide();
        }

        private void btnChooseDontPrintReceipt_Click_1(object sender, EventArgs e)
        {
            var payTransactionInBank = new frmPayTransactionInBank();
            payTransactionInBank.Show();
            this.Hide();
        }
    }
}
