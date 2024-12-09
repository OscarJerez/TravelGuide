using System.Collections.Generic;
using TravelGuide;

public class TripPlanner
{
    public UserPreferences Preferences { get; set; }
    public List<City> Cities { get; set; }
    public TripResult Result { get; private set; }

    public TripPlanner(List<City> cities, UserPreferences preferences)
    {
        Cities = cities;
        Preferences = preferences;
    }

    public void PlanTrip(List<string> destinations)
    {
        var optimizer = new RouteOptimizer(Cities);
        Result = optimizer.OptimizeRoutes(destinations, Preferences);
    }

    public string GenerateItinerary()
    {
        return Result != null ? Result.Summarize() : "No trip planned.";
    }
}
