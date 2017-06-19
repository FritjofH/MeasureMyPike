using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MeasureMyPike.Models.Application
{
    public class MediaData
    {
        public int id { get; set; }
        public byte[] data { get; set; }
        public int length { get; set; }
    }
}