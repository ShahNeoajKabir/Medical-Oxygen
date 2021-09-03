using System;
using System.Collections.Generic;
using System.Text;

namespace ModelClass.DTO
{
    public class Tag
    {
        public int TagId { get; set; }
        public string TagName { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int Status { get; set; }

    }
}
