using System;
using System.Collections.Generic;

#nullable disable

namespace DataAnalyse.Entity
{
    public partial class Location
    {
        public string Province { get; set; }
        public string City { get; set; }
        public float? Latitude { get; set; }
        public float? Longitude { get; set; }
    }
}
