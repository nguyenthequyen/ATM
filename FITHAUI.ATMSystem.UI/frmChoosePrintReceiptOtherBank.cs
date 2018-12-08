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
    public partial class frmChoosePrintReceiptOtherBank : Form
    {
        public frmChoosePrintReceiptOtherBank()
        {
            InitializeComponent();
        }

        private static string _cardNo;
        public string CardNo { get => _cardNo; set => _cardNo = value; }

        private static string _cardNoAccountReceived;
        public string CardNoAccountReceived { get => _cardNoAccountReceived; set => _cardNoAccountReceived = value; }

        private static string _money;
        public string Money { get => _money; set => _money = value; }

        private void btnChoosePrintReceipt_Click(object sender, EventArgs e)
        {
            var payTransactionOtherBank = new frmPayTransactionOtherBank();
            payTransactionOtherBank.CardNo = CardNo;
            payTransactionOtherBank.CardNoAccountReceived = CardNoAccountReceived;
            payTransactionOtherBank.Money = Money;
            payTransactionOtherBank.TransferFee = 11000;
            payTransactionOtherBank.Show();
            this.Hide();
        }

        private void btnChooseDontPrintReceipt_Click(object sender, EventArgs e)
        {
            var payTransactionOtherBank = new frmPayTransactionOtherBank();
            payTransactionOtherBank.Show();
            this.Hide();
        }
    }
}
