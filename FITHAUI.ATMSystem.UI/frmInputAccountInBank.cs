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
    public partial class frmInputAccountInBank : Form
    {

        private static string _cardNo;
        public string CardNo { get => _cardNo; set => _cardNo = value; }

        public frmInputAccountInBank()
        {
            InitializeComponent();
        }

        private void btnChooseTrue_Click(object sender, EventArgs e)
        {
            var frmInputAmountMoneyInBank = new frmInputAmountMoneyInBank();
            frmInputAmountMoneyInBank.CardNo = CardNo;
            frmInputAmountMoneyInBank.Show();
            this.Hide();
        }
    }
}
