using System;
using System.Collections.Generic;
using System.Text;

namespace ModelClass.DTO
{
    public class Cart
    {
        public int CartId { get; set; }
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public Customer Customer { get; set; }
        public Product Product { get; set; }
        public OrderTable OrderTable { get; set; }
    }
}
