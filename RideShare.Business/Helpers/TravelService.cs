using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using RideShare.Models;
using RideShare.Models.DTO;
using RideShare.Models.Requests;
using RideShare.Models.Responses;

namespace RideShare.Business.Helpers
{
   public class TravelService
    {
        public BaseResponse<CreateTravelResponse> CreateTravel(CreateTravelRequest request)
        {
            if(!ValidationHelper.ValidateCreateTravelRequest(request))
                return ResponseHelper.GetResponse<CreateTravelResponse>("Bad Request", System.Net.HttpStatusCode.BadRequest, null);
            try
            {
                var response = new CreateTravelResponse();

                var item = request.TravelItem;

                var createTravelDto = new CreateTravelDTO()
                {
                    AvailableSeat = item.AvailableSeat,
                    Date = item.Date,
                    Description = item.Description,
                    SourceLocation = item.SourceLocation,
                    TargetLocation = item.TargetLocation,
                    TravelId = Guid.NewGuid().ToString(),
                    IsPublish = true
                };

                var list = JsonHelper.ReadJson<CreateTravelDTO>();

                list.Add(createTravelDto);

                JsonHelper.WriteJson<CreateTravelDTO>(list);

                response.TravelId = createTravelDto.TravelId;


                return ResponseHelper.GetResponse<CreateTravelResponse>("Success", System.Net.HttpStatusCode.OK, response);

            }
            catch (Exception ex)
            {
                return ResponseHelper.GetResponse<CreateTravelResponse>(ex.Message, System.Net.HttpStatusCode.InternalServerError, null);
            }
   }
        public BaseResponse<PublishTravelResponse> PublishTravel(PublishTravelRequest request)
        {
            if (!ValidationHelper.ValidatePublishTravelRequest(request))
                return ResponseHelper.GetResponse<PublishTravelResponse>("Bad Request", System.Net.HttpStatusCode.BadRequest, null);
            try
            {
                var list = JsonHelper.ReadJson<CreateTravelDTO>();

                var element = list.Where(x => x.TravelId == request.PublishTravelItem.TravelId);

                if (!element.Any())
                    return ResponseHelper.GetResponse<PublishTravelResponse>("Not Found", System.Net.HttpStatusCode.NotFound, null);

                  element.First().IsPublish = request.PublishTravelItem.IsPublish;

                JsonHelper.WriteJson<CreateTravelDTO>(list);

                return ResponseHelper.GetResponse<PublishTravelResponse>("Success", System.Net.HttpStatusCode.OK, null);
            }
            catch (Exception ex)
            {
                return ResponseHelper.GetResponse<PublishTravelResponse>(ex.Message, System.Net.HttpStatusCode.InternalServerError, null);
            }

        }
        public BaseResponse<SearchTravelResponse> SearchTravel(SearchTravelRequest request)
        {
            if (!ValidationHelper.ValidateSearchTravelRequest(request))
                return ResponseHelper.GetResponse<SearchTravelResponse>("Bad Request", System.Net.HttpStatusCode.BadRequest, null);
            try
            {
                var response = new BaseResponse<SearchTravelResponse>();

                var list = JsonHelper.ReadJson<CreateTravelDTO>();

                var element = list.Where(x => x.SourceLocation == request.SearchTravelItem.SourceLocation && x.TargetLocation == request.SearchTravelItem.TargetLocation && x.IsPublish == true);

                if (!element.Any())
                    return ResponseHelper.GetResponse<SearchTravelResponse>("Not Found", System.Net.HttpStatusCode.NotFound, null);

                var filteredList = element;
                response.Data = new SearchTravelResponse();
                response.Data.SearchTravelItem = new List<SearchTravelResponseItem>();

                foreach (var item in filteredList)
                {
                    var searchTravelItem = new SearchTravelResponseItem()
                    {
                        Date = item.Date,
                        Description = item.Description,
                        EmptySeat = item.AvailableSeat,
                        SourceLocation = item.SourceLocation,
                        TargetLocation = item.TargetLocation
                    };

                    response.Data.SearchTravelItem.Add(searchTravelItem);
                }

                return ResponseHelper.GetResponse<SearchTravelResponse>("Success", System.Net.HttpStatusCode.OK, response.Data);
            }
            catch (Exception ex)
            {
                return ResponseHelper.GetResponse<SearchTravelResponse>(ex.Message, System.Net.HttpStatusCode.InternalServerError, null);
            }
        }
        public BaseResponse<SubscribeTravelResponse> SubscribeTravel(SubscribeTravelRequest request)
        {
            if (!ValidationHelper.ValidateSubscribeTravelRequest(request))
                return ResponseHelper.GetResponse<SubscribeTravelResponse>("Bad Request", System.Net.HttpStatusCode.BadRequest, null);
            try
            {
                var response = new BaseResponse<SubscribeTravelResponse>();

                var list = JsonHelper.ReadJson<CreateTravelDTO>();

                var element = list.Where(x => x.TravelId == request.SubscribeTravelItem.TravelId);

                if (!element.Any())
                    return ResponseHelper.GetResponse<SubscribeTravelResponse>("Not Found", System.Net.HttpStatusCode.NotFound, null);

                var avaiableSeat = element.First().AvailableSeat;

                if (avaiableSeat >= request.SubscribeTravelItem.RequestedSeatCount)
                {
                    avaiableSeat = avaiableSeat - request.SubscribeTravelItem.RequestedSeatCount;

                    element.First().AvailableSeat = avaiableSeat;

                    JsonHelper.WriteJson<CreateTravelDTO>(list);

                    return ResponseHelper.GetResponse<SubscribeTravelResponse>("Success", System.Net.HttpStatusCode.OK, null);
                }
                else
                {
                    return ResponseHelper.GetResponse<SubscribeTravelResponse>("Seats Not Available", System.Net.HttpStatusCode.NotFound, null);
                }
            }
            catch (Exception ex)
            {
                return ResponseHelper.GetResponse<SubscribeTravelResponse>(ex.Message, System.Net.HttpStatusCode.InternalServerError, null);
            }
        }
    }
}
