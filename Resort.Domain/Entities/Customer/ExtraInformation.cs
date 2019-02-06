﻿using System;
using System.Collections.Generic;

namespace Resort.Domain.Entities
{
    public partial class ExtraInformation
    {
        public long CustomerId { get; set; }
        public string School { get; set; }
        public string Work { get; set; }
        public string TimeZone { get; set; }
        public string EmergencyContact { get; set; }
        public string Occupation { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
