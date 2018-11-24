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
        /// <summary>
        /// Số dư tài khoản
        /// </summary>
        /// <param name="cardNo"></param>
        /// <returns></returns>
        //public int CheckBalance(string cardNo)
        //{
        //    int balance = -1;
        //    try
        //    {
        //        string query = "select Balance from Account as a inner join Card as c on a.AccountID = c.AccountID where @CardNo  =  c.CardNo";
        //        dbContext.OpenConnection();
        //        SqlCommand sqlCommand = new SqlCommand(query, dbContext.Connect);
        //        sqlCommand.Parameters.AddWithValue("CardNo", cardNo);
        //        SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
        //        while (sqlDataReader.Read())
        //        {
        //            balance = Convert.ToInt32(sqlDataReader["Balance"]);
        //        }
        //    }
        //    catch (SqlException ex)
        //    {
        //        Console.WriteLine("Có lỗi xảy ra: " + ex.Message);
        //    }
        //    dbContext.CloseConnection();
        //    return balance;
        //}
        /// <summary>
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

        public void updateBalance(int money, string cardNo)
        {
            try
            {
                int balance = CheckBalance(cardNo);
                int newBalance = balance - money - 1100;    // trừ thêm lệ phí là 1100 vnd

                string queryUpdate = "update Account set Account.Balance = @newBalance " +
                    "from Account inner join Card on Account.AccountID = Card.AccountID where Card.CardNo = @cardNo ";
                dbContext.OpenConnection();
                SqlCommand cmd1 = new SqlCommand(queryUpdate, dbContext.Connect);
                cmd1.Parameters.AddWithValue("newBalance", newBalance);
                cmd1.Parameters.AddWithValue("cardNo", cardNo);
                cmd1.ExecuteNonQuery();

                dbContext.CloseConnection();
                return;
            }
            catch
            {
                dbContext.CloseConnection();
                return;
            }
        }
    }
}
