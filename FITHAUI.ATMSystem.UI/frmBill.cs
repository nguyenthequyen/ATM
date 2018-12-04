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
    public partial class frmBill : Form
    {
        public frmBill()
        {
            InitializeComponent();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            // In biên lai

            frmWithDrawSuccess withDrawSuccess = new frmWithDrawSuccess();
            this.Close();

            Task delay = Task.Delay(3000);
            withDrawSuccess.Show();
            delay.Wait();
            withDrawSuccess.Close();

            frmValidateCard frmValidateCard = new frmValidateCard();
            frmValidateCard.Show();
        }

        private void btnNoPrint_Click(object sender, EventArgs e)
        {
            frmWithDrawSuccess withDrawSuccess = new frmWithDrawSuccess();
            this.Close();

            Task delay = Task.Delay(3000);
            withDrawSuccess.Show();
            delay.Wait();
            withDrawSuccess.Close();

            frmValidateCard frmValidateCard = new frmValidateCard();
            frmValidateCard.Show();
        }
    }
}
