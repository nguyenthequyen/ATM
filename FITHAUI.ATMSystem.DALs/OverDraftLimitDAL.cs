using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FITHAUI.ATMSystem
{
    public class OverDraftLimitDAL
    {
        Databasecontext dbContext = new Databasecontext();
        public int GetOverDraft(string cardNo)
        {
            int overDraft = -1;
            string sql = "select OverDraft.Value " +
                "from Card join Account on Card.AccountID = Account.AccountID join OverDraft on Account.ODID = OverDraft.ODID " +
                "where Card.CardNo = @cardNo";
            dbContext.OpenConnection();
            SqlCommand sqlCommand = new SqlCommand(sql, dbContext.Connect);
            sqlCommand.Parameters.AddWithValue("@CardNo", cardNo);
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            while (sqlDataReader.Read())
            {
                overDraft = Convert.ToInt32(sqlDataReader[0]);
            }
            dbContext.CloseConnection();

            return overDraft;
        }
    }
}
