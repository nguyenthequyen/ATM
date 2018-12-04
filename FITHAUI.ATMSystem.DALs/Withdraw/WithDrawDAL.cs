using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace FITHAUI.ATMSystem.DALs.Withdraw
{
    class WithDrawDAL
    {
        Databasecontext dbConext = new Databasecontext();
        Balance_DAL balance_DAL = new Balance_DAL();
        public int withDraw(string cardNo, decimal money)
        {
            int checkWithdraw = -1;
            var balance = balance_DAL.CheckBalance(cardNo);
            return checkWithdraw;
        }
    }
}
