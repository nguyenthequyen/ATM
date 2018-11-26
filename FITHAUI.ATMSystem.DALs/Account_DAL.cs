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
        /// Số dư tài khoản sử dụng store procedure
        /// </summary>
        /// <param name="cardNo"></param>
        /// <returns></returns>
        public int CheckBalance(string cardNo)
        {
            int balance = -1;
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
            return balance;
        }
    }
}
