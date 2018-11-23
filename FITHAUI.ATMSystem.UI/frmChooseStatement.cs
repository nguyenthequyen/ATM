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
    public partial class frmChooseStatement : Form
    {
        private static string _cardNo;
        public string CardNo { get => _cardNo; set => _cardNo = value; }
        public frmChooseStatement()
        {
            InitializeComponent();
        }

        private void btnDisplayScreen_Click(object sender, EventArgs e)
        {
            frmViewHistory viewHistory = new frmViewHistory();
            viewHistory.CardNo = CardNo;
            viewHistory.Show();
            this.Close();
        }
    }
}
