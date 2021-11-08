using System;
using System.Collections.Generic;

#nullable disable

namespace API.Entities
{
    public partial class Order
    {
        public Order()
        {
            OderLines = new HashSet<OderLine>();
        }

        public int Id { get; set; }
        public int UsersId { get; set; }
        public DateTime OrderDate { get; set; }
        public string Status { get; set; }
        public int UserAddressesId { get; set; }
        public decimal TotalAmount { get; set; }

        public virtual UserAddress UserAddresses { get; set; }
        public virtual User Users { get; set; }
        public virtual ICollection<OderLine> OderLines { get; set; }
    }
}
