using System;
using System.Collections.Generic;

#nullable disable

namespace API.Entities
{
    public partial class UserAddress
    {
        public UserAddress()
        {
            Orders = new HashSet<Order>();
            Users = new HashSet<User>();
        }

        public int Id { get; set; }
        public string Adress { get; set; }
        public string Zip { get; set; }
        public string City { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
