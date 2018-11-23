using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FITHAUI.ATMSystem
{
    public class Stock
    {
        /// <summary>
        /// Mã của bản ghi stock
        /// </summary>
        public string StockID { get; set; }
        /// <summary>
        /// Số lượng mỗi loại tiền trong mỗi máy ATM
        /// </summary>
        public int Quantity { get; set; }
        /// <summary>
        /// Mã loại tiền
        /// </summary>
        public string MoneyID { get; set; }
        /// <summary>
        /// Mã máy ATM
        /// </summary>
        public string ATMID { get; set; }

        public Stock()
        {

        }

        public Stock(string stockID, int quantity, string moneyID, string aTMID)
        {
            StockID = stockID;
            Quantity = quantity;
            MoneyID = moneyID;
            ATMID = aTMID;
        }
    }
}
