using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FITHAUI.ATMSystem
{
    public class ViewHistory_BUL
    {
        ViewHistory_DAL viewHistory_DAL = new ViewHistory_DAL();
        /// <summary>
        /// Xem lịch sử giao dịch
        /// </summary>
        /// <param name="cardNo"></param>
        /// <returns></returns>
        public List<Log> GetListLog(string cardNo)
        {
            return viewHistory_DAL.ViewHistory(cardNo);
        }
    }
}
