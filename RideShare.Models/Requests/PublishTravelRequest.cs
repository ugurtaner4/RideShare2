using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RideShare.Models.Requests
{
    public class PublishTravelRequest
    {
        public PublishTravelRequestItem PublishTravelItem { get; set; }
    }
    public class PublishTravelRequestItem
    {
        public int UserId { get; set; }
        public string TravelId {  get; set; }
        public bool IsPublish { get; set; }
    }
}