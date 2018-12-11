using System;
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

        private static string _accountNOReceived;
        public string AccountNOReceived { get => _accountNOReceived; set => _accountNOReceived = value; }

        private static string _money;
        public string Money { get => _money; set => _money = value; }

        public void GetNameCustormer(string accountNOReceived)
        {
            var nameCustormer = cashTransferBUL.GetNameCustomer(accountNOReceived);
            lblCustomerName.Text = nameCustormer;
        }

        private void frmCashTransferAccountReceivedOtherBank_Load(object sender, EventArgs e)
        {
            GetNameCustormer(AccountNOReceived);
            lblCardNumber.Text = AccountNOReceived;
            lblMoney.Text = Money;
        }

        private void btnChooseAccept_Click(object sender, EventArgs e)
        {
            if (cashTransferBUL.CheckCardNo(AccountNOReceived))
            {
                frmChoosePrintReceiptOtherBank choosePrintReceipt = new frmChoosePrintReceiptOtherBank();
                choosePrintReceipt.CardNo = CardNo;
                choosePrintReceipt.AccountNOReceived = AccountNOReceived;
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

        private void button24_Click(object sender, EventArgs e)
        {
            frmValidateCard validateCard = new frmValidateCard();
            validateCard.Show();
            this.Close();
        }

        private void btnChooseCancel_Click(object sender, EventArgs e)
        {
            frmListServices frmList = new frmListServices();
            frmList.CardNo = CardNo;
            this.Close();
            frmList.Show();
        }
    }
}
