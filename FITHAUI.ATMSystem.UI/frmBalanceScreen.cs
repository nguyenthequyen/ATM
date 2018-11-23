using FITHAUI.ATMSystem.BULs.CheckBalance;
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
    public partial class frmBalanceScreen : Form
    {
        private static string _cardNo;
        public string CardNo { get => _cardNo; set => _cardNo = value; }
        Balance_BUL balance_BUL = new Balance_BUL();
        Account account = new Account();
        public frmBalanceScreen()
        {
            InitializeComponent();
        }
        public void DisplayScreen()
        {
            txtBalance.Text =  balance_BUL.GetBalance(CardNo).ToString() + " VND";
            txtBalanceRight.Text = balance_BUL.GetBalanceRight(CardNo).ToString() + " VND";
        }
        private void frmBalanceScreen_Load(object sender, EventArgs e)
        {
            DisplayScreen();
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            
        }
    }
}
