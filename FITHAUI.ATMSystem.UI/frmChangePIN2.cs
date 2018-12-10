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
    public partial class frmChangePIN2 : Form
    {
        SetTextInput st = new SetTextInput();
        Card_BUL Card_BUL = new Card_BUL();
        Log_BUL Log_BUL = new Log_BUL();
        private static string _cardNo;
        public string CardNo { get => _cardNo; set => _cardNo = value; }
        private static int _pin;
        public int Pin { get => _pin; set => _pin = value; }
        public frmChangePIN2()
        {
            InitializeComponent();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {

            if (int.Parse(txtNewPINAgain.Text) == Pin)
            {
                //TODO: Thêm số cây ATM
                //Log_BUL.CreateLog(DateTime.Now, 0, "09da2d0c-dd3e-4530-bb8d-98445d6457ae", "b936bf52-94d0-488f-bcda-1e4f1ecc422f", "", txtCardNo.Text, "");
                frmChangePINSuccess changePINSuccess = new frmChangePINSuccess();
                Card_BUL.ChangePIN(CardNo, Pin.ToString());
                changePINSuccess.Show();
                Log_BUL.CreateLog(DateTime.Now, 0, "", "09da2d0c-dd3e-4530-bb8d-98445d6457ae", "b936bf52-94d0-488f-bcda-1e4f1ecc422f", txtCardNo.Text, "");
                this.Close();
            }
            else
            {
                frmChangePINFail changePINFail = new frmChangePINFail();
                changePINFail.Show();
                this.Close();
            }

        }

        private void btnCorrection_Click(object sender, EventArgs e)
        {
            txtNewPINAgain.Text = "";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            frmValidateCard validateCard = new frmValidateCard();
            validateCard.Show();
            this.Close();
        }

        private void btnOne_Click(object sender, EventArgs e)
        {
            var number = st.SetTextCardNo("1", txtNewPINAgain.Text);
            txtNewPINAgain.Text = number;
        }

        private void btnTwo_Click(object sender, EventArgs e)
        {
            var number = st.SetTextCardNo("2", txtNewPINAgain.Text);
            txtNewPINAgain.Text = number;
        }

        private void btnThree_Click(object sender, EventArgs e)
        {
            var number = st.SetTextCardNo("3", txtNewPINAgain.Text);
            txtNewPINAgain.Text = number;
        }

        private void btnFour_Click(object sender, EventArgs e)
        {
            var number = st.SetTextCardNo("4", txtNewPINAgain.Text);
            txtNewPINAgain.Text = number;
        }

        private void btnFive_Click(object sender, EventArgs e)
        {
            var number = st.SetTextCardNo("5", txtNewPINAgain.Text);
            txtNewPINAgain.Text = number;
        }

        private void btnSix_Click(object sender, EventArgs e)
        {
            var number = st.SetTextCardNo("6", txtNewPINAgain.Text);
            txtNewPINAgain.Text = number;
        }

        private void btnSeven_Click(object sender, EventArgs e)
        {
            var number = st.SetTextCardNo("7", txtNewPINAgain.Text);
            txtNewPINAgain.Text = number;
        }

        private void btnEight_Click(object sender, EventArgs e)
        {
            var number = st.SetTextCardNo("8", txtNewPINAgain.Text);
            txtNewPINAgain.Text = number;
        }

        private void btnNine_Click(object sender, EventArgs e)
        {
            var number = st.SetTextCardNo("9", txtNewPINAgain.Text);
            txtNewPINAgain.Text = number;
        }

        private void btnZero_Click(object sender, EventArgs e)
        {
            var number = st.SetTextCardNo("0", txtNewPINAgain.Text);
            txtNewPINAgain.Text = number;
        }
    }
}
