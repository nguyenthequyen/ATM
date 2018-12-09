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
    public partial class frmCashTransferAccountWrong : Form
    {

        private static string _cardNo;
        public string CardNo { get => _cardNo; set => _cardNo = value; }

        public frmCashTransferAccountWrong()
        {
            InitializeComponent();
        }

        private void button24_Click(object sender, EventArgs e)
        {
            frmValidateCard validateCard = new frmValidateCard();
            validateCard.Show();
            this.Close();
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            frmListServices frmList = new frmListServices();
            frmList.CardNo = CardNo;
            this.Close();
            frmList.Show();
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            frmValidateCard frmValidate = new frmValidateCard();
            this.Close();
            frmValidate.Show();
        }
    }

}
