using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FITHAUI.ATMSystem
{
    public class ATM
    {
        /// <summary>
        /// Mã ATM
        /// </summary>
        public string ATMID { get; set; }
        /// <summary>
        /// Tên chi nhánh
        /// </summary>
        public string Branch { get; set; }
        /// <summary>
        /// Vị trí ATM
        /// </summary>
        public string Address { get; set; }

        public ATM()
        {

        }

        public ATM(string aTMID, string branch, string address)
        {
            ATMID = aTMID;
            Branch = branch;
            Address = address;
        }
    }
}
