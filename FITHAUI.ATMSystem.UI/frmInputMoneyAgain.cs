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
    public partial class frmInputMoneyAgain : Form
    {
        public frmInputMoneyAgain()
        {
            InitializeComponent();
        }

        private void btnTrue_Click(object sender, EventArgs e)
        {
            frmBill bill = new frmBill();
            bill.Show();
        }

        private void btnIgnore_Click(object sender, EventArgs e)
        {
            frmListServices listServices = new frmListServices();
            listServices.Show();
        }

        private void btnFalse_Click(object sender, EventArgs e)
        {
            textInpMoney.Clear();
        }
    }
}
