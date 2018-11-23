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
    public partial class frmChooseBalanceStatement : Form
    {
        private static string _cardNo;
        public string CardNo { get => _cardNo; set => _cardNo = value; }
        public frmChooseBalanceStatement()
        {
            InitializeComponent();
        }

        private void frmChooseBalanceStatement_Load(object sender, EventArgs e)
        {

        }

        private void btnServiceBalance_Click(object sender, EventArgs e)
        {
            frmChooseBalance chooseBalance = new frmChooseBalance();
            chooseBalance.CardNo = CardNo;
            chooseBalance.Show();
            this.Close();
        }
    }
}
