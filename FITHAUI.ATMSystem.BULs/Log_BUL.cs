using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FITHAUI.ATMSystem
{
    public class Log_BUL
    {
        Log_DAL log = new Log_DAL();
        /// <summary>
        /// Xem lịch sử giao dịch
        /// </summary>
        /// <param name="cardNo"></param>
        /// <returns></returns>
        public List<Log> GetListLog(string cardNo)
        {
            return log.ViewHistory(cardNo);
        }
    }
}
