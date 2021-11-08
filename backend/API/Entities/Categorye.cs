using System;
using System.Collections.Generic;

#nullable disable

namespace API.Entities
{
    public partial class Categorye
    {
        public Categorye()
        {
            SubCategoryes = new HashSet<SubCategorye>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<SubCategorye> SubCategoryes { get; set; }
    }
}
