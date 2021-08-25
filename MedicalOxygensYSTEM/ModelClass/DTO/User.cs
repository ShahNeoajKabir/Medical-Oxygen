using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ModelClass.DTO
{
    public class User
    {
        public int UserId { get; set; }
        public string Image { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string MobileNumber { get; set; }
        public int UserType { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int Status { get; set; }
        [NotMapped]
        public int Role { get; set; }
        public ICollection<UserRole> UserRole { get; set; }

    }
    public class UserSearch
    {
        public string Search { get; set; }
    }
}
