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
    public partial class frmViewHistory : Form
    {
        private static string _cardNo;
        public string CardNo { get => _cardNo; set => _cardNo = value; }
        ViewHistory_BUL history_BUL = new ViewHistory_BUL();
        public frmViewHistory()
        {
            InitializeComponent();
        }

        public void DisplayHistory(string cardNo)
        {
            dgvHistory.DataSource = history_BUL.GetListLog(cardNo);
            dgvHistory.Columns["LogID"].Visible = false;
            dgvHistory.Columns["LogTypeID"].Visible = false;
            dgvHistory.Columns["ATMID"].Visible = false;
            dgvHistory.Columns["CardNo"].Visible = false;
            dgvHistory.Columns["CardNoTo"].Visible = false;
            dgvHistory.Columns["LogDate"].HeaderText = "Ngày giao dịch";
            dgvHistory.Columns["Details"].HeaderText = "Chi tiết giao dịch";
            dgvHistory.Columns["Amount"].HeaderText = "Số tiền";
        }

        private void frmViewHistory_Load(object sender, EventArgs e)
        {
            DisplayHistory(CardNo);
        }

        private void btnCardNo_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
