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
    public partial class frmInputAccountOtherBank : Form
    {

        private static string _cardNo;
        public string CardNo { get => _cardNo; set => _cardNo = value; }

        public frmInputAccountOtherBank()
        {
            InitializeComponent();
        }

        private void btnChooseYes_Click(object sender, EventArgs e)
        {
            frmInputAmountMoneyOtherBank frmInputAmountMoneyOtherBank = new frmInputAmountMoneyOtherBank();
            frmInputAmountMoneyOtherBank.CardNo = CardNo;
            frmInputAmountMoneyOtherBank.Show();
            this.Hide();
        }
    }
}
