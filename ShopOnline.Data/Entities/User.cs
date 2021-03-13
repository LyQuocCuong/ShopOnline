using ShopOnline.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnline.Data.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public DateTime DOB { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public DateTime LastLoginDate { get; set; }
        public UserStatus Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsDeleted { get; set; }

        //inverse navigation property
        public ICollection<Order> Orders { get; set; }
        public ICollection<SysLogActivity> SysLogActivities { get; set; }
        //Many-to-Many
        public ICollection<UserRole> UserRoles { get; set; }
    }
}
