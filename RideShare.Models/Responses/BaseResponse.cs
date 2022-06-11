using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.Json.Serialization;
using System.Net;

namespace RideShare.Models.Responses
{
    public class BaseResponse<T>
    {
        [JsonPropertyName("status")]
        public HttpStatusCode Status { get; set; }

        [JsonPropertyName("message")]
        public string Message { get; set; }

        [JsonPropertyName("data")]
        public T Data { get; set; }
    }
}