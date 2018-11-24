using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FITHAUI.ATMSystem.DALs;

namespace FITHAUI.ATMSystem.BULs
{
    public class StockBUL
    {
        StockDAL stockDAL = new StockDAL();
        public string updateQuantity(int money)
        {
            int multiples = getMultiples();

            if (multiples == 0) // Hết tiền (bội số bằng 0 -> Không có tờ tiền nào trong cây)
                return "SystemError";
            else if (money % multiples != 0 || money < 50000)   // Không phải bội số
                return "ErrorMoneyType";
            else
            {
                string totalMoney = customSheet(money);
                if (totalMoney.Equals("SystemError"))   // Hết tiền.(vd: có 1 tờ 10k => bội = 10k. Rút 100k => hệ thống chỉ có 10k để trả => Hết tiền)
                    return "SystemError";

                string[] arrMoney = totalMoney.Split('&');
                string[] typeOne = null;
                int count = 0;
                int moneyValue = 0;
                string moneyID = "";
                bool update = true;
                for (int i = 0; i < arrMoney.Length; i++)
                {
                    typeOne = arrMoney[i].Split('-');
                    count = Convert.ToInt32(typeOne[0]);
                    moneyValue = Convert.ToInt32(typeOne[1]);
                    moneyID = getMoneyId(moneyValue);
                    update = stockDAL.updateQuantity("b936bf52-94d0-488f-bcda-1e4f1ecc422f", moneyID, count);
                    if (!update)
                        return "ErrorSystem";
                }
                return "Success";
            }
        }

        public int getMultiples()
        {
            int[] money = new int[] { 500000, 200000, 100000, 50000, 20000, 10000 };
            for (int i = money.Length - 1; i >= 0; i--)
            {
                int quantity = getQuantity("b936bf52-94d0-488f-bcda-1e4f1ecc422f", getMoneyId(money[i]));
                int currentMoney = quantity * money[i];

                if (quantity > 0)
                    return money[i];
            }
            return 0;
        }

        private string getMoneyId(int money)
        {
            if (money == 10000)
                return "8d0df24b-a494-4d34-af1b-e67195080410";
            else if (money == 20000)
                return "7e34377c-3774-46bd-9030-9a1e9356c5b0";
            else if (money == 50000)
                return "79658465-775c-449d-b1ac-c51812886d7c";
            else if (money == 100000)
                return "24a21df7-143d-40ae-9b3d-245a022efb75";
            else if (money == 200000)
                return "b75f52b6-0467-432a-a274-ea209efed713";
            else if (money == 500000)
                return "2e585453-33d3-4ecf-9c5f-740bad7fd74a";
            else
                return "";
        }

        private int getQuantity(string atmID, string moneyID)
        {
            return stockDAL.getQuantity(atmID, moneyID);
        }

        private string customSheet(int mon)
        {
            int[] money = new int[] { 500000, 200000, 100000, 50000, 20000, 10000 };
            string ways = "";
            int total, countSheet;
            int mod = 0, currentMoney = 0, quantity = 0;
            bool checkTotal = true;
            int index = -1;

            total = mon;
            for (int i = 0; i < money.Length; i++)
            {
                countSheet = total / money[i];
                if (countSheet != 0)
                {
                    int tienChan = countSheet * money[i];
                    quantity = getQuantity("b936bf52-94d0-488f-bcda-1e4f1ecc422f", getMoneyId(money[i]));
                    currentMoney = quantity * money[i];
                    if (money[i] > currentMoney)
                        continue;
                    else if (tienChan > currentMoney)   //kiểm tra số tiền còn trong DB
                    {
                        mod = total - currentMoney;
                        countSheet = currentMoney / money[i];
                        index = i;
                    }
                    else
                        mod = total - tienChan;
                    ways = countSheet + "-" + money[i];
                    if (mod == 0)
                        break;
                    else
                    {
                        String pence = "";
                        while (mod != 0 && checkTotal)
                        {
                            for (int j = 0; j < money.Length; j++)
                            {
                                countSheet = mod / money[j];
                                if (index == j)
                                {
                                    if (j == 5 && mod != 0)
                                    {
                                        checkTotal = false;
                                        break;
                                    }
                                    continue;
                                }
                                if (countSheet != 0)
                                {
                                    tienChan = countSheet * money[j];
                                    quantity = getQuantity("b936bf52-94d0-488f-bcda-1e4f1ecc422f", getMoneyId(money[j]));
                                    currentMoney = quantity * money[j];
                                    if (money[j] > currentMoney)    //kiểm tra số tiền còn trong DB
                                    {
                                        if (j == 5 && mod != 0)
                                        {
                                            checkTotal = false;
                                            break;
                                        }
                                        continue;
                                    }
                                    else if (tienChan > currentMoney)
                                    {
                                        if (j == 5 && mod != 0)
                                        {
                                            checkTotal = false;
                                            break;
                                        }
                                        mod = mod - currentMoney;
                                        countSheet = currentMoney / money[j];
                                        index = j;
                                    }
                                    else
                                        mod -= tienChan;
                                    pence += "&" + countSheet + "-" + money[j];
                                }
                            }
                        }
                        ways += pence;
                        break;
                    }
                }
            }
            if (checkTotal && ways != "")
                return ways;
            else
                return "SystemError";   // Hết tiền
        }
    }
}
