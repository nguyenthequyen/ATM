﻿using System;
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
    public partial class frmInputAmountMoneyOtherBank : Form
    {
        SetTextInput setTextInput = new SetTextInput();
        private static string _cardNo;
        public string CardNo { get => _cardNo; set => _cardNo = value; }
        private static string _accountNOReceived;
        public string AccountNOReceived { get => _accountNOReceived; set => _accountNOReceived = value; }
        public frmInputAmountMoneyOtherBank()
        {
            InitializeComponent();
        }

        private void btnChooseYes_Click(object sender, EventArgs e)
        {
            var cashTransferAccountReceivedOtherBank = new frmCashTransferAccountReceivedOtherBank();
            cashTransferAccountReceivedOtherBank.CardNo = CardNo;
            cashTransferAccountReceivedOtherBank.AccountNOReceived = AccountNOReceived;
            cashTransferAccountReceivedOtherBank.Money = txtMoney.Text;
            cashTransferAccountReceivedOtherBank.Show();
            this.Hide();
        }

        private void btnOne_Click(object sender, EventArgs e)
        {
            var number = setTextInput.SetTextCardNo("1", txtMoney.Text);
            txtMoney.Text = number;
        }

        private void btnTwo_Click(object sender, EventArgs e)
        {
            var number = setTextInput.SetTextCardNo("2", txtMoney.Text);
            txtMoney.Text = number;
        }

        private void btnThree_Click(object sender, EventArgs e)
        {
            var number = setTextInput.SetTextCardNo("3", txtMoney.Text);
            txtMoney.Text = number;
        }

        private void btnFour_Click(object sender, EventArgs e)
        {
            var number = setTextInput.SetTextCardNo("4", txtMoney.Text);
            txtMoney.Text = number;
        }

        private void btnFive_Click(object sender, EventArgs e)
        {
            var number = setTextInput.SetTextCardNo("5", txtMoney.Text);
            txtMoney.Text = number;
        }

        private void btnSix_Click(object sender, EventArgs e)
        {
            var number = setTextInput.SetTextCardNo("6", txtMoney.Text);
            txtMoney.Text = number;
        }

        private void btnSeven_Click(object sender, EventArgs e)
        {
            var number = setTextInput.SetTextCardNo("7", txtMoney.Text);
            txtMoney.Text = number;
        }

        private void btnEight_Click(object sender, EventArgs e)
        {
            var number = setTextInput.SetTextCardNo("8", txtMoney.Text);
            txtMoney.Text = number;
        }

        private void btnNine_Click(object sender, EventArgs e)
        {
            var number = setTextInput.SetTextCardNo("9", txtMoney.Text);
            txtMoney.Text = number;
        }

        private void btnZero_Click(object sender, EventArgs e)
        {
            var number = setTextInput.SetTextCardNo("0", txtMoney.Text);
            txtMoney.Text = number;
        }

        private void button24_Click(object sender, EventArgs e)
        {
            frmValidateCard validateCard = new frmValidateCard();
            validateCard.Show();
            this.Close();
        }

        private void btnChooseNo_Click(object sender, EventArgs e)
        {
            txtMoney.Text = "";
        }

        private void btnChooseUndo_Click(object sender, EventArgs e)
        {
            frmInputAccountOtherBank inputAccountOtherBank = new frmInputAccountOtherBank();
            inputAccountOtherBank.CardNo = CardNo;
            this.Close();
            inputAccountOtherBank.Show();
        }
    }
}
