using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FITHAUI.ATMSystem.DALs.CheckBalance
{
    public class Balance_DAL
    {
        Databasecontext dbContext = new Databasecontext();
        /// <summary>
        /// Số dư tài khoản
        /// </summary>
        /// <param name="cardNo"></param>
        /// <returns></returns>
        public int CheckBalance(string cardNo)
        {
            string query = "select Balance from Account as a inner join Card as c on a.AccountID = c.AccountID where @CardNo  =  c.CardNo";
            int balance = -1;
            dbContext.OpenConnection();
            SqlCommand sqlCommand = new SqlCommand(query, dbContext.Connect);
            sqlCommand.Parameters.AddWithValue("CardNo", cardNo);
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
