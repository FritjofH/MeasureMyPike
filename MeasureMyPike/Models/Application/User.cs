using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MeasureMyPike.Models.Application
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public System.DateTime MemberSince { get; set; }
    }
}