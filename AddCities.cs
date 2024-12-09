namespace TravelGuide
{
    public class City
    {
        public string Name { get; set; }
        public List<Route> Connections { get; set; }
        public City(string name, List<Route> connections)
        {
            Name = name;
            Connections = connections;
        }

        public List<Route> GetConnections()
        {
            return Connections;
        }
    }
}