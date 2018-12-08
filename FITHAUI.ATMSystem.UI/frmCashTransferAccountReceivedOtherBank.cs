﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FITHAUI.ATMSystem.BULs.CashTransfer;
namespace FITHAUI.ATMSystem.UI
{
    public partial class frmCashTransferAccountReceivedOtherBank : Form
    {
        public frmCashTransferAccountReceivedOtherBank()
        {
            InitializeComponent();
        }

        CashTransferBUL cashTransferBUL = new CashTransferBUL();
        private static string _cardNo;
        public string CardNo { get => _cardNo; set => _cardNo = value; }

        private static string _cardNoAccountReceived;
        public string CardNoAccountReceived { get => _cardNoAccountReceived; set => _cardNoAccountReceived = value; }

        private static string _money;
        public string Money { get => _money; set => _money = value; }

        public void GetNameCustormer(string cardNo)
        {
            var nameCustormer = cashTransferBUL.GetNameCustomer(cardNo);
            lblCustomerName.Text = nameCustormer;
        }

        private void frmCashTransferAccountReceivedOtherBank_Load(object sender, EventArgs e)
        {
            GetNameCustormer(CardNoAccountReceived);
            lblCardNumber.Text = CardNoAccountReceived;
            lblMoney.Text = Money;
        }

        private void btnChooseAccept_Click(object sender, EventArgs e)
        {
            if (cashTransferBUL.CheckCardNo(CardNoAccountReceived))
            {
                frmChoosePrintReceiptInBank choosePrintReceipt = new frmChoosePrintReceiptInBank();
                choosePrintReceipt.CardNo = CardNo;
                choosePrintReceipt.CardNoAccountReceived = CardNoAccountReceived;
                choosePrintReceipt.Money = Money;
                choosePrintReceipt.Show();
                this.Hide();
            }
            else
            {
                frmInputAccountWrong inputAccountWrong = new frmInputAccountWrong();
                inputAccountWrong.Show();
                this.Hide();
            }
        }
    }
}
