using System;
using System.Collections.Generic;
using System.Text;

namespace ModelClass.ViewModel
{
    public class VMProductDetails
    {
        public int ProductId { get; set; }
        public string ProductCode { get; set; }
        public string Title { get; set; }
        public string BrandName { get; set; }
        public string CategoriesName { get; set; }
        public string AttributeValue { get; set; }
        public string Description { get; set; }
        public int StockQuantity { get; set; }
        public string Image { get; set; }
        public decimal RegularPrice { get; set; }
        public decimal? DiscountPrice { get; set; }
    }
}
