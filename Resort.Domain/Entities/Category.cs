using System;
using System.Collections.Generic;

namespace Resort.Domain.Entities
{
    public partial class Category
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Modify { get; set; }
        public string Status { get; set; }

        public virtual Accommodation Accommodation { get; set; }
    }
}
