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
    public partial class frmInputAmountMoneyOtherBank : Form
    {
        private static string _cardNo;
        public string CardNo { get => _cardNo; set => _cardNo = value; }

        public frmInputAmountMoneyOtherBank()
        {
            InitializeComponent();
        }

        private void btnChooseYes_Click(object sender, EventArgs e)
        {
            var frmCashTransferAccountReceived = new frmCashTransferAccountReceived();
            frmCashTransferAccountReceived.CardNo = CardNo;
            frmCashTransferAccountReceived.Show();
            this.Hide();
        }
    }
}
