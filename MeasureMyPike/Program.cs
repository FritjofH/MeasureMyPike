using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeasureMyPike
{
    class Program
    {
        static void Main(string[] args)
        {
            DatabaseConnection dbconn = new DatabaseConnection();
            dbconn.createUser("Höst", "Fritjof", "hostf", "hemligt");
        }
    }
}
