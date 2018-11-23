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
    public partial class frmInputAccountOtherBank : Form
    {
        public frmInputAccountOtherBank()
        {
            InitializeComponent();
        }

        private void btnChooseYes_Click(object sender, EventArgs e)
        {
            frmInputAmountMoneyOtherBank frmInputAmountMoneyOtherBank = new frmInputAmountMoneyOtherBank();
            frmInputAmountMoneyOtherBank.Show();
            this.Hide();
        }
    }
}
