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
        private static string _cardNo;
        public string CardNo { get => _cardNo; set => _cardNo = value; }

        public frmChooseKindTransfer()
        {
            InitializeComponent();
        }

        private void btnTransferInBank_Click(object sender, EventArgs e)
        {
            var frmInputAccountInBank = new frmInputAccountInBank();
            frmInputAccountInBank.CardNo = CardNo;
            frmInputAccountInBank.Show();
            this.Hide();
        }

        private void btnChooseTransferOtherBank_Click_1(object sender, EventArgs e)
        {
            var frmInputAccountOtherBank = new frmInputAccountOtherBank();
            frmInputAccountOtherBank.CardNo = CardNo;
            frmInputAccountOtherBank.Show();
            this.Hide();
        }
    }
}
