using Contentful.Core.Models;
using System;

namespace bike_site.Models
{
    public class Bikes
    {
        public Asset BikeImage { get; set; }
        public string Brand { get; set; }
        public string BikeModel { get; set; }
        public int Price { get; set; }
        public string BikeSite { get; set; }
    }
}
