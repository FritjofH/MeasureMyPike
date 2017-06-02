using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeasureMyPike
{
    public class Program
    {
        public static void Main(string[] args)
        {
            DatabaseConnection dbconn = new DatabaseConnection();
            var resultText = dbconn.createUser("Höst", "Fritjof", "hostf", "hemligt");
            Debug.WriteLine(resultText);
        }
    }
}
