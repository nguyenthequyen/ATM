using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FITHAUI.ATMSystem.DALs
{
    public class Databasecontext
    {
        //private static readonly log4net.ILog log =log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private string _connectionString = ConfigurationManager.ConnectionStrings["ATMSystem"].ToString();
        private SqlConnection _sqlConnection;
        /// <summary>
        /// Mở kết nối cơ sở dữ liệu
        /// </summary>
        public bool OpenConnection()
        {
            try
            {
                _sqlConnection = new SqlConnection(_connectionString);
                _sqlConnection.Open();
            }
            catch (SqlException sqlException)
            {
                Console.Write("----------------------Lỗi---------------------" + sqlException.Message);
                //log.Error(sqlException.Message);
                return false;
            }
            return true;
        }

        public void OpenConection()
        {
            try
            {
                _sqlConnection = new SqlConnection(_connectionString);
                _sqlConnection.Open();
            }
            catch (SqlException sqlException)
            {
                Console.Write("----------------------Lỗi---------------------" + sqlException.Message);
                //log.Error(sqlException.Message);
            }
        }

        /// <summary>
        /// Đóng kết nối cơ sở dữ liệu
        /// </summary>
        public void CloseConnection()
        {
            _sqlConnection.Close();
        }
        /// <summary>
        /// Thực hiện câu lệnh truy vấn
        /// </summary>
        /// <param name="query"></param>
        public void ExcuteNonQuery(string query)
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand(query);
                sqlCommand.ExecuteNonQuery();
            }
            catch (SqlException sqlException)
            {
                Console.Write("----------------------Lỗi---------------------" + sqlException.Message);
                //log.Error(sqlException.Message);
            }
        }
        /// <summary>
        /// Sử dụng để đọc dữ liệu
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public SqlDataReader DataReader(string query)
        {
            SqlCommand cmd = new SqlCommand(query, _sqlConnection);
            SqlDataReader dr = cmd.ExecuteReader();
            return dr;
        }

        /// <summary>
        /// Hiện thị dữ liệu lên datagirdview
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public object ShowDataInGridView(string query)
        {
            SqlDataAdapter dr = new SqlDataAdapter(query, _connectionString);
            DataSet ds = new DataSet();
            dr.Fill(ds);
            object dataum = ds.Tables[0];
            return dataum;
        }
    }
}
