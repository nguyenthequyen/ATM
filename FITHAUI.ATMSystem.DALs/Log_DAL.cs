using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

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
            try
            {
                SqlCommand sqlCommand = new SqlCommand("Proc_ViewHistory", dbContext.Connect);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add("@CardNo", SqlDbType.NVarChar).Value = cardNo.Trim();
                dbContext.OpenConnection();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    var description = sqlDataReader["Description"].ToString();
                    switch (description)
                    {
                        case "Widthdraw":
                            description = "-";
                            break;
                        case "receiveMoney":
                            description = "+";
                            break;
                        case "Transfer":
                            description = "-";
                            break;
                        default:
                            break;
                    }
                    DateTime.Parse(sqlDataReader["LogDate"].ToString());
                    Log log = new Log(
                        DateTime.Parse(sqlDataReader["LogDate"].ToString()),
                        decimal.Parse(sqlDataReader["Amount"].ToString()),
                        description);
                    logs.Add(log);
                }
                dbContext.CloseConnection();
                CreateLog(DateTime.Now, 1100, "SUCCESS", "39137be2-0446-4688-be5a-862e94b8a6b9", "fc57dd25-0a60-427a-aaa5-f9d2059c8abb", cardNo, "");
            }
            catch (Exception ex)
            {
                CreateLog(DateTime.Now, 1100, "ERROR", "39137be2-0446-4688-be5a-862e94b8a6b9", "fc57dd25-0a60-427a-aaa5-f9d2059c8abb", cardNo, "");
                Console.WriteLine("Có lỗi xảy ra: " + ex.Message);
            }

            return logs;
        }
        public void CreateLog(DateTime logDate, decimal amount, string details, string logTypeID, string atmID, string cardNo, string cardNoTo)
        {
            try
            {
                string sqlInsert = "insert into Log(LogDate, Amount, Details, LogTypeID, ATMID, CardNo, CardNoTo) Values(@logDate, @amount, @details, @logTypeID, @atmID, @cardNo, @cardNoTo)";
                dbContext.OpenConnection();
                SqlCommand cmd = new SqlCommand(sqlInsert, dbContext.Connect);
                cmd.Parameters.AddWithValue("logDate", logDate);
                cmd.Parameters.AddWithValue("amount", amount);
                cmd.Parameters.AddWithValue("details", details);
                cmd.Parameters.AddWithValue("logTypeID", logTypeID);
                cmd.Parameters.AddWithValue("atmID", atmID);
                cmd.Parameters.AddWithValue("cardNo", cardNo);
                cmd.Parameters.AddWithValue("cardNoTo", cardNoTo);
                cmd.ExecuteNonQuery();
                dbContext.CloseConnection();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
