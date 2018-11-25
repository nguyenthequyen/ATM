using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FITHAUI.ATMSystem.UI
{
    public class CheckLengthPIN
    {
        public bool checkLengthPIN(string str)
        {
            if (str.Length == 6)
            {
                return true;
            }
            else return false;
        }
    }
}
