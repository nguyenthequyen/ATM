using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FITHAUI.ATMSystem.DALs;

namespace FITHAUI.ATMSystem.BULs
{
    public class Config_BUL
    {
        Config_DAL configdal = new Config_DAL();

        public bool checkMoney(int money)
        {
            if (money <= configdal.getMaxWithDraw())
                return true;
            else
                return false;
        }
    }
}
