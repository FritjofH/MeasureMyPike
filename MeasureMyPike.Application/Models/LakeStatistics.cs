using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MeasureMyPike.Models.Application
{
    public class LakeStatistics
    {
        public int LakeId { get; set; }
        public string LakeName { get; set; }
        public int LocationId { get; set; }
        public string LocationCoordinates { get; set; }
        public List<int> CatchId { get; set; }
        public int TotalFishLength { get; set; }
        public int TotalFishWeight { get; set; }
    }
}