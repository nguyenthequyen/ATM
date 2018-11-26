using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FITHAUI.ATMSystem.BULs;

namespace FITHAUI.ATMSystem.UI
{
    public partial class frmViewHistory : Form
    {
        private static string _cardNo;
        public string CardNo { get => _cardNo; set => _cardNo = value; }
        Log_BUL log_BUL = new Log_BUL();
        Account_BUL account_BUL = new Account_BUL();
        public frmViewHistory()
        {
            InitializeComponent();
        }

        public void DisplayHistory(string cardNo)
        {
            dgvHistory.DataSource = log_BUL.GetListLog(cardNo);
            dgvHistory.Columns["LogID"].Visible = false;
            dgvHistory.Columns["LogTypeID"].Visible = false;
            dgvHistory.Columns["ATMID"].Visible = false;
            dgvHistory.Columns["CardNo"].Visible = false;
            dgvHistory.Columns["CardNoTo"].Visible = false;
            dgvHistory.Columns["LogDate"].HeaderText = "Ngày giao dịch";
            dgvHistory.Columns["Description"].HeaderText = "Chi tiết giao dịch";
            dgvHistory.Columns["Amount"].HeaderText = "Số tiền";
            lblBalance.Text = account_BUL.GetBalance(cardNo) + " VND"; 
        }

        private void frmViewHistory_Load(object sender, EventArgs e)
        {
           DisplayHistory(CardNo);
        }

        private void btnCardNo_TextChanged(object sender, EventArgs e)
        {

        }

        private void button24_Click(object sender, EventArgs e)
        {

        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            frmListServices listServices = new frmListServices();
            this.Close();
            listServices.CardNo = CardNo;
            listServices.Show();
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
