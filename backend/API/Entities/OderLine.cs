using System;
using System.Collections.Generic;

#nullable disable

namespace API.Entities
{
    public partial class OderLine
    {
        public int Id { get; set; }
        public int OrdersId { get; set; }
        public int ProductsId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }

        public virtual Order Orders { get; set; }
        public virtual Product Products { get; set; }
    }
}
