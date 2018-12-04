using FITHAUI.ATMSystem.DALs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FITHAUI.ATMSystem
{
    public class Account_DAL
    {
        Databasecontext dbContext = new Databasecontext();
        Log_DAL log_DAL = new Log_DAL();
        /// <summary>
        /// Số dư tài khoản sử dụng store procedure
        /// </summary>
        /// <param name="cardNo"></param>
        /// <returns></returns>
        public int CheckBalance(string cardNo)
        {
            int balance = -1;
            try
            {
                SqlCommand sqlCommand = new SqlCommand("Proc_CheckBalance", dbContext.Connect);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add("@CardNo", SqlDbType.NVarChar).Value = cardNo.Trim();
                dbContext.OpenConnection();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    balance = Convert.ToInt32(sqlDataReader["Balance"]);
                }
                dbContext.CloseConnection();
                log_DAL.CreateLog(DateTime.Now, 1100, "SUCCESS", "39137be2-0446-4688-be5a-862e94b8a6b9", "fc57dd25-0a60-427a-aaa5-f9d2059c8abb", cardNo, "");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Có lỗi xảy ra: " + ex.Message);
                log_DAL.CreateLog(DateTime.Now, 1100, "ERROR", "39137be2-0446-4688-be5a-862e94b8a6b9", "fc57dd25-0a60-427a-aaa5-f9d2059c8abb", cardNo, "");
                return balance;
            }
            return balance;
        }
    }
}
