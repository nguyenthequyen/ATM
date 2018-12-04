using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FITHAUI.ATMSystem
{
    public class Card_BUL
    {
        Card_DAL card_DAL = new Card_DAL();
        //Validate Card
        public bool CheckCardNo(string cardNo)
        {
            return card_DAL.CheckCardNo(cardNo);
        }
        //Validate PIN
        public string CheckPIN(string cardNo, String pin)
        {
            return card_DAL.CheckPIN(cardNo, pin);
        }
        //Update Attempt
        public void UpdateAttempt(string cardNo)
        {
            card_DAL.UpdateAttempt(cardNo);
        }
        //Get Attempt
        public bool CheckAttempt(string cardNo)
        {
            if(card_DAL.GetAttempt(cardNo)>=0 && card_DAL.GetAttempt(cardNo)<3)
            {
                return true;
            }
            else if(card_DAL.GetAttempt(cardNo)==-1 || card_DAL.GetAttempt(cardNo) == 3)
            {
                return false;
            }
            return true;
        }
        //Check status
        public bool CheckStatus(string cardNo)
        {
            if (card_DAL.GetAttempt(cardNo).Equals("normal"))
            {
                return true;
            }
            else if (card_DAL.GetAttempt(cardNo).Equals("block"))
            {
                return false;
            }
            return true;
        }
        //Change PIN
        public void ChangePIN(string cardNo,string newPIN)
        {            
            card_DAL.ChangePIN(cardNo,newPIN);
        }
        //Check ExpiredDate
        public bool CheckExpiredDate(string cardNo)
        {
            string currentDate = DateTime.Now.ToString("yyyy-MM-dd");
            int currentYear = Convert.ToInt32(currentDate.Split('-')[0]);
            int currentMonth = Convert.ToInt32(currentDate.Split('-')[1]);
            int currentDay = Convert.ToInt32(currentDate.Split('-')[2]);
            var date = card_DAL.GetExpiredDate(cardNo);
            int exYear = Convert.ToInt32(date.Substring(6,4));
            int exMonth = Convert.ToInt32(date.Substring(3,2));
            int exDay = Convert.ToInt32(date.Substring(0,2));

            if (currentYear > exYear)
            {
                return false;
            }
            else if (currentYear == exYear)
            {
                if (currentMonth > exMonth)
                {
                    return false;
                }
                else if (currentMonth < exMonth)
                {
                    if (currentDay > exDay)
                    {
                        return false;
                    }
                    else if (currentDay < exDay)
                    {
                        return true;
                    }
                    else
                    {
                        return true;
                    }
                }
            }
            else
            {
                return true;
            }
            return false;
        }
    }
}
