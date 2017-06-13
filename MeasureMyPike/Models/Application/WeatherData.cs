using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MeasureMyPike.Models.Application
{
    public class WeatherData
    {
        public int Id { get; set; }
        public int Temperature { get; set; }
        public string Weather { get; set; }
        public string MoonPosition { get; set; }
    }
}