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
    public partial class frmChangePIN : Form
    {
        SetTextInput st = new SetTextInput();
        CheckLengthPIN lengthPIN = new CheckLengthPIN();
        public frmChangePIN()
        {
            InitializeComponent();
        }
        private static string _cardNo;
        public string CardNo { get => _cardNo; set => _cardNo = value; }       

        //private static int _pin;
        //public int Pin { get => _pin; set => _pin = value; }
        public string getTextBoxNewPIN()
        {
            return txtNewPIN.Text;
        }
        public void setTextBoxNewPIN(string str)
        {
                txtNewPIN.Text += str;
        }
        
        private void btnAccept_Click(object sender, EventArgs e)
        {
            var pin = lengthPIN.checkLengthPIN(txtNewPIN.Text);
            if(pin == true)
            {
                //setTextBoxNewPIN(txtNewPIN.Text);
                frmChangePIN2 changePIN2 = new frmChangePIN2();
                changePIN2.Pin = int.Parse(txtNewPIN.Text);
                changePIN2.CardNo = CardNo;
                changePIN2.Show();
                this.Close();
            }
            else
            {
                frmChangePINFail changePINFail = new frmChangePINFail();
                changePINFail.Show();
                this.Close();
            }
        }

        private void btnOne_Click(object sender, EventArgs e)
        {
            var number = st.SetTextCardNo("1", txtNewPIN.Text);
            txtNewPIN.Text = number;
        }

        private void btnTwo_Click(object sender, EventArgs e)
        {
            var number = st.SetTextCardNo("2", txtNewPIN.Text);
            txtNewPIN.Text = number;
        }

        private void btnThree_Click(object sender, EventArgs e)
        {
            var number = st.SetTextCardNo("3", txtNewPIN.Text);
            txtNewPIN.Text = number;
        }

        private void btnFour_Click(object sender, EventArgs e)
        {
            var number = st.SetTextCardNo("4", txtNewPIN.Text);
            txtNewPIN.Text = number;
        }

        private void btnFive_Click(object sender, EventArgs e)
        {
            var number = st.SetTextCardNo("5", txtNewPIN.Text);
            txtNewPIN.Text = number;
        }

        private void btnSix_Click(object sender, EventArgs e)
        {
            var number = st.SetTextCardNo("6", txtNewPIN.Text);
            txtNewPIN.Text = number;
        }

        private void btnSeven_Click(object sender, EventArgs e)
        {
            var number = st.SetTextCardNo("7", txtNewPIN.Text);
            txtNewPIN.Text = number;
        }

        private void btnEight_Click(object sender, EventArgs e)
        {
            var number = st.SetTextCardNo("8", txtNewPIN.Text);
            txtNewPIN.Text = number;
        }

        private void btnNine_Click(object sender, EventArgs e)
        {
            var number = st.SetTextCardNo("9", txtNewPIN.Text);
            txtNewPIN.Text = number;
        }

        private void btnZero_Click(object sender, EventArgs e)
        {
            var number = st.SetTextCardNo("0", txtNewPIN.Text);
            txtNewPIN.Text = number;
        }

        private void btnCorrection_Click(object sender, EventArgs e)
        {
            txtNewPIN.Text = "";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            frmValidateCard validateCard = new frmValidateCard();
            validateCard.Show();
            this.Close();
        }
    }
}
