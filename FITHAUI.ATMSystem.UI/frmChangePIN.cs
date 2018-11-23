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
        private static string cardNO;
        public frmChangePIN()
        {
            InitializeComponent();
        }

        public static string CardNO { get => cardNO; set => cardNO = value; }

        private void btnAccept_Click(object sender, EventArgs e)
        {

        }
    }
}
