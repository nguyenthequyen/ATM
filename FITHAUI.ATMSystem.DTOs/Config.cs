using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FITHAUI.ATMSystem
{
    public class Config
    {
        /// <summary>
        /// Id cấu hình
        /// </summary>
        public string ConfigID { get; set; }
        /// <summary>
        /// Số tiền tối thiểu mỗi lần rút
        /// </summary>
        public decimal MinWithdraw { get; set; }
        /// <summary>
        /// Số tiền tối đa rút trong ngày
        /// </summary>
        public decimal MaxWithdraw { get; set; }
        /// <summary>
        /// Ngày cập nhật
        /// </summary>
        public DateTime DateModified { get; set; }
        /// <summary>
        /// Số bản ghi được hiển thị trên mỗi trang ở màn hình hiển thị kết quả tìm kiếm
        /// </summary>
        public int NumberPage { get; set; }

        public Config()
        {

        }

        public Config(string configID, decimal minWithdraw, decimal maxWithdraw, DateTime dateModified, int numberPage)
        {
            ConfigID = configID;
            MinWithdraw = minWithdraw;
            MaxWithdraw = maxWithdraw;
            DateModified = dateModified;
            NumberPage = numberPage;
        }
    }
}
