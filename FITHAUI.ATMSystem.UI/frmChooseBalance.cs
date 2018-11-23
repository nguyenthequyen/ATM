using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FITHAUI.ATMSystem.UI
{
    public partial class frmChooseBalance : Form
    {
        private static string _cardNo;
        public string CardNo { get => _cardNo; set => _cardNo = value; }
        public frmChooseBalance()
        {
            InitializeComponent();
        }

        private void btnDisplayScreen_Click(object sender, EventArgs e)
        {
            frmBalanceScreen balanceScreen = new frmBalanceScreen();
            balanceScreen.CardNo = CardNo;
            this.Close();
            balanceScreen.Show();
        }

        private void btnPrintPdf_Click(object sender, EventArgs e)
        {
            try
            {
                Document doc = new Document();
                PdfWriter.GetInstance(doc, new FileStream("F:/SystemATM/FITHAUI.ATMSystem/Balance.pdf", FileMode.Create));
                doc.Open();
                Paragraph pr = new Paragraph("NGUYEN THE QUYEN");
                doc.Add(pr);
                doc.Close();
                MessageBox.Show("In file thành công");
            }
            catch (Exception ex)
            {

                Console.WriteLine("Có lỗi xảy ra trong quá trình tạo File: " + ex.Message);
            }
        }
    }
}
