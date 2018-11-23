using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FITHAUI.ATMSystem
{
    public class LogType
    {
        /// <summary>
        /// Mã log type sử dụng trong hệ thống
        /// </summary>
        public string LogTypeID { get; set; }
        /// <summary>
        /// Tên hoặc các chi tiết của log type
        /// </summary>
        public string Description { get; set; }

        public LogType()
        {

        }

        public LogType(string logTypeID, string description)
        {
            LogTypeID = logTypeID;
            Description = description;
        }
    }
}
