using RideShare.Models.Requests;
using System;
using System.Collections.Generic;
using System.Text;

namespace RideShare.Business.Helpers
{
    public class ValidationHelper
    {
        public static Boolean ValidateCreateTravelRequest(CreateTravelRequest request)
        {
            return request != null && request.TravelItem != null && request.TravelItem.AvailableSeat != 0 &&
                request.TravelItem.Date != null && !string.IsNullOrEmpty(request.TravelItem.SourceLocation) && !string.IsNullOrEmpty(request.TravelItem.TargetLocation);
        }
        public static Boolean ValidateSearchTravelRequest(SearchTravelRequest request)
        {
            return request != null && !string.IsNullOrEmpty(request.SearchTravelItem.SourceLocation) && !string.IsNullOrEmpty(request.SearchTravelItem.TargetLocation);
        }
        public static Boolean ValidateSubscribeTravelRequest(SubscribeTravelRequest request)
        {
            return request != null && request.SubscribeTravelItem.RequestedSeatCount != 0 && request.SubscribeTravelItem.TravelId != null;
        }
        public static Boolean ValidatePublishTravelRequest(PublishTravelRequest request)
        {
            return request != null && request.PublishTravelItem.TravelId != null;
        }
    }
}
