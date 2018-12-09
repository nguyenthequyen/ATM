using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using FITHAUI.ATMSystem.DTOs;
namespace FITHAUI.ATMSystem.DALs
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
                    decimal.Parse(sqlDataReader["Amount"].ToString()),
                    sqlDataReader["Description"].ToString());
                logs.Add(log);
            }
            dbContext.CloseConnection();
            return logs;
        }
        public void CreateLog(DateTime logDate, decimal amount, string details, string logTypeID, string atmID, string cardNo, string cardNoTo )
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
                //return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                //return false;
            }            
        }
        //public List<Log> getAllLog(string cardNo)
        //{
        //    try
        //    {
        //        List<Log> listLog = new List<Log>();
        //        string sql = "Select*From Log Where CardNo =@cardNo";
        //        dbContext.OpenConnection();
        //        SqlCommand cmd = new SqlCommand(sql, dbContext.Connect);
        //        cmd.Parameters.AddWithValue("cardNo", cardNo);
        //        SqlDataReader dr = cmd.ExecuteReader();
        //        while (dr.Read())
        //        {
        //            Log log = new Log(dr["LogID"].ToString(),
        //                DateTime.Parse(dr["LogDate"].ToString()),
        //                decimal.Parse(dr["Amount"].ToString()),
        //                dr["Details"].ToString(),
        //                dr["LogTypeID"].ToString(),
        //                dr["ATMID"].ToString(),
        //                dr["CardNo"].ToString(),
        //                dr["CardNoTo"].ToString());
        //            listLog.Add(log);
        //        }
        //        dbContext.CloseConnection();
        //        return listLog;
        //    }
        //    catch 
        //    {
        //        if (dbContext.CHECK_OPEN)
        //        {
        //            dbContext.CloseConnection();
        //        }
        //        return null;
        //    }
            
              
        //}
    }
}
