using FITHAUI.ATMSystem.DALs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FITHAUI.ATMSystem.BULs
{
    public class ATM_BUL
    {
        ATM_DAL aTM_DAL = new ATM_DAL();
        public List<ATM> GetATMName()
        {
            return aTM_DAL.GetATMName();
        }
    }
}
