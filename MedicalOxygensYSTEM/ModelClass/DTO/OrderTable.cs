using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ModelClass.DTO
{
    public class OrderTable
    {
        public int BillId { get; set; }
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public double BillAmount { get; set; }
        public int BillStatus { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int Status { get; set; }
        [NotMapped]
        public string CustomerName { get; set; }
        [NotMapped]

        public string ProductName { get; set; }
        public Customer Customer { get; set; }
        public Product Product { get; set; }
        public Payment Payment { get; set; }
    }

    public class BillTableSearch
    {
        public string Search { get; set; }
    }
}

