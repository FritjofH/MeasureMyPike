using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MeasureMyPike.Models.Application
{
    public class MediaData
    {
        public int Id { get; set; }
        public byte[] Data { get; set; }
        public int Length { get; set; }
    }
}