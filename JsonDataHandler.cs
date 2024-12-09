using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelGuide
{
    public class JsonDataHandler
    {
        public string FilePath { get; set; }

        public JsonDataHandler(string filePath)
        {
            FilePath = filePath;
        }

        public List<City> LoadData()
        {
            var json = File.ReadAllText(FilePath);
            var data = JsonConvert.DeserializeObject<JsonCityData>(json);

            var cities = new List<City>();
            foreach (var city in data.Cities)
            {
                var routes = city.Connections.ConvertAll(conn =>
                    new Route(city.Name, conn.Destination, conn.Distance, conn.Time, conn.Cost, conn.TravelMethod));
                cities.Add(new City(city.Name, routes));
            }
            return cities;
        }
    }

    public class JsonCityData
    {
        public List<JsonCity> Cities { get; set; }
    }

    public class JsonCity
    {
        public string Name { get; set; }
        public List<JsonConnection> Connections { get; set; }
    }

    public class JsonConnection
    {
        public string Destination { get; set; }
        public int Distance { get; set; }
        public int Time { get; set; }
        public int Cost { get; set; }
        public string TravelMethod { get; set; }
    }
}
