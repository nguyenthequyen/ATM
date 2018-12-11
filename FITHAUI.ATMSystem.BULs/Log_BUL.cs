
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FITHAUI.ATMSystem
{
    public class Log_BUL
    {
        Log_DAL log_DAL = new Log_DAL();
        
        public List<Log> GetListLog(string cardNo)
        {
            return log_DAL.ViewHistory(cardNo);
        }
        public void CreateLog(DateTime logDate, decimal amount, string details, string logTypeID, string atmID, string cardNo, string cardNoTo)
        {
            log_DAL.CreateLog(DateTime.Now, amount, details, logTypeID, atmID, cardNo, cardNoTo);
        }

        public int getTotalAmount(string logTypeID, string atmID, string cardNo)
        {
            string startTime, endTime;
            startTime = DateTime.Today.ToString("yyyy-MM-dd") + " 00:00:00";
            endTime = DateTime.Today.ToString("yyyy-MM-dd") + " 23:59:59";
            return log_DAL.getTotalAmount(logTypeID, atmID, cardNo, startTime, endTime);
        }

        //public List<Log> GetAllLog(string cardNo)
        //{
        //    List<Log> listLog = log_DAL.GetAllLog(cardNo);
        //    List<Log> listLogNew = new List<Log>();
        //    for(int i=0; i < listLog.Count; i++)
        //    {
        //        Log log = listLog[i];
        //        if (log.LogTypeID.Equals("542ed769-f0d8-48b4-ba5c-ddf600a85be1"))
        //        {
        //            log.LogTypeID = "Widthdraw";
        //        }
        //        else if (log.LogTypeID.Equals("ed52b1ad-47ed-48c3-a89e-79958250f402"))
        //        {
        //            log.LogTypeID = "Transfer";
        //        }
        //        else if (log.LogTypeID.Equals("abcf9247-c548-45eb-9660-b6c8bc8c7f27"))
        //        {
        //            log.LogTypeID = "checkBalance";
        //        }
        //        else if (log.LogTypeID.Equals("09da2d0c-dd3e-4530-bb8d-98445d6457ae"))
        //        {
        //            log.LogTypeID = "changePIN";
        //        }
        //        listLogNew.Add(log);
        //    }
        //    return listLogNew;
        //}
    }
}
