using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MeasureMyPike.Models.Application
{
    public class Lure
    {
        public int id { get; set; }
        public string name { get; set; }
        public int brandId { get; set; }
        public int weight { get; set; }
        public string colour { get; set; }
    }
}