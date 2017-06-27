using System;

namespace MeasureMyPike.Models.Application
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Lastname { get; set; }
        public string Firstname { get; set; }
        public DateTime MemberSince { get; set; }

    }
}