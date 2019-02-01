using System;
using System.Collections.Generic;

namespace Resort.Domain.Entities
{
    public partial class SocialMedia
    {
        public long CustomerId { get; set; }
        public int? FacebookId { get; set; }
        public int? InstagramId { get; set; }
        public int? TwitterId { get; set; }
        public int? SnapchatId { get; set; }
        public int? PinterestId { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
