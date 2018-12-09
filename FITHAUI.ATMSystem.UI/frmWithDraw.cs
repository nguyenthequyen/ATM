using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FITHAUI.ATMSystem.BULs;

namespace FITHAUI.ATMSystem.UI
{
    public partial class frmWithDraw : Form
    {
        SetTextInput setTextInput = new SetTextInput();
        private string cardNo;
        public string CardNo { get => cardNo; set => cardNo = value; }
        Config_BUL config_BUL = new Config_BUL();
        Account_BUL account_BUL = new Account_BUL();
        WithdrawLimitBUL withdrawLimitBUL = new WithdrawLimitBUL();
        StockBUL stockBUL = new StockBUL();
        MoneyBUL moneyBUL = new MoneyBUL();
        
        public frmWithDraw()
        {
            InitializeComponent();
            setMultiples();
        }

        private void btnTrue_Click(object sender, EventArgs e)
        {
            int money;
            Int32.TryParse(txtInputMoney.Text, out money);

            frmWithdrawMain frmWithdrawMain = new frmWithdrawMain();
            frmWithdrawMain.CardNo = cardNo;
            this.Hide();
            if (frmWithdrawMain.withdraw(money, true))
                this.Close();
            else
            {
                this.Show();
                txtInputMoney.Clear();
            }
        }

        private void btnIgnore_Click(object sender, EventArgs e)
        {
            frmListServices listServices = new frmListServices();
            listServices.Show();
            this.Close();
        }

        private void btnFalse_Click(object sender, EventArgs e)
        {
            txtInputMoney.Clear();
        }

        private void setMultiples()
        {
            int getMultiples = stockBUL.GetMultiples();
            if(getMultiples <= 50000)
                lblShowMultiples.Text = "50,000 VND";
            else
                lblShowMultiples.Text = moneyBUL.FormatMoney(getMultiples) + " VND";
        }

        private void btnOne_Click(object sender, EventArgs e)
        {
            var number = setTextInput.SetTextInputMoney("1", txtInputMoney.Text);
            txtInputMoney.Text = number;
        }

        private void btnTwo_Click(object sender, EventArgs e)
        {
            var number = setTextInput.SetTextInputMoney("2", txtInputMoney.Text);
            txtInputMoney.Text = number;
        }

        private void btnThree_Click(object sender, EventArgs e)
        {
            var number = setTextInput.SetTextInputMoney("3", txtInputMoney.Text);
            txtInputMoney.Text = number;
        }

        private void btnFour_Click(object sender, EventArgs e)
        {
            var number = setTextInput.SetTextInputMoney("4", txtInputMoney.Text);
            txtInputMoney.Text = number;
        }

        private void btnFive_Click(object sender, EventArgs e)
        {
            var number = setTextInput.SetTextInputMoney("5", txtInputMoney.Text);
            txtInputMoney.Text = number;
        }

        private void btnSix_Click(object sender, EventArgs e)
        {
            var number = setTextInput.SetTextInputMoney("6", txtInputMoney.Text);
            txtInputMoney.Text = number;
        }

        private void btnSeven_Click(object sender, EventArgs e)
        {
            var number = setTextInput.SetTextInputMoney("7", txtInputMoney.Text);
            txtInputMoney.Text = number;
        }

        private void btnEight_Click(object sender, EventArgs e)
        {
            var number = setTextInput.SetTextInputMoney("8", txtInputMoney.Text);
            txtInputMoney.Text = number;
        }

        private void btnNine_Click(object sender, EventArgs e)
        {
            var number = setTextInput.SetTextInputMoney("9", txtInputMoney.Text);
            txtInputMoney.Text = number;
        }

        private void btnZero_Click(object sender, EventArgs e)
        {
            var number = setTextInput.SetTextInputMoney("0", txtInputMoney.Text);
            txtInputMoney.Text = number;
        }
    }
}
