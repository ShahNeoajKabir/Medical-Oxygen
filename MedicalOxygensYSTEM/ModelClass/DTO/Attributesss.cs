using System;
using System.Collections.Generic;
using System.Text;

namespace ModelClass.DTO
{
    public class Attributesss
    {
        public int AttributeId { get; set; }
        public string AttributeName { get; set; }
        public string AttributeValue { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int Status { get; set; }
        public ICollection<Product> Product { get; set; }
    }
}
