using System;
using System.Collections.Generic;
using System.Text;

namespace ModelClass.DTO
{
    public class CustomerBillingAddress
    {
        public int BillingAddressId { get; set; }
        public int CustomerId { get; set; }
        public string StreetAddress { get; set; }
        public string PostalCode { get; set; }
        public string District { get; set; }
        public Customer Customer { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int Status { get; set; }
    }
}
