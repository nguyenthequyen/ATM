using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FITHAUI.ATMSystem
{
    public class WithdrawLimit
    {
        /// <summary>
        /// Mã giới hạn rút
        /// </summary>
        public string WDID { get; set; }
        /// <summary>
        /// Số tiền tối đa một tài khoản có thể rút trong ngày
        /// </summary>
        public decimal Value { get; set; }

        public WithdrawLimit()
        {

        }

        public WithdrawLimit(string wDID, decimal value)
        {
            WDID = wDID;
            Value = value;
        }
    }
}
