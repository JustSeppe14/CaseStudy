using Contentful.Core.Models;
using System;

namespace bike_site.Models
{
    public class Bikes
    {
        public Asset BikeImage { get; set; }
        public string Brand { get; set; }
        public string BikeName {get; set;}
        public string Type {get; set;}
        public string Groupset { get; set; }
        public int AmountOfGears {get; set;}
        public string Suspension { get; set; }
        public int Price { get; set; }
        public string BikeSite { get; set; }
    }
}
