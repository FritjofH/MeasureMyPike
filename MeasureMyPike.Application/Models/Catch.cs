using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MeasureMyPike.Models.Application
{
    public class Catch
    {
        public int id { get; set; }
        public DateTime timestamp { get; set; }
        public int userId { get; set; }
        public int commentId { get; set; }
        public int fishId { get; set; }
        public List<int> mediaId { get; set; }
        public int locationId { get; set; }
        public int luresId { get; set; }
        public int weatherData { get; set; }
    }
}