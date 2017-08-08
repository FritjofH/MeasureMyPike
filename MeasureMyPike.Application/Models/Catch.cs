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
        public List<int> MediaId { get; set; }
        public int LocationId { get; set; }
        public int LureId { get; set; }
        public int WeatherData { get; set; }
    }
    public class NewCatch
    {
        public int weight { get; set; }
        public int length { get; set; }
        public DateTime date { get; set; }
        public string lakeName { get; set; }
        public string lureName { get; set; }
        public int lureId { get; set; }
        public string weather { get; set; }
        public string comment { get; set; }
        public string coordinates { get; set; }
        public double airTemp { get; set; }
        public double waterTemp { get; set; }
        public string username { get; set; }
    };
}