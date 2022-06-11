using RideShare.Business.Helpers;
using RideShare.Models.Requests;
using RideShare.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RideShare.Controllers
{
    public class RideShareController : ApiController
    {
        // GET api/values
        [Route("createTravel")]
        public BaseResponse<CreateTravelResponse> CreateTravel([FromBody]CreateTravelRequest value)
        {
            
            var response = new BaseResponse<CreateTravelResponse>();

            var travelService = new TravelService();

            response = travelService.CreateTravel(value);


            return response;
        }

        // GET api/values/5
        [Route("publishTravel")]
        public BaseResponse<PublishTravelResponse> PublishTravel([FromBody]PublishTravelRequest value)
        {
            var response = new BaseResponse<PublishTravelResponse>();

            var travelService = new TravelService();

            response = travelService.PublishTravel(value);


            return response;
        }

        // POST api/values
        [Route("searchTravel")]
        public BaseResponse<SearchTravelResponse> SearchTravel([FromBody]SearchTravelRequest value)
        {
            var response = new BaseResponse<SearchTravelResponse>();

            var travelService = new TravelService();

            response = travelService.SearchTravel(value);


            return response;
        }

        // PUT api/values/5
        [Route("subscribeTravel")]
        public BaseResponse<SubscribeTravelResponse> SubscribeTravel([FromBody]SubscribeTravelRequest value)
        {
            var response = new BaseResponse<SubscribeTravelResponse>();

            var travelService = new TravelService();

            response = travelService.SubscribeTravel(value);

            return response;
        }

       
    }
}
