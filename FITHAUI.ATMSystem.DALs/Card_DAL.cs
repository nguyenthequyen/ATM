using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace FITHAUI.ATMSystem
{
    public class Card_DAL
    {
        Log_DAL log = new Log_DAL();
        Databasecontext dbContext = new Databasecontext();

        public bool CheckCardNo(string cardNo)
        {
            try
            {
                List<Card> listCard = new List<Card>();
                string sql = "Select*From Card Where CardNo = @cardNo and Status = N'normal'";
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
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public void UpdateCard(string cardNo, string status, int attempt)
        {
            dbContext.OpenConnection();
            string sqlUpdate = "Update Card Set Attempt =@attempt, Status =@status Where CardNo=@cardNo";
            SqlCommand cmd = new SqlCommand(sqlUpdate, dbContext.Connect);
            cmd.Parameters.AddWithValue("cardNo", cardNo);
            cmd.Parameters.AddWithValue("status", status);
            cmd.Parameters.AddWithValue("attempt", attempt);
            cmd.ExecuteNonQuery();
            dbContext.CloseConnection();
        }
        public string CheckPIN(string cardNo, string pin)
        {
            try
            {
                string PIN = "";
                string sql = "Select PIN from Card where CardNo=@cardNo";
                dbContext.OpenConnection();
                SqlCommand cmd = new SqlCommand(sql, dbContext.Connect);
                cmd.Parameters.AddWithValue("cardNo", cardNo);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    PIN = dr["PIN"].ToString();
                }
                dbContext.CloseConnection();
                UpdateCard(cardNo, "normal", 0);
                return PIN;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                UpdateCard(cardNo, GetStatus(cardNo), GetAttempt(cardNo));
                return "";
            }
        }
        public void ChangePIN(string cardNo, string newPIN)
        {
            try
            {
                dbContext.CloseConnection();
                string sqlUpdate = "Update Card set PIN = @newPin where CardNo=@cardNo";
                dbContext.OpenConnection();
                SqlCommand cmd = new SqlCommand(sqlUpdate, dbContext.Connect);
                cmd.Parameters.AddWithValue("newPIN", newPIN);
                cmd.Parameters.AddWithValue("cardNo", cardNo);
                cmd.ExecuteNonQuery();
                dbContext.CloseConnection();
                log.CreateLog(DateTime.Now, 1100, "SUCCESS", "abcf9247-c548-45eb-9660-b6c8bc8c7f27", "fc57dd25-0a60-427a-aaa5-f9d2059c8abb", cardNo, "");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                log.CreateLog(DateTime.Now, 1100, "ERROR", "39137be2-0446-4688-be5a-862e94b8a6b9", "fc57dd25-0a60-427a-aaa5-f9d2059c8abb", cardNo, "");
            }
        }
        public string GetStatus(string cardNo)
        {
            try
            {
                string status = "";
                string sql = "Select Status From Card where CardNo =@cardNo";
                dbContext.OpenConnection();
                SqlCommand cmd = new SqlCommand(sql, dbContext.Connect);
                cmd.Parameters.AddWithValue("cardNo", cardNo);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    status = dr["Status"].ToString();
                }
                dbContext.CloseConnection();
                return status;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return "";
            }
        }

        public string GetExpiredDate(string cardNo)
        {
            try
            {
                string exDate = "";
                string sql = "Select ExpiredDate from Card where CardNo = @cardNo";
                dbContext.OpenConnection();
                SqlCommand cmd = new SqlCommand(sql, dbContext.Connect);
                cmd.Parameters.AddWithValue("cardNo", cardNo);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    exDate = dr["ExpiredDate"].ToString();
                }
                dbContext.CloseConnection();
                return exDate;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return "";
            }
        }
        public void UpdateAttempt(string cardNo)
        {
            try
            {
                int attempt = 0;
                string sql = "Select Attempt From Card Where CardNo =@cardNo";
                dbContext.OpenConnection();
                SqlCommand cmd = new SqlCommand(sql, dbContext.Connect);
                cmd.Parameters.AddWithValue("cardNo", cardNo);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    attempt = Convert.ToInt32(dr["Attempt"]);
                }
                attempt++;
                dbContext.CloseConnection();

                string sqlUpdate = "Update Card set Attempt=@attempt where CardNo=@cardNo";
                dbContext.OpenConnection();
                SqlCommand cmd1 = new SqlCommand(sqlUpdate, dbContext.Connect);
                cmd1.Parameters.AddWithValue("attempt", attempt);
                cmd1.Parameters.AddWithValue("cardNo", cardNo);
                cmd1.ExecuteNonQuery();
                dbContext.CloseConnection();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public int GetAttempt(string cardNo)
        {
            try
            {
                int attempt = 0;
                string sql = "Select Attempt From Card Where CardNo=@cardNo";
                dbContext.OpenConnection();
                SqlCommand cmd = new SqlCommand(sql, dbContext.Connect);
                cmd.Parameters.AddWithValue("cardNo", cardNo);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    attempt = Convert.ToInt32(dr["Attempt"]);
                }
                dbContext.CloseConnection();
                if (attempt == 3)
                {
                    string sqlUpdate = "Update Card set Status = N'block' where CardNo =@cardNo";
                    dbContext.OpenConnection();
                    SqlCommand cmd1 = new SqlCommand(sqlUpdate, dbContext.Connect);
                    cmd1.Parameters.AddWithValue("cardNo", cardNo);
                    cmd1.ExecuteNonQuery();
                    dbContext.CloseConnection();
                }
                return attempt;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return -1;
            }
        }
    }
}
