using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FITHAUI.ATMSystem
{
    public class WithdrawLimitBUL
    {
        WithdrawLimitDAL withdrawLimitDAL = new WithdrawLimitDAL();
        Log_BUL log_BUL = new Log_BUL();

        public bool checkWithdrawLimit(string logTypeID, string atmID, string cardNo, int money)
        {
            int withdrawLimit = withdrawLimitDAL.GetWithdrawLimit(cardNo);
            int totalAmountLogToday = log_BUL.getTotalAmount(logTypeID, atmID, cardNo);
            if (money + totalAmountLogToday <= withdrawLimit)
                return true;
            else
                return false;
        }
    }
}
