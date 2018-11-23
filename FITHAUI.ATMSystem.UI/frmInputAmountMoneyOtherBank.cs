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
    public partial class frmInputAmountMoneyOtherBank : Form
    {
        public frmInputAmountMoneyOtherBank()
        {
            InitializeComponent();
        }

        private void btnChooseYes_Click(object sender, EventArgs e)
        {
            frmInputAccountValid frmInputAccountValid = new frmInputAccountValid();
            frmInputAccountValid.Show();
            this.Hide();
        }
    }
}
