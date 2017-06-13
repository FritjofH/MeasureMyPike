using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MeasureMyPike.Models.Application
{
    public class Catch
    {
        public int Id { get; set; }
        public DateTime Timestamp { get; set; }
        public int UserId { get; set; }
        public int CommentId { get; set; }
        public int FishId { get; set; }
        public int[] MediaId { get; set; }
        public int LocationId { get; set; }
        public int LuresId { get; set; }
        public int WeatherData { get; set; }
    }
}