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
    public partial class frmListServices : Form
    {

        private static string _cardNo;
        public string CardNo { get => _cardNo; set => _cardNo = value; }
        public frmListServices()
        {
            InitializeComponent();
        }

        private void frmListServices_Load(object sender, EventArgs e)
        {

        }

        private void button21_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(CardNo,"Card No");
        }

        private void btnCashTransfer_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmChooseKindTransfer frmChooseKindTransfer = new frmChooseKindTransfer();
            frmChooseKindTransfer.CardNo = CardNo;
            frmChooseKindTransfer.Show();
        }
    }
}
