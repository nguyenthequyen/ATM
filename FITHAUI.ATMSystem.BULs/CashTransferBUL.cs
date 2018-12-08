using FITHAUI.ATMSystem.DALs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FITHAUI.ATMSystem.BULs.CashTransfer
{
    public class CashTransferBUL
    {
        CashTransferDAL cashTransferDAL = new CashTransferDAL();

        public string GetNameCustomer(string cardNo)
        {
            return cashTransferDAL.GetNameCustomer(cardNo);
        }

        public void UpdateBalance(int money, string cardNo, string cardNoTo, int transferFee)
        {
            cashTransferDAL.UpdateBalance(money, cardNo, cardNoTo, transferFee);
        }

        public bool CompareBalance(int money, string cardNo, int transferFee)
        {
            return cashTransferDAL.CompareBalance(money, cardNo, transferFee);
        }

        public bool CheckCardNo(string cardNo)
        {
            return cashTransferDAL.CheckCardNo(cardNo);
        }
    }
}
