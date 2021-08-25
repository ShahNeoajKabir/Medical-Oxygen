using System;
using System.Collections.Generic;
using System.Text;

namespace ModelClass.DTO
{
    public class Product
    {
        public int ProductId { get; set; }
        public int CategoriesId { get; set; }
        public int BrandId { get; set; }
        public int TagId { get; set; }
        public int AttributeId { get; set; }
        public string ProductCode { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public decimal RegularPrice { get; set; }
        public decimal? DiscountPrice { get; set; }
        public string Description { get; set; }
        public int StockQuantity { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int Status { get; set; }
        public Categories Categories { get; set; }
        public Tag Tag { get; set; }
        public Attributesss Attribute { get; set; }
        public Brand Brand { get; set; }
        public OrderTable OrderTable { get; set; }
    }
    public class ProductSearch
    {
        public string Search { get; set; }
    }
}
