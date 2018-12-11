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
    public partial class frmWithdrawMain : Form
    {
        private string cardNo;
        public frmWithdrawMain()
        {
            InitializeComponent();
        }

        public string CardNo { get => cardNo; set => cardNo = value; }

        Config_BUL config_BUL = new Config_BUL();
        Account_BUL account_BUL = new Account_BUL();
        StockBUL stockBUL = new StockBUL();
        WithdrawLimitBUL withdrawLimitBUL = new WithdrawLimitBUL();
        Log_BUL log_BUL = new Log_BUL();

        private void btn10tr_Click(object sender, EventArgs e)
        {
            withdraw(10000000, false);
        }

        private void btn5tr_Click(object sender, EventArgs e)
        {
            withdraw(5000000, false);
        }

        private void btn4tr_Click(object sender, EventArgs e)
        {
            withdraw(4000000, false);
        }

        private void btn3tr_Click(object sender, EventArgs e)
        {
            withdraw(3000000, false);
        }

        private void btn2tr_Click(object sender, EventArgs e)
        {
            withdraw(2000000, false);
        }

        private void btn1tr_Click(object sender, EventArgs e)
        {
            withdraw(1000000, false);
        }

        private void btn500_Click(object sender, EventArgs e)
        {
            withdraw(500000, false);
        }

        private void btnSoKhac_Click(object sender, EventArgs e)
        {
            frmWithDraw withdraw = new frmWithDraw();
            withdraw.CardNo = cardNo;
            withdraw.Show();

            this.Close();
        }

        public bool withdraw(int money, bool ortherMoney)
        {
            bool checkOverMoneySystem = config_BUL.CheckMoney(money);
            bool checkBalanceAndOD = account_BUL.CheckBalanceAndOverDraft(cardNo, money);    // Chưa vượt quá => true (ktra trong bảng OverDraft)
            // Chưa vượt quá => true (ktra trong bảng Withdraw Limit)
            bool checkWithdrawLimit = withdrawLimitBUL.checkWithdrawLimit("542ed769 - f0d8 - 48b4 - ba5c - ddf600a85be1", "b936bf52-94d0-488f-bcda-1e4f1ecc422f", cardNo, money);

            if (!checkOverMoneySystem)   // Vượt quá số tiền rút của cây / 1 lần rút (Bảng Config)
            {
                frmOverMoneySystem frmOverMoneySystem = new frmOverMoneySystem();

                Task delay = Task.Delay(4000);
                frmOverMoneySystem.Show();
                this.Hide();
                delay.Wait();
                frmOverMoneySystem.Close();
                if (ortherMoney)
                    this.Close();
                else
                    this.Show();
            }
            else if (!checkBalanceAndOD)   // Vượt quá thấu chi + số dư (Bảng OverDraft + Account)
            {
                frmOverdraftAndBalance frmOverdraftAndBalance = new frmOverdraftAndBalance();
                Task delay = Task.Delay(4000);
                frmOverdraftAndBalance.Show();
                this.Hide();
                delay.Wait();
                frmOverdraftAndBalance.Close();
                if (ortherMoney)
                    this.Close();
                else
                    this.Show();
            }
            else if (!checkWithdrawLimit)  // Vượt quá số tiền rút trong ngày (Bảng WithdrawLimit + Bảng Log)
            {
                frmOverMoneyInDay frmOverMoneyInDay = new frmOverMoneyInDay();
                Task delay = Task.Delay(4000);
                frmOverMoneyInDay.Show();
                this.Hide();
                delay.Wait();
                frmOverMoneyInDay.Close();
                if (ortherMoney)
                    this.Close();
                else
                    this.Show();
            }
            else
            {
                string updateStock = stockBUL.UpdateQuantity(money);    // ErrorMoneyType;  SystemError;    Success

                if (updateStock.Equals("ErrorMoneyType"))    // Không phải bội số
                {
                    frmMultiplesError frmMultiplesError = new frmMultiplesError();
                    Task delay = Task.Delay(4000);
                    frmMultiplesError.Show();
                    this.Hide();
                    delay.Wait();
                    frmMultiplesError.Close();
                    if (ortherMoney)
                        this.Close();
                    else
                        this.Show();
                }
                else if (updateStock.Equals("SystemError"))     // Hệ thống hết tiền
                {
                    frmSystemOutOfMoney frmSystemOutOfMoney = new frmSystemOutOfMoney();
                    Task delay = Task.Delay(4000);
                    frmSystemOutOfMoney.Show();
                    this.Hide();
                    delay.Wait();
                    frmSystemOutOfMoney.Close();
                    if (ortherMoney)
                        this.Close();
                    else
                        this.Show();
                }
                else  // Thành công
                {
                    account_BUL.UpdateBalance(money, cardNo);
                    // Ghi log
                    log_BUL.CreateLog(DateTime.Now,decimal.Parse(money.ToString()), "SUCCESS", "542ed769-f0d8-48b4-ba5c-ddf600a85be1", "b936bf52-94d0-488f-bcda-1e4f1ecc422f", cardNo, "");

                    frmBill bill = new frmBill();
                    bill.Money = money;
                    bill.CardNo = cardNo;
                    bill.Show();
                    this.Close();
                    return true;
                }
            }
            return false;
        }
    }
}
