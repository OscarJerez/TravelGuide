using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelGuide
{
    public class Route
    {
        public string StartCity { get; set; }
        public string EndCity { get; set; }
        public int Distance { get; set; }
        public int Time { get; set; }
        public int Cost { get; set; }
        public string TravelMethod { get; set; }

        public Route(string startCity, string endCity, int distance, int time, int cost, string travelMethod)
        {
            StartCity = startCity;
            EndCity = endCity;
            Distance = distance;
            Time = time;
            Cost = cost;
            TravelMethod = travelMethod;
        }
    }
}
