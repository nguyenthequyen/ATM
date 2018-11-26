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
    public partial class frmAwait : Form
    {
        SetTextInput setTextInput = new SetTextInput();
        Timer timer = new Timer();
        public frmAwait()
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
            this.Hide();
            frmInputPinFailed frmInputPinFailed = new frmInputPinFailed();
            frmInputPinFailed.Show();
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
            timer.Interval = 1;
            var maThe = "234567891";
            if (txtCardNo.Text == maThe)
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

        private void frmAwait_Load(object sender, EventArgs e)
        {

        }
    }
}
