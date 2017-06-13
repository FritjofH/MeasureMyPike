using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MeasureMyPike.Models.Application
{
    public class Location
    {
        public int Id { get; set; }
        public string Lake { get; set; }
        public string Coordinates { get; set; }
    }
}