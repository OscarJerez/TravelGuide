namespace TravelGuide
{
    public class TransportMode
    {
        public string Type { get; set; }
        public double CostPerKm { get; set; }
        public double Speed { get; set; }

        public TransportMode(string type, double costPerKm, double speed)
        {
            Type = type;
            CostPerKm = costPerKm;
            Speed = speed;
        }

        public double CalculateTravelTime(double distance)
        {
            return distance / Speed;
        }
        public double CalculateTravelCost(double distance)
        {
            return distance * CostPerKm;
        } 
    }
}