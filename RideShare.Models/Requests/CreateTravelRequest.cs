using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RideShare.Models.Requests
{
    public class CreateTravelRequest // TODO Baseden türeyecek
    {
        public CreateTravelRequestItem TravelItem { get; set; }
    }

    public class CreateTravelRequestItem
    {
        public string SourceLocation { get; set; }
        public string TargetLocation { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public int AvailableSeat { get; set; }
    }
}