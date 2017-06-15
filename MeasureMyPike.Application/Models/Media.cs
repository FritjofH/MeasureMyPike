using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MeasureMyPike.Models.Application
{
    public class Media
    {
        public int Id { get; set; }
        public string MediaFormat { get; set; }
        public int MediaDataId { get; set; }
    }
}