using System;
using System.Collections.Generic;
using System.Text;

namespace ModelClass.DTO
{
    public class Customer
    {
        public Customer()
        {
        }
        public int CustomerId { get; set; }
        public int? UserId { get; set; }
        public string CustomerName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string MobileNo { get; set; }
        public int Gender { get; set; } 
        public string Address { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? Status { get; set; }
        public string Image { get; set; }
        public OrderTable OrderTable { get; set; }
        public ICollection<CustomerBillingAddress> CustomerBillingAddress { get; set; }
        public ICollection<CustomerShippingAddress> CustomerShippingAddress { get; set; }
    }

    public class CustomerSearch
    {
        public string Search { get; set; }
    }
}
