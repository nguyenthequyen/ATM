using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FITHAUI.ATMSystem.BULs.CashTransfer;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace FITHAUI.ATMSystem.UI
{
    public partial class frmPayTransactionInBank : Form
    {
        private static string _cardNo;
        public string CardNo { get => _cardNo; set => _cardNo = value; }

        private static string _accountNOReceived;
        public string AccountNOReceived { get => _accountNOReceived; set => _accountNOReceived = value; }

        private static string _money;
        public string Money { get => _money; set => _money = value; }

        private static int _transferFee;
        public int TransferFee { get => _transferFee; set => _transferFee = value; }

        private static bool _doesPrintReceipt;
        public bool DoesPrintReceipt { get => _doesPrintReceipt; set => _doesPrintReceipt = value; }

        CashTransferBUL cashTransferBUL = new CashTransferBUL();
        Account_BUL account_BUL = new Account_BUL();
        SubStringDate sub = new SubStringDate();
        public frmPayTransactionInBank()
        {
            InitializeComponent();
        }

        private void btnChooseYes_Click_1(object sender, EventArgs e)
        {
            if (cashTransferBUL.CompareBalance(int.Parse(Money), CardNo, TransferFee))
            {
                cashTransferBUL.UpdateBalance(int.Parse(Money), CardNo, AccountNOReceived, TransferFee);
                this.Hide();
                var waitCashTransfer = new frmWaitCashTransfer();
                waitCashTransfer.CardNo = CardNo;
                waitCashTransfer.Show();
                Task delay = Task.Delay(3000);
                delay.Wait();
                waitCashTransfer.Close();
                if (DoesPrintReceipt)
                {
                    PrintReceipt();
                }
                frmCashTransferSuccess frmCash = new frmCashTransferSuccess();
                frmCash.CardNo = CardNo;
                frmCash.Show();

            }
            else
            {
                frmTransactionFailed transactionFailed = new frmTransactionFailed();
                transactionFailed.Show();
                this.Hide();
            }
        }

        private void btnChooseNo_Click(object sender, EventArgs e)
        {
            frmListServices frmList = new frmListServices();
            frmList.CardNo = CardNo;
            this.Close();
            frmList.Show();
        }

        public void PrintReceipt()
        {
            string path = @"E:\BLT Windows\ATM\FITHAUI.ATMSystem.UI";
            var accountID = cashTransferBUL.GetAccountIDByCardNo(CardNo);
            var cardNoReceived = cashTransferBUL.GetCardNoByAccountNo(AccountNOReceived);
            FileStream fs = new
                FileStream(path + @"\pdf\CashTransfer.pdf", FileMode.Create, FileAccess.Write, FileShare.None);
            iTextSharp.text.Rectangle rec =
                new iTextSharp.text.Rectangle(240, 340);
            rec.BackgroundColor = new BaseColor(System.Drawing.Color.WhiteSmoke);
            Document doc = new Document(rec, 14, 14, 22.6f, 22.6f);
            PdfWriter writer = PdfWriter.GetInstance(doc, fs);
            doc.Open();
            iTextSharp.text.Font headerFont = FontFactory.GetFont("Verdana", 8);
            iTextSharp.text.Font emptyFont = FontFactory.GetFont("Verdana", 5);
            //Ảnh header
            //Ảnh header
            string imageURL = path + @"\Content\Images\Logo.png";
            iTextSharp.text.Image jpg = iTextSharp.text.Image.GetInstance(imageURL);
            jpg.Alignment = Element.ALIGN_CENTER;
            jpg.ScaleToFit(80f, 120f);
            doc.Add(jpg);
            PdfPTable common = new PdfPTable(3);
            common.HorizontalAlignment = Element.ALIGN_CENTER;
            common.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
            common.WidthPercentage = 95f;

            Paragraph emptyPara = new Paragraph("    ", emptyFont);
            var dateNow = sub.SubDate(DateTime.Now.ToString().Trim());
            var time = sub.SubTime(DateTime.Now.ToString().Trim());
            PdfPCell pDay = new PdfPCell(new Phrase(string.Format("NGAY                    :  {0}        GIO:  {1}\n", dateNow, time), headerFont));
            pDay.Colspan = 3;
            pDay.Border = iTextSharp.text.Rectangle.NO_BORDER;
            PdfPCell pNameATM = new PdfPCell(new Phrase(string.Format("TEN MAY              :  {0}", "ATM1"), headerFont));
            pNameATM.Colspan = 3;
            pNameATM.Border = iTextSharp.text.Rectangle.NO_BORDER;
            PdfPCell pAddressATM = new PdfPCell(new Phrase(string.Format("DIA CHI                 :  {0}", "HA NOI"), headerFont));
            pAddressATM.Colspan = 3;
            pAddressATM.Border = iTextSharp.text.Rectangle.NO_BORDER;
            PdfPCell pCardNoATM = new PdfPCell(new Phrase(string.Format("SO THE                 :  {0}", CardNo), headerFont));
            pCardNoATM.Colspan = 3;
            pCardNoATM.Border = iTextSharp.text.Rectangle.NO_BORDER;
            PdfPCell pTrace = new PdfPCell(new Phrase(string.Format("SO TRACE            :  {0}", "123456879"), headerFont));
            pTrace.Colspan = 3;
            pTrace.Border = iTextSharp.text.Rectangle.NO_BORDER;
            common.AddCell(pDay);
            common.AddCell(pNameATM);
            common.AddCell(pAddressATM);
            common.AddCell(pCardNoATM);
            common.AddCell(pTrace);
            doc.Add(common);


            //doc.Add(jpg);

            doc.Add(emptyPara);
            PdfPTable table = new PdfPTable(3);
            table.HorizontalAlignment = Element.ALIGN_CENTER;
            table.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
            table.WidthPercentage = 95f;

            PdfPCell cashTransferInBank = new PdfPCell(new Phrase(String.Format("                         CHUYEN KHOAN NOI BO\n", ""), headerFont));
            cashTransferInBank.Colspan = 3;
            cashTransferInBank.Border = iTextSharp.text.Rectangle.NO_BORDER;
            PdfPCell cCardNo = new PdfPCell(new Phrase(String.Format("TAI KHOAN NGUON     :  {0}", accountID), headerFont));
            cCardNo.Colspan = 3;
            cCardNo.Border = iTextSharp.text.Rectangle.NO_BORDER;
            PdfPCell cCardNOReceived = new PdfPCell(new Phrase(String.Format("SO THE NHAN              :  {0}", cardNoReceived), headerFont));
            cCardNOReceived.Colspan = 3;
            cCardNOReceived.Border = iTextSharp.text.Rectangle.NO_BORDER;
            PdfPCell cAvailBal = new PdfPCell(new Phrase(String.Format("SO TIEN                        :  {0} VND", Money), headerFont));
            cAvailBal.Colspan = 3;
            cAvailBal.Border = iTextSharp.text.Rectangle.NO_BORDER;
            PdfPCell cFee = new PdfPCell(new Phrase(String.Format("PHI (+VAT)                    :  {0} VND", "0"), headerFont));
            cFee.Colspan = 3;
            cFee.Border = iTextSharp.text.Rectangle.NO_BORDER;
            table.AddCell(cashTransferInBank);
            table.AddCell(cCardNo);
            table.AddCell(cCardNOReceived);
            table.AddCell(cAvailBal);
            table.AddCell(cFee);
            doc.Add(table);
            doc.Close();
            //MessageBox.Show("GIAO DỊCH THÀNH CÔNG");
            try
            {
                Process myProcess = new Process();
                //Process.Start(path + @"\pdfexe\SumatraPDF.exe", path + @"\pdf\CashTransfer.pdf");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        private void button24_Click(object sender, EventArgs e)
        {
            frmValidateCard validateCard = new frmValidateCard();
            validateCard.Show();
            this.Close();
        }
    }
}
