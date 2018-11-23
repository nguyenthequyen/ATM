using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FITHAUI.ATMSystem
{
    public class OverDraft
    {
        /// <summary>
        /// Mã mức thấu chi
        /// </summary>
        public string ODID { get; set; }
        /// <summary>
        /// Số tiền mà một tài khoản có thể thấu chi
        /// </summary>
        public string Value { get; set; }

        public OverDraft()
        {

        }

        public OverDraft(string oDID, string value)
        {
            ODID = oDID;
            Value = value;
        }
    }
}
