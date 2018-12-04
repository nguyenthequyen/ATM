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
    public partial class frmListServices : Form
    {
        private static string _cardNo;
        public string CardNo { get => _cardNo; set => _cardNo = value; }
        public frmListServices()
        {
            InitializeComponent();
        }

        private void btnBalanceStatement_Click(object sender, EventArgs e)
        {
            this.Close();
            frmChooseBalanceStatement chooseBalanceStatement = new frmChooseBalanceStatement();
            chooseBalanceStatement.CardNo = CardNo;
            chooseBalanceStatement.Show();
        }

        private void frmListServices_Load(object sender, EventArgs e)
        {

        }
        private void btnWithDraw_Click(object sender, EventArgs e)
        {
            this.Close();
            frmWithdrawMain withDraw = new frmWithdrawMain();
            withDraw.CardNo = CardNo;
            withDraw.Show();
        }
        private void btnChangePIN_Click(object sender, EventArgs e)
        {
            this.Close();
            frmChangePIN changePIN = new frmChangePIN();
            changePIN.CardNo = CardNo;
            changePIN.Show();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            frmValidateCard validateCard = new frmValidateCard();
            validateCard.Show();
            this.Close();
        }
    }
}
