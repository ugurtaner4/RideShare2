using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RideShare.Models.Responses
{
    public class SearchTravelResponse 
    {
       
        public List<SearchTravelResponseItem> SearchTravelItem { get; set; }
    }

    public class SearchTravelResponseItem
    {
        public string SourceLocation { get; set; }
        public string TargetLocation { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public int EmptySeat { get; set; }
    }
}