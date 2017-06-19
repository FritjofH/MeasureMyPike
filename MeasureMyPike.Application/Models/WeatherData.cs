using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MeasureMyPike.Models.Application
{
    public class WeatherData
    {
        public int id { get; set; }
        public int temperature { get; set; }
        public string weather { get; set; }
        public string moonPosition { get; set; }
    }
}