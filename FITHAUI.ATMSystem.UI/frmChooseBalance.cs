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
    public partial class frmChooseBalance : Form
    {
        private static string _cardNo;
        public string CardNo { get => _cardNo; set => _cardNo = value; }
        public frmChooseBalance()
        {
            InitializeComponent();
        }

        private void btnDisplayScreen_Click(object sender, EventArgs e)
        {
            frmBalanceScreen balanceScreen = new frmBalanceScreen();
            balanceScreen.CardNo = CardNo;
            this.Close();
            balanceScreen.Show();
        }

        private void frmChooseBalance_Load(object sender, EventArgs e)
        {

        }
    }
}
