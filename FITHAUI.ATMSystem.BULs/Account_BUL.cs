using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FITHAUI.ATMSystem
{

    public class Account_BUL
    {
        Account_DAL account = new Account_DAL();
        OverDraftLimitDAL overDraftLimitDAL = new OverDraftLimitDAL();

        /// <summary>
        /// Số dư thực tế
        /// </summary>
        /// <param name="cardNo"></param>
        /// <returns></returns>
        public string GetBalance(string cardNo)
        {
            int ba = account.CheckBalance(cardNo);
            string str = ba + "";
            List<char> arrChar = new List<char>();
            char[] arr = str.ToCharArray();
            if (arr.Length <= 3)
            {
                return str;
            }
            else
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    arrChar.Add(arr[i]);
                }

                int count = 1;
                for (int i = arr.Length - 1; i >= 0; i--)
                {
                    if (count < 3)
                    {
                        count++;
                    }
                    else if (count == 3)
                    {
                        if (i != 0)
                        {
                            arrChar.Insert(arrChar.Count - (arrChar.Count - i), ',');
                            count = 1;
                        }
                    }
                }
                return String.Join("", arrChar);
            }
        }
        /// <summary>
        /// Số dư cho phép
        /// </summary>
        /// <param name="cardNo"></param>
        /// <returns></returns>
        public string GetBalanceRight(string cardNo)
        {
            int ba = (account.CheckBalance(cardNo) - 50000);
            string str = ba + "";
            List<char> arrChar = new List<char>();
            char[] arr = str.ToCharArray();
            if (arr.Length <= 3)
            {
                return str;
            }
            else
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    arrChar.Add(arr[i]);
                }

                int count = 1;
                for (int i = arr.Length - 1; i >= 0; i--)
                {
                    if (count < 3)
                    {
                        count++;
                    }
                    else if (count == 3)
                    {
                        if (i != 0)
                        {
                            arrChar.Insert(arrChar.Count - (arrChar.Count - i), ',');
                            count = 1;
                        }
                    }
                }
                return String.Join("", arrChar);
            }
        }

        public bool CheckBalanceAndOverDraft(string cardNo, int money)
        {
            int balance = account.getBalance(cardNo);
            int overDraft = overDraftLimitDAL.GetOverDraft(cardNo);
            if (money <= balance + overDraft)
                return true;
            else
                return false;
        }

        public void UpdateBalance(int money, string cardNo)
        {
            account.UpdateBalance(money, cardNo);
        }
    }
}
