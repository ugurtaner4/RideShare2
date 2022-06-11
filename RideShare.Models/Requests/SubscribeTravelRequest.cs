using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RideShare.Models.Requests
{
    public class SubscribeTravelRequest
    {
        public SubscribeTravelRequestItem SubscribeTravelItem { get; set; }
    }

    public class SubscribeTravelRequestItem
    {
        public string TravelId { get; set; }
        public int RequestedSeatCount { get; set; }
    }
}