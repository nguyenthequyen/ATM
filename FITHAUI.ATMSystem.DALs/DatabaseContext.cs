using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FITHAUI.ATMSystem
{
    public class Databasecontext
    {
        //private static readonly log4net.ILog log =log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private static SqlConnection _sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ATMSystem"].ToString());
        /// <summary>
        /// Mở kết nối cơ sở dữ liệu
        /// </summary>
        /// 
        public static bool CHECK_OPEN = false;

        public SqlConnection Connect
        {
            get { return Databasecontext._sqlConnection; }
        }

        public void OpenConnection()
        {
            _sqlConnection.Open();
            CHECK_OPEN = true;
        }

        public void CloseConnection()
        {
            _sqlConnection.Close();
            CHECK_OPEN = false;
        }
    }
}
