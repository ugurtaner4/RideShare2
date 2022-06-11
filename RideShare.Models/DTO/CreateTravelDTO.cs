using System;
using System.Collections.Generic;
using System.Text;

namespace RideShare.Models.DTO
{
    public class CreateTravelDTO
    {
        public string SourceLocation { get; set; }
        public string TargetLocation { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public int AvailableSeat { get; set; }
        public string TravelId { get; set; }
        public Boolean IsPublish { get; set; }
    }
}
