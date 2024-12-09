using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelGuide
{
    public class RouteOptimizer
    {
        private List<City> Cities;

        public RouteOptimizer(List<City> cities)
        {
            Cities = cities;
        }

        public TripResult OptimizeRoutes(List<string> destinations, UserPreferences preferences)
        {
            var selectedRoutes = new List<Route>();
            int totalDistance = 0, totalTime = 0, totalCost = 0;

            for (int i = 0; i < destinations.Count - 1; i++)
            {
                var startCity = Cities.FirstOrDefault(c => c.Name == destinations[i]);
                var nextCity = destinations[i + 1];
                var route = startCity?.GetConnections().FirstOrDefault(r => r.EndCity == nextCity);

                if (route != null)
                {
                    selectedRoutes.Add(route);
                    totalDistance += route.Distance;
                    totalTime += route.Time;
                    totalCost += route.Cost;
                }
            }

            return new TripResult(selectedRoutes, totalDistance, totalTime, totalCost);
        }
    }
}
