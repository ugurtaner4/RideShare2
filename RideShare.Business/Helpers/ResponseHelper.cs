using RideShare.Models.Responses;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace RideShare.Business.Helpers
{
    public class ResponseHelper
    {
        public static BaseResponse<T> GetResponse<T>(string message, HttpStatusCode status, T data)
        {

            return new BaseResponse<T>()
            {
                Message= message,
                Status=status,
                Data=data
            };
        }
    }
}
