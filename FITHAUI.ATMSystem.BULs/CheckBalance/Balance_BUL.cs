using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FITHAUI.ATMSystem
{

    public class Balance_BUL
    {
        Balance_DAL balance = new Balance_DAL();
        /// <summary>
        /// Số dư thực tế
        /// </summary>
        /// <param name="cardNo"></param>
        /// <returns></returns>
        public string GetBalance(string cardNo)
        {
            int ba = balance.CheckBalance(cardNo);
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
            int ba = (balance.CheckBalance(cardNo) - 50000);
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
    }
}
