using System;
using System.Collections.Generic;
using System.Text;

namespace Resort.Application.Accommodations.SleepingArrangement.Models
{
    public class SleppingArragement_Model
    {
        public long AccommodationId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public long? LanguageId { get; set; }
    }
}
