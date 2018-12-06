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
    public partial class frmChangePIN2 : Form
    {
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
                Log_BUL.CreateLog(0, "new pin:" + txtNewPINAgain, "09da2d0c-dd3e-4530-bb8d-98445d6457ae", "b936bf52-94d0-488f-bcda-1e4f1ecc422f", txtCardNo.Text, "");
                frmChangePINSuccess changePINSuccess = new frmChangePINSuccess();
                Card_BUL.ChangePIN(CardNo, Pin.ToString());
                changePINSuccess.Show();
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
    }
}
