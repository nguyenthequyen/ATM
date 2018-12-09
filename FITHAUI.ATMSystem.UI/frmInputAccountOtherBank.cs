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
        SetTextInput setTextInput = new SetTextInput();
        private static string _cardNo;
        public string CardNo { get => _cardNo; set => _cardNo = value; }

        public frmInputAccountOtherBank()
        {
            InitializeComponent();
        }

        private void btnChooseYes_Click(object sender, EventArgs e)
        {
            var inputAmountMoneyOtherBank = new frmInputAmountMoneyOtherBank();
            inputAmountMoneyOtherBank.CardNo = CardNo;
            inputAmountMoneyOtherBank.CardNoAccountReceived = txtCardNoAccountReceived.Text;
            inputAmountMoneyOtherBank.Show();
            this.Hide();
        }

        private void btnOne_Click(object sender, EventArgs e)
        {
            var number = setTextInput.SetTextCardNo("1", txtCardNoAccountReceived.Text);
            txtCardNoAccountReceived.Text = number;
        }

        private void btnTwo_Click(object sender, EventArgs e)
        {
            var number = setTextInput.SetTextCardNo("2", txtCardNoAccountReceived.Text);
            txtCardNoAccountReceived.Text = number;
        }

        private void btnThree_Click(object sender, EventArgs e)
        {
            var number = setTextInput.SetTextCardNo("3", txtCardNoAccountReceived.Text);
            txtCardNoAccountReceived.Text = number;
        }

        private void btnFour_Click(object sender, EventArgs e)
        {
            var number = setTextInput.SetTextCardNo("4", txtCardNoAccountReceived.Text);
            txtCardNoAccountReceived.Text = number;
        }

        private void btnFive_Click(object sender, EventArgs e)
        {
            var number = setTextInput.SetTextCardNo("5", txtCardNoAccountReceived.Text);
            txtCardNoAccountReceived.Text = number;
        }

        private void btnSix_Click(object sender, EventArgs e)
        {
            var number = setTextInput.SetTextCardNo("6", txtCardNoAccountReceived.Text);
            txtCardNoAccountReceived.Text = number;
        }

        private void btnSeven_Click(object sender, EventArgs e)
        {
            var number = setTextInput.SetTextCardNo("7", txtCardNoAccountReceived.Text);
            txtCardNoAccountReceived.Text = number;
        }

        private void btnEight_Click(object sender, EventArgs e)
        {
            var number = setTextInput.SetTextCardNo("8", txtCardNoAccountReceived.Text);
            txtCardNoAccountReceived.Text = number;
        }

        private void btnNine_Click(object sender, EventArgs e)
        {
            var number = setTextInput.SetTextCardNo("9", txtCardNoAccountReceived.Text);
            txtCardNoAccountReceived.Text = number;
        }

        private void btnZero_Click(object sender, EventArgs e)
        {
            var number = setTextInput.SetTextCardNo("0", txtCardNoAccountReceived.Text);
            txtCardNoAccountReceived.Text = number;
        }
    }
}
