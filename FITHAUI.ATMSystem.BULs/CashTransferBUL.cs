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

        public string GetNameCustomer(string accountNo)
        {
            return cashTransferDAL.GetNameCustomer(accountNo);
        }

        public void UpdateBalance(int money, string cardNo, string accountNo, int transferFee)
        {
            cashTransferDAL.UpdateBalance(money, cardNo, accountNo, transferFee);
        }

        public bool CompareBalance(int money, string cardNo, int transferFee)
        {
            return cashTransferDAL.CompareBalance(money, cardNo, transferFee);
        }

        public bool CheckCardNo(string accountNo)
        {
            return cashTransferDAL.CheckCardNo(accountNo);
        }

        public string GetAccountIDByCardNo(string cardNo)
        {
            return cashTransferDAL.GetAccountIDByCardNo(cardNo);
        }

        public string GetCardNoByAccountNo(string accountNo)
        {
            return cashTransferDAL.GetCardNoByAccountNo(accountNo);
        }
    }
}
