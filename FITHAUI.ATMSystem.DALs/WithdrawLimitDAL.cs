using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FITHAUI.ATMSystem
{
    public class WithdrawLimitDAL
    {
        Databasecontext dbContext = new Databasecontext();
        public int GetWithdrawLimit(string cardNo)
        {
            int withdrawLimit = -1;
            string sql = "select WithdrawLimit.Value " +
                "from Card join Account on Card.AccountID = Account.AccountID join WithdrawLimit on Account.WDID = WithdrawLimit.WDID " +
                "where Card.CardNo = @cardNo";
            dbContext.OpenConnection();
            SqlCommand sqlCommand = new SqlCommand(sql, dbContext.Connect);
            sqlCommand.Parameters.AddWithValue("@CardNo", cardNo);
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            while (sqlDataReader.Read())
            {
                withdrawLimit = Convert.ToInt32(sqlDataReader[0]);
            }
            dbContext.CloseConnection();

            return withdrawLimit;
        }
    }
}
