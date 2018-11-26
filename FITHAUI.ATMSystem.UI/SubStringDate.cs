using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FITHAUI.ATMSystem.UI
{
    public class SubStringDate
    {
        public string SubDate(string date)
        {
            string dateTime = date;
            string day = dateTime.Substring(0, 2);
            string month = dateTime.Substring(3, 2);
            string year = dateTime.Substring(8, 2);
            return day + "-" + month + "-" + year;
        }
        public string SubTime(string date)
        {
            string dateTime = date;
            string time = dateTime.Substring(11, 8);
            return time;
        }
    }
}
