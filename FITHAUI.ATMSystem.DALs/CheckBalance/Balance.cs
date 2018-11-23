using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FITHAUI.ATMSystem.DALs.CheckBalance
{
    public class Balance
    {
        Databasecontext dbContext = new Databasecontext();
        public void CheckBalance(string cardNo)
        {
            dbContext.OpenConection();
            SqlCommand sqlCommand = new SqlCommand();
        }
    }
}
