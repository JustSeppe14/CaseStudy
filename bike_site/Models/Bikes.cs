using Contentful.Core.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace bike_site.Models
{
    public class Bikes
    {
        
        public SystemProperties Sys {  get; set; }

       [JsonProperty("bikeName")]
       public string Model {get; set;}

       public string Groupset {get; set;}
       
       [JsonProperty("amountOfGears")]
       public int Gears {get; set;}

       public List<Asset> Image{get; set;}

       public Brand Brand { get; set;}

       public Type Type{get; set;}

       public string Description { get; set;}

       public int Price { get; set;}

       public string Suspension { get; set;}

       public string BikeSite { get; set;}

       public string Slug { get; set;}
    }
}
