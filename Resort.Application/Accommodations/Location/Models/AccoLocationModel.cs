using System;
using System.Collections.Generic;
using System.Text;

namespace Resort.Application.Accommodations.Location.Models
{
    public class AccoLocationModel
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public string Distance { get; set; }
        public string DistanceDescription { get; set; }
        public double? Longitude { get; set; }
        public double? Latitude { get; set; }
        public long? LanguageId { get; set; }
    }
}
