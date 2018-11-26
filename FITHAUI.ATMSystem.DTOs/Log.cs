using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FITHAUI.ATMSystem
{
    public class Log:LogType
    {
        /// <summary>
        /// Mã của bản ghi log
        /// </summary>
        public string LogID { get; set; }
        /// <summary>
        /// Ngày giao dịch xảy ra
        /// </summary>
        public DateTime LogDate { get; set; }
        /// <summary>
        /// Khoản tiền giao dịch
        /// </summary>
        public decimal Amount { get; set; }
        /// <summary>
        /// Mô tả về giao dịch
        /// </summary>
        public string Details { get; set; }
        /// <summary>
        /// Mã máy ATM
        /// </summary>
        public string ATMID { get; set; }
        /// <summary>
        /// Số thẻ ATM
        /// </summary>
        public string CardNo { get; set; }
        /// <summary>
        /// Số thẻ ATM nhận tiền
        /// </summary>
        public string CardNoTo { get; set; }

        public Log()
        {

        }

        public Log(string logID, DateTime logDate, decimal amount, string details, string logTypeID, string aTMID, string cardNo)
        {
            LogID = logID;
            LogDate = logDate;
            Amount = amount;
            Details = details;
            LogTypeID = logTypeID;
            ATMID = aTMID;
            CardNo = cardNo;
        }
        public Log(DateTime logDate,  decimal amount, string description) :base(description)
        {
            LogDate = logDate;
            Amount = amount;
            Description = description;
        }
    }
}
