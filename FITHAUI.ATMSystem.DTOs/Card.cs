using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FITHAUI.ATMSystem
{
    public class Card
    {
        /// <summary>
        /// Số thẻ ATM
        /// </summary>
        public string CardNo { get; set; }
        /// <summary>
        /// Mã PIN của thẻ
        /// </summary>
        public int PIN { get; set; }
        /// <summary>
        /// Trạng thái của thẻ: block, normal . . .
        /// </summary>
        public string Status { get; set; }
        /// <summary>
        /// Ngày cấp thẻ
        /// </summary>
        public DateTime StartDate { get; set; }
        /// <summary>
        /// Ngày hết hạn
        /// </summary>
        public DateTime ExpiredDate { get; set; }
        /// <summary>
        /// Số tài khoản
        /// </summary>
        public string AccountID { get; set; }
        /// <summary>
        /// Số lần nhập PIN không hợp lệ của khách hàng
        /// </summary>
        public int Attempt { get; set; }

        public Card()
        {

        }

        public Card(string cardNo, int pIN, string status, DateTime startDate, DateTime expiredDate, string accountID, int attempt)
        {
            CardNo = cardNo;
            PIN = pIN;
            Status = status;
            StartDate = startDate;
            ExpiredDate = expiredDate;
            AccountID = accountID;
            Attempt = attempt;
        }
    }
}
