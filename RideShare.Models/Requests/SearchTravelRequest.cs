using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RideShare.Models.Requests
{
    public class SearchTravelRequest
    {
        public SearchTravelRequestItem SearchTravelItem { get; set; }
    }
    public class SearchTravelRequestItem
    {
        public string SourceLocation { get; set; }
        public string TargetLocation { get; set; }
    }
}