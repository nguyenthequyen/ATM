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
    public partial class frmInputAccountReceiver : Form
    {
        public frmInputAccountReceiver()
        {
            InitializeComponent();
        }

        private void btnChooseTrue_Click(object sender, EventArgs e)
        {
            var frmInputAmountMoneyInBank = new frmInputAmountMoneyInBank();
            frmInputAmountMoneyInBank.Show();
            this.Hide();
        }
    }
}
