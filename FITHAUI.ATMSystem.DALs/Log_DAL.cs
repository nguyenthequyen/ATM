using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FITHAUI.ATMSystem
{
    public class Log_DAL
    {
        Databasecontext dbContext = new Databasecontext();
        /// <summary>
        /// Xem lịch sử giao dịch
        /// </summary>
        /// <param name="cardNo"></param>
        /// <returns></returns>
        public List<Log> ViewHistory(string cardNo)
        {
            List<Log> logs = new List<Log>();
            SqlCommand sqlCommand = new SqlCommand("Proc_ViewHistory", dbContext.Connect);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.Add("@CardNo", SqlDbType.NVarChar).Value = cardNo.Trim();
            dbContext.OpenConnection();
            //DataTableReader sqlDataReader = sqlCommand.ExecuteReader();
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            while (sqlDataReader.Read())
            {
                DateTime.Parse(sqlDataReader["LogDate"].ToString());
                Log log = new Log(
                    DateTime.Parse(sqlDataReader["LogDate"].ToString()),
                    sqlDataReader["Details"].ToString(),
                    decimal.Parse(sqlDataReader["Amount"].ToString()));
                logs.Add(log);
            }
            dbContext.CloseConnection();
            return logs;
        }
    }
}
