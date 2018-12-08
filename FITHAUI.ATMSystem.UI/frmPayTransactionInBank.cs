using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FITHAUI.ATMSystem.BULs.CashTransfer;

namespace FITHAUI.ATMSystem.UI
{
    public partial class frmPayTransactionInBank : Form
    {
        private static string _cardNo;
        public string CardNo { get => _cardNo; set => _cardNo = value; }

        private static string _cardNoAccountReceived;
        public string CardNoAccountReceived { get => _cardNoAccountReceived; set => _cardNoAccountReceived = value; }

        private static string _money;
        public string Money { get => _money; set => _money = value; }

        private static int _transferFee;
        public int TransferFee { get => _transferFee; set => _transferFee = value; }

        CashTransferBUL cashTransferBUL = new CashTransferBUL();
        public frmPayTransactionInBank()
        {
            InitializeComponent();
        }

        private void btnChooseYes_Click_1(object sender, EventArgs e)
        {
            if (cashTransferBUL.CompareBalance(int.Parse(Money), CardNo, TransferFee))
            {
                cashTransferBUL.UpdateBalance(int.Parse(Money), CardNo, CardNoAccountReceived, TransferFee);
                var waitCashTransfer = new frmWaitCashTransfer();
                waitCashTransfer.CardNo = CardNo;
                waitCashTransfer.Show();
                this.Hide();
            }
            else
            {
                frmTransactionFailed transactionFailed = new frmTransactionFailed();
                transactionFailed.Show();
                this.Hide();
            }
        }

        private void btnChooseNo_Click(object sender, EventArgs e)
        {

        }
    }
}
