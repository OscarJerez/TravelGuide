namespace TravelGuide
{
    public class TripResult
    {
        public List<Route> Routes { get; set; }
        public int TotalDistance { get; set; }
        public int TotalTime { get; set; }
        public int TotalCost { get; set; }

        public TripResult(List<Route> routes, int totalDistance, int totalTime, int totalCost)
        {
            Routes = routes;
            TotalDistance = totalDistance;
            TotalTime = totalTime;
            TotalCost = totalCost;
        }

        public string Summarize()
        {
            return $"Total Distance: {TotalDistance} km\n" +
                   $"Total Time: {TotalTime} mins\n" +
                   $"Total Cost: {TotalCost} currency\n";
        }
    }
}
