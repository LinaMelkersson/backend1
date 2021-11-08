using System;
using System.Collections.Generic;

#nullable disable

namespace API.Entities
{
    public partial class SubCategorye
    {
        public SubCategorye()
        {
            Products = new HashSet<Product>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryesId { get; set; }

        public virtual Categorye Categoryes { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
