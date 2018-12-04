using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace FITHAUI.ATMSystem
{
    public class Config_DAL
    {
        //lấy số tiền tối đa trong 1 lần rút của cây
        Databasecontext dbContext = new Databasecontext();
        public int GetMaxWithDraw()
        {
            int maxWithDraw = -1;
            string sql = "Select Config.MaxWithdraw from Config";
            dbContext.OpenConnection();
            SqlCommand sqlCommand = new SqlCommand(sql, dbContext.Connect);
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            while (sqlDataReader.Read())
            {
                maxWithDraw = Convert.ToInt32(sqlDataReader[0]);
            }
            dbContext.CloseConnection();
            return maxWithDraw;
        }
    }
}
