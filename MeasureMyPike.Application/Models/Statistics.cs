using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MeasureMyPike.Models.Application
{
    public class Statistics
    {
        public int Id { get; set; }
        public DateTime Timestamp { get; set; }
        public int CatchId { get; set; }
        public int UserId { get; set; }
        public string UserName { get; internal set; }
        public string Comment { get; set; }
        public Double? WaterTemperature { get; set; }
        public Double? AirTemperature { get; set; }
        public string Weather { get; set; }
        public string MoonPhase { get; set; }
        public int FishId { get; set; }
        public string FishLength { get; internal set; }
        public string FishWeight { get; internal set; }
        public int LocationId { get; set; }
        public string LocationCoordinates { get; internal set; }
        public int LakeId { get; internal set; }
        public string LakeName { get; internal set; }
        public int LureId { get; set; }
        public string LureName { get; internal set; }
        public string LureBrand { get; internal set; }
        public int? LureWeight { get; internal set; }
    }
}