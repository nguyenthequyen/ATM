using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FITHAUI.ATMSystem
{
    class Account
    {
        /// <summary>
        /// Mã tài khoản
        /// </summary>
        public string AccountID { get; set; }
        /// <summary>
        /// Số tiền còn lại trong tài khoản
        /// </summary>
        public decimal Balance { get; set; }
        /// <summary>
        /// Mã khách hàng
        /// </summary>
        public string CustID { get; set; }
        /// <summary>
        /// Mã OverDraft (số tiền có thể thấu chi)
        /// </summary>
        public string ODID { get; set; }
        /// <summary>
        /// Mã WithDraw (số tiền tối đa rút trong ngày)
        /// </summary>
        public string WDID { get; set; }
        /// <summary>
        /// Số tài khoản
        /// </summary>
        public string AccountNo { get; set; }

        public Account()
        {

        }

        public Account(string accountID, decimal balance, string custID, string oDID, string wDID)
        {
            AccountID = accountID;
            Balance = balance;
            CustID = custID;
            ODID = oDID;
            WDID = wDID;
        }
    }
}
