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

            //Skapar upp en användare, om inte en med samma användarnamn redan finns
            var resultText = dbconn.createUser("Höst", "Fritjof", "hostf", "hemligt");
            Debug.WriteLine(resultText);

            //Ska fungera
            resultText = dbconn.login("hostf", "hemligt");
            Debug.WriteLine(resultText);
            
            //Ska faila
            resultText = dbconn.login("hostf", "gemligt");
            Debug.WriteLine(resultText);
        }
    }
}
