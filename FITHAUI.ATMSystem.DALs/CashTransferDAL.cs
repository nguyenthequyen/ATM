using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FITHAUI.ATMSystem.DALs
{
    public class CashTransferDAL
    {
        Databasecontext dbContext = new Databasecontext();
        public string GetNameCustomer(string cardNo)
        {
            try
            {
                string name = "TECHCOMBANK ACCOUNT";
                string query = "SELECT Customer.Name FROM Account INNER JOIN Customer on Account.CustID = Customer.CustomerID INNER JOIN Card on Account.AccountID = Card.AccountID WHERE CardNo = @cardNo";
                dbContext.OpenConnection();
                SqlCommand cmd = new SqlCommand(query, dbContext.Connect);
                cmd.Parameters.AddWithValue("cardNo", cardNo);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    name = dr["Name"].ToString();
                }
                dbContext.CloseConnection();
                return name;
            }
            catch
            {
                if (dbContext.CHECK_OPEN)
                {
                    dbContext.CloseConnection();
                }
                return "";
            }
        }

        public bool CheckCardNo(string cardNo)
        {
            try
            {
                List<Card> listCard = new List<Card>();
                string sql = "SELECT * FROM Card WHERE CardNo = @cardNo";
                dbContext.OpenConnection();
                SqlCommand cmd = new SqlCommand(sql, dbContext.Connect);
                cmd.Parameters.AddWithValue("cardNo", cardNo);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Card card = new Card(
                        dr["CardNo"].ToString(),
                        Convert.ToInt32(dr["PIN"]),
                        dr["Status"].ToString(),
                        DateTime.Parse(dr["StartDate"].ToString()),
                        DateTime.Parse(dr["ExpiredDate"].ToString()),
                        dr["AccountID"].ToString(),
                        Convert.ToInt32(dr["Attempt"])
                    );
                    listCard.Add(card);
                }
                dbContext.CloseConnection();
                if (listCard.Count == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch
            {
                if (dbContext.CHECK_OPEN)
                {
                    dbContext.CloseConnection();
                }
                return false;
            }

        }

        public void UpdateBalance(int money, string cardNo, string cardNoTo, int transferFee)
        {
            try
            {

                int balance = 0;
                string query = "SELECT Account.Balance FROM Account INNER JOIN Card ON Account.AccountID = Card.AccountID WHERE CardNo = @cardNo";
                dbContext.OpenConnection();
                SqlCommand cmd = new SqlCommand(query, dbContext.Connect);
                cmd.Parameters.AddWithValue("cardNo", cardNo);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    balance = Convert.ToInt32(dr["Balance"]);
                }
                dbContext.CloseConnection();
                int newBalance = balance - money - transferFee;

                string queryUpdate = "UPDATE Account SET Account.Balance = @newBalance FROM Account INNER JOIN Card ON Account.AccountID = Card.AccountID WHERE Card.CardNo = @cardNo ";
                dbContext.OpenConnection();
                SqlCommand cmd1 = new SqlCommand(queryUpdate, dbContext.Connect);
                cmd1.Parameters.AddWithValue("newBalance", newBalance);
                cmd1.Parameters.AddWithValue("cardNo", cardNo);
                cmd1.ExecuteNonQuery();

                dbContext.CloseConnection();

                UpdateBalanceTo(money, cardNoTo);

            }
            catch
            {
                if (dbContext.CHECK_OPEN)
                {
                    dbContext.CloseConnection();
                }
            }
        }

        public void UpdateBalanceTo(int money, string cardNo)
        {
            try
            {

                int balance = 0;
                string query = "SELECT Account.Balance FROM Account INNER JOIN Card ON Account.AccountID = Card.AccountID WHERE CardNo = @cardNo";
                dbContext.OpenConnection();
                SqlCommand cmd = new SqlCommand(query, dbContext.Connect);
                cmd.Parameters.AddWithValue("cardNo", cardNo);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    balance = Convert.ToInt32(dr["Balance"]);
                }
                dbContext.CloseConnection();
                int newBalance = balance + money;

                string queryUpdate = "UPDATE Account SET Account.Balance = @newBalance FROM Account INNER JOIN Card ON Account.AccountID = Card.AccountID WHERE Card.CardNo = @cardNo ";
                dbContext.OpenConnection();
                SqlCommand cmd1 = new SqlCommand(queryUpdate, dbContext.Connect);
                cmd1.Parameters.AddWithValue("newBalance", newBalance);
                cmd1.Parameters.AddWithValue("cardNo", cardNo);
                cmd1.ExecuteNonQuery();

                dbContext.CloseConnection();

            }
            catch
            {
                if (dbContext.CHECK_OPEN)
                {
                    dbContext.CloseConnection();
                }
            }
        }

        public bool CompareBalance(int money, string cardNo, int transferFee)
        {
            try
            {
                int balance = 0;
                string query = "SELECT Account.Balance FROM Account INNER JOIN Card ON Account.AccountID = Card.AccountID WHERE CardNo = @cardNo";
                dbContext.OpenConnection();
                SqlCommand cmd = new SqlCommand(query, dbContext.Connect);
                cmd.Parameters.AddWithValue("cardNo", cardNo);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    balance = Convert.ToInt32(dr["Balance"]);
                }
                dbContext.CloseConnection();
                if (balance + GetOverDraft(cardNo) > 0)
                {
                    if ((money + transferFee) <= (balance + GetOverDraft(cardNo)))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
                
            }
            catch
            {
                if (dbContext.CHECK_OPEN)
                {
                    dbContext.CloseConnection();
                }
                return false;
            }
        }

        public int GetOverDraft(string cardNo)
        {
            try
            {
                int overDraft = 0;
                string query = "SELECT Value FROM OverDraft INNER JOIN Account ON Account.ODID = OverDraft.ODID INNER JOIN Card ON Account.AccountID = Card.AccountID WHERE CardNo = @cardNo";
                dbContext.OpenConnection();
                SqlCommand cmd = new SqlCommand(query, dbContext.Connect);
                cmd.Parameters.AddWithValue("cardNo", cardNo);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    overDraft = Convert.ToInt32(dr["Value"]);
                }
                dbContext.CloseConnection();
                return overDraft;
            }
            catch
            {
                if (dbContext.CHECK_OPEN)
                {
                    dbContext.CloseConnection();
                }
                return 0;
            }
        }
    }
}
