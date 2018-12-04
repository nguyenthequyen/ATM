using FITHAUI.ATMSystem.BULs;
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
    public partial class frmValidateCard : Form
    {
        SetTextInput setTextInput = new SetTextInput();
        Timer timer = new Timer();
        Card_BUL card_BUL = new Card_BUL();
        private static string _message;

        public string Message { get => _message; set => _message = value; }

        public frmValidateCard()
        {
            InitializeComponent();
        }
        /// <summary>
        /// DelayLoadForm nếu dữ liệu hợp lệ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void checkCardSuccess(object sender, EventArgs e)
        {
            timer.Stop();
            timer.Tick -= new EventHandler(checkCardSuccess);
            this.Hide();
            frmInputPin frmInputPin = new frmInputPin();
            frmInputPin.CardNo = txtCardNo.Text;
            frmInputPin.Show();
        }
        /// <summary>
        /// DelayLoadForm nếu dữ liệu không hợp lệ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void checkCardNoFailed(object sender, EventArgs e)
        {
            timer.Stop();
            timer.Tick -= new EventHandler(checkCardNoFailed);
            GetLabelCheckCardNo().Visible = true;
            txtCardNo.Text = "";          
        }         
        public Label GetLabelCheckCardNo()
        {
            return lblCheckCardNo;            
        }
        private void btnOne_Click(object sender, EventArgs e)
        {
            var number = setTextInput.SetTextCardNo("1", txtCardNo.Text);
            txtCardNo.Text = number;
        }

        private void btnTwo_Click(object sender, EventArgs e)
        {
            var number = setTextInput.SetTextCardNo("2", txtCardNo.Text);
            txtCardNo.Text = number;
        }

        private void btnThree_Click(object sender, EventArgs e)
        {
            var number = setTextInput.SetTextCardNo("3", txtCardNo.Text);
            txtCardNo.Text = number;           
        }

        private void btnFour_Click(object sender, EventArgs e)
        {
            var number = setTextInput.SetTextCardNo("4", txtCardNo.Text);
            txtCardNo.Text = number;
        }

        private void btnFive_Click(object sender, EventArgs e)
        {
            var number = setTextInput.SetTextCardNo("5", txtCardNo.Text);
            txtCardNo.Text = number;
        }

        private void btnSix_Click(object sender, EventArgs e)
        {
            var number = setTextInput.SetTextCardNo("6", txtCardNo.Text);
            txtCardNo.Text = number;
        }

        private void btnSeven_Click(object sender, EventArgs e)
        {
            var number = setTextInput.SetTextCardNo("7", txtCardNo.Text);
            txtCardNo.Text = number;
        }

        private void btnEight_Click(object sender, EventArgs e)
        {
            var number = setTextInput.SetTextCardNo("8", txtCardNo.Text);
            txtCardNo.Text = number;
        }

        private void btnNine_Click(object sender, EventArgs e)
        {
            var number = setTextInput.SetTextCardNo("9", txtCardNo.Text);
            txtCardNo.Text = number;
        }

        private void btnZero_Click(object sender, EventArgs e)
        {
            var number = setTextInput.SetTextCardNo("0", txtCardNo.Text);
            txtCardNo.Text = number;
        }
        
        private void btnAccept_Click(object sender, EventArgs e)
        {
            timer.Interval = 10;
            var checkCard = card_BUL.CheckCardNo(txtCardNo.Text);
            if (checkCard)
            {
                timer.Tick += new EventHandler(checkCardSuccess);
                timer.Start();
            }
            else
            {
                timer.Tick += new EventHandler(checkCardNoFailed);
                timer.Start();
            }
        }

        private void frmValidateCard_Load(object sender, EventArgs e)
        {

        }

        private void btnCorrect_Click(object sender, EventArgs e)
        {
            txtCardNo.Text = "";
        }
    }
}
