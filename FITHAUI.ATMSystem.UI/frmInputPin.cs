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
    public partial class frmInputPin : Form
    {
        SetTextInput setTextInput = new SetTextInput();
        private static string _cardNo;
        public frmInputPin()
        {
            InitializeComponent();
        }

        public string CardNo { get => _cardNo; set => _cardNo = value; }

        private void frmInputPin_Load(object sender, EventArgs e)
        {
            //MessageBox.Show(_cardNo,"Card No");
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            frmListServices listServices = new frmListServices();
            if (txtPin.Text == "123")
            {
                listServices.CardNo = CardNo;
                listServices.Show();
            }
            else
            {
                Application.Exit();
            }
        }

        private void btnOne_Click(object sender, EventArgs e)
        {
            var number = setTextInput.SetTextCardNo("1", txtPin.Text);
            txtPin.Text = number;
        }

        private void btnTwo_Click(object sender, EventArgs e)
        {
            var number = setTextInput.SetTextCardNo("2", txtPin.Text);
            txtPin.Text = number;
        }

        private void btnThree_Click(object sender, EventArgs e)
        {
            var number = setTextInput.SetTextCardNo("3", txtPin.Text);
            txtPin.Text = number;
        }

        private void btnFour_Click(object sender, EventArgs e)
        {
            var number = setTextInput.SetTextCardNo("4", txtPin.Text);
            txtPin.Text = number;
        }

        private void btnFive_Click(object sender, EventArgs e)
        {
            var number = setTextInput.SetTextCardNo("5", txtPin.Text);
            txtPin.Text = number;
        }

        private void btnSix_Click(object sender, EventArgs e)
        {
            var number = setTextInput.SetTextCardNo("6", txtPin.Text);
            txtPin.Text = number;
        }

        private void btnSeven_Click(object sender, EventArgs e)
        {
            var number = setTextInput.SetTextCardNo("7", txtPin.Text);
            txtPin.Text = number;
        }

        private void btnEight_Click(object sender, EventArgs e)
        {
            var number = setTextInput.SetTextCardNo("8", txtPin.Text);
            txtPin.Text = number;
        }

        private void btnNine_Click(object sender, EventArgs e)
        {
            var number = setTextInput.SetTextCardNo("9", txtPin.Text);
            txtPin.Text = number;
        }

        private void btnZero_Click(object sender, EventArgs e)
        {
            var number = setTextInput.SetTextCardNo("0", txtPin.Text);
            txtPin.Text = number;
        }
    }
}
