using System;
using System.Collections.Generic;
using System.Text;

namespace ModelClass.DTO
{
    public class Categories
    {
        public int CategoriesId { get; set; }
        public string Image { get; set; }
        public string CategoriesName { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int Status { get; set; }
        public ICollection<Product> Product { get; set; }

    }
    public class CategoriesSearch
    {
        public string Search { get; set; }
    }
}
