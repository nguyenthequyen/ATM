using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FITHAUI.ATMSystem.DALs
{
    public class ATM_DAL
    {
        Databasecontext dbContext = new Databasecontext();
        public List<ATM> GetATMName()
        {
            string MachineName1 = Environment.MachineName;
            List<ATM> aTMs = new List<ATM>();
            try
            {
                var atmID = "";
                if (MachineName1 == "THE-QUYEN")
                {
                    atmID = "fc57dd25-0a60-427a-aaa5-f9d2059c8abb";
                }
                SqlCommand sqlCommand = new SqlCommand("Proc_GetATMName", dbContext.Connect);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add("@ATMId", SqlDbType.NVarChar).Value = atmID.Trim();
                dbContext.OpenConnection();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    ATM aTM = new ATM(
                        sqlDataReader["ATMID"].ToString(), 
                        sqlDataReader["Branch"].ToString(), 
                        sqlDataReader["Address"].ToString());
                    aTMs.Add(aTM);
                }
                dbContext.CloseConnection();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return aTMs;
        }
    }
}
