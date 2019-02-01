using System;
using System.Collections.Generic;

namespace Resort.Domain.Entities
{
    public partial class AccessibilityName
    {
        public AccessibilityName()
        {
            Accessibility = new HashSet<Accessibility>();
        }

        public long Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Accessibility> Accessibility { get; set; }
    }
}
