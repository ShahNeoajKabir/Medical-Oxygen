using System;
using System.Collections.Generic;
using System.Text;

namespace ModelClass.DTO
{
    public class CustomerShippingAddress
    {
        public int ShippingAddressId { get; set; }
        public int CustomerId { get; set; }
        public string StreetAddress { get; set; }
        public string PostalCode { get; set; }
        public string District { get; set; }
        public User User { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int Status { get; set; }
        public Customer Customer { get; set; }
    }
}
