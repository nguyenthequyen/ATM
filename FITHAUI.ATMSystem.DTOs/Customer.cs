using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FITHAUI.ATMSystem
{
    class Customer
    {
        /// <summary>
        /// Mã khách hàng
        /// </summary>
        public string CustomerID { get; set; }
        /// <summary>
        /// Tên khách hàng
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Số điện thoại
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Email
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// Địa chỉ
        /// </summary>
        public string Address { get; set; }

        public Customer()
        {

        }

        public Customer(string customerID, string name, string email, string phone)
        {
            CustomerID = customerID;
            Name = name;
            Email = email;
            Phone = phone;
        }
    }
}
