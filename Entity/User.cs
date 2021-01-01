using System;
using System.Collections.Generic;

#nullable disable

namespace DataAnalyse
{
    public partial class User
    {
        public string Phone { get; set; }
        public string Name { get; set; }
        public string Idno { get; set; }
        public float? Latitude { get; set; }
        public float? Longitude { get; set; }
        public string Sex { get; set; }
        public string BloodGroup { get; set; }
        public string Mail { get; set; }
        public string Job { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public DateTime? Birthdate { get; set; }
        public string PricingPackage { get; set; }
    }
}
