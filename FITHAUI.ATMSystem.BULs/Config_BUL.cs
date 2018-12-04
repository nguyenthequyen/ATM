using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FITHAUI.ATMSystem
{
    public class Config_BUL
    {
        Config_DAL configdal = new Config_DAL();

        public bool CheckMoney(int money)
        {
            if (money <= configdal.GetMaxWithDraw())
                return true;
            else
                return false;
        }
    }
}
