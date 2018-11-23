using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FITHAUI.ATMSystem
{
    public class Money
    {
        /// <summary>
        /// Mã loại tiền sử dụng trong hệ thống
        /// </summary>
        public string MoneyID { get; set; }
        /// <summary>
        /// Giá trị của loại tiền
        /// </summary>
        public string MoneyValue { get; set; }

        public Money()
        {

        }

        public Money(string moneyID, string moneyValue)
        {
            MoneyID = moneyID;
            MoneyValue = moneyValue;
        }
    }
}
