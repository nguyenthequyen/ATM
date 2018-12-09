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
            var inputAccountInBank = new frmInputAccountInBank();
            inputAccountInBank.CardNo = CardNo;
            inputAccountInBank.Show();
            this.Hide();
        }

        private void btnChooseTransferOtherBank_Click_1(object sender, EventArgs e)
        {
            var inputAccountOtherBank = new frmInputAccountOtherBank();
            inputAccountOtherBank.CardNo = CardNo;
            inputAccountOtherBank.Show();
            this.Hide();
        }

        private void button24_Click(object sender, EventArgs e)
        {
            frmValidateCard validateCard = new frmValidateCard();
            validateCard.Show();
            this.Close();
        }
    }
}
