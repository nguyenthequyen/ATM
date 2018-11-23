using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FITHAUI.ATMSystem
{
    public class SetTextInput
    {
        /// <summary>
        /// Lớp nhập dữ liệu vào Textbox
        /// </summary>
        /// <param name="number">Số nhập từ button</param>
        /// <param name="cardNo">Số thẻ</param>
        /// <returns></returns>
        public string SetTextCardNo(string number, string cardNo)
        {
            return cardNo += number;
        }
    }
}
