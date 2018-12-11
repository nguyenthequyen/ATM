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
        public string GetNameCustomer(string accountNo)
        {
            try
            {
                string name = "TECHCOMBANK ACCOUNT";
                string query = "SELECT Customer.Name FROM Account INNER JOIN Customer on Account.CustID = Customer.CustomerID WHERE AccountNo = @accountNo";
                dbContext.OpenConnection();
                SqlCommand cmd = new SqlCommand(query, dbContext.Connect);
                cmd.Parameters.AddWithValue("accountNo", accountNo);
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

        public bool CheckCardNo(string accountNo)
        {
            try
            {
                List<Card> listCard = new List<Card>();
                string sql = "SELECT * FROM Card INNER JOIN Account ON Card.AccountID = Account.AccountID WHERE AccountNo = @accountNo";
                dbContext.OpenConnection();
                SqlCommand cmd = new SqlCommand(sql, dbContext.Connect);
                cmd.Parameters.AddWithValue("accountNo", accountNo);
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

        public void UpdateBalance(int money, string cardNo, string accountNo, int transferFee)
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

                UpdateBalanceTo(money, accountNo);

            }
            catch
            {
                if (dbContext.CHECK_OPEN)
                {
                    dbContext.CloseConnection();
                }
            }
        }

        public void UpdateBalanceTo(int money, string accountNo)
        {
            try
            {

                int balance = 0;
                string query = "SELECT Account.Balance FROM Account WHERE AccountNo = @accountNo";
                dbContext.OpenConnection();
                SqlCommand cmd = new SqlCommand(query, dbContext.Connect);
                cmd.Parameters.AddWithValue("accountNo", accountNo);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    balance = Convert.ToInt32(dr["Balance"]);
                }
                dbContext.CloseConnection();
                int newBalance = balance + money;

                string queryUpdate = "UPDATE Account SET Account.Balance = @newBalance FROM Account WHERE AccountNo = @accountNo ";
                dbContext.OpenConnection();
                SqlCommand cmd1 = new SqlCommand(queryUpdate, dbContext.Connect);
                cmd1.Parameters.AddWithValue("newBalance", newBalance);
                cmd1.Parameters.AddWithValue("accountNo", accountNo);
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
        public string GetAccountIDByCardNo(string cardNo)
        {
            try
            {
                string accountNo = "";
                string query = "SELECT Account.AccountNo FROM Account INNER JOIN Card on Account.AccountID = Card.AccountID WHERE CardNo = @cardNo";
                dbContext.OpenConnection();
                SqlCommand cmd = new SqlCommand(query, dbContext.Connect);
                cmd.Parameters.AddWithValue("cardNo", cardNo);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    accountNo = dr["AccountNo"].ToString();
                }
                dbContext.CloseConnection();
                return accountNo;
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

        public string GetCardNoByAccountNo(string accountNo)
        {
            try
            {
                string cardNo = "";
                string query = "SELECT Card.CardNo FROM Account INNER JOIN Card on Account.AccountID = Card.AccountID WHERE AccountNo = @accountNo";
                dbContext.OpenConnection();
                SqlCommand cmd = new SqlCommand(query, dbContext.Connect);
                cmd.Parameters.AddWithValue("accountNo", accountNo);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    cardNo = dr["CardNo"].ToString();
                }
                dbContext.CloseConnection();
                return cardNo;
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
    }
}
