using System;
using System.Collections.Generic;
using System.Text;

namespace ModelClass.DTO
{
    public class Payment
    {
        public int PaymentId { get; set; }
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
        public int PaymentMethod { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int Status { get; set; }
        public OrderTable OrderTable { get; set; }
    }
}
