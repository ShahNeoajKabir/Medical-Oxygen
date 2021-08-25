using System;
using System.Collections.Generic;
using System.Text;

namespace ModelClass.ViewModel
{
    public class VMMaster
    {
        public DateTime SalesDate { get; set; }
        public double TotalAmount { get; set; }
        public string ItemName { get; set; }
        public double ItemRate { get; set; }
        public int ItemQuantity { get; set; }
    }
}
