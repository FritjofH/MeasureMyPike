using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MeasureMyPike.Models.Application
{
    public class Security
    {
        public int Id { get; set; }
        public string Password { get; set; }
        public int UserId { get; set; }
    }
}