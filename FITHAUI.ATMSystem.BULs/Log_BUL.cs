using FITHAUI.ATMSystem.DALs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FITHAUI.ATMSystem.BULs
{
    public class Log_BUL
    {
        Log_DAL log_DAL = new Log_DAL();
        
        public List<Log> GetListLog(string cardNo)
        {
            return log_DAL.ViewHistory(cardNo);
        }
        public void CreateLog(decimal amount, string details, string logTypeID, string atmID, string cardNo, string cardNoTo)
        {
            //string dateTime = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ssZ");
            //logID = "log" + dateTime;
            //logDate = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ssZ");
            log_DAL.CreateLog(amount, details, logTypeID, atmID, cardNo, cardNoTo);
        }        
    }
}
