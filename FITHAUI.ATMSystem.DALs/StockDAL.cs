using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FITHAUI.ATMSystem.DALs
{
    public class StockDAL
    {
        Databasecontext dbContext = new Databasecontext();
        public bool updateQuantity(string atmID, string moneyID, int quantity)
        {
            try
            {
                int currenQuantity = getQuantity(atmID, moneyID);
                int newQuantity = currenQuantity - quantity;

                if (newQuantity < 0)
                    return false;

                string queryUpdate = "update Stock set Quantity = @newQuantity where ATMID = @atmId and MoneyID = @moneyID";
                dbContext.OpenConnection();
                SqlCommand cmd1 = new SqlCommand(queryUpdate, dbContext.Connect);
                cmd1.Parameters.AddWithValue("newQuantity", newQuantity);
                cmd1.Parameters.AddWithValue("atmId", atmID);
                cmd1.Parameters.AddWithValue("moneyID", moneyID);
                cmd1.ExecuteNonQuery();

                dbContext.CloseConnection();
                return true;
            }
            catch
            {
                dbContext.CloseConnection();
                return false;
            }
        }

        public int getQuantity(string atmID, string moneyID)
        {
            try
            {
                int currentQuantity = -1;
                string query = "select Quantity from Stock  where ATMID = @atmId and MoneyID = @moneyID";
                dbContext.OpenConnection();
                SqlCommand cmd = new SqlCommand(query, dbContext.Connect);
                cmd.Parameters.AddWithValue("atmId", atmID);
                cmd.Parameters.AddWithValue("moneyID", moneyID);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    currentQuantity = Convert.ToInt32(dr[0]);
                }
                dbContext.CloseConnection();
                return currentQuantity;
            }
            catch
            {
                dbContext.CloseConnection();
                return -1;
            }
        }
    }
}
