using System;
using System.Collections.Generic;

namespace Resort.Domain.Entities
{
    public partial class Accessibility
    {
        public long AccommodationId { get; set; }
        public long? AccessibilityNameId { get; set; }
        public string Description { get; set; }

        public virtual AccessibilityName AccessibilityName { get; set; }
        public virtual Accommodation Accommodation { get; set; }
    }
}
