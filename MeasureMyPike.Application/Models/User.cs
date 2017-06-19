using System;

namespace MeasureMyPike.Models.Application
{
    public class User
    {
        public int id { get; set; }
        public string username { get; set; }
        public string lastName { get; set; }
        public string firstName { get; set; }
        public DateTime memberSince { get; set; }
    }
}