using System;
using System.Collections.Generic;

#nullable disable

namespace API.Entities
{
    public partial class Product
    {
        public Product()
        {
            OderLines = new HashSet<OderLine>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public decimal Price { get; set; }
        public int SubCategoryesId { get; set; }

        public virtual SubCategorye SubCategoryes { get; set; }
        public virtual ICollection<OderLine> OderLines { get; set; }
    }
}
