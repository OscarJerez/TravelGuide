namespace TravelGuide
{
    public class UserPreferences
    {
        public string Priority { get; set; } // Options: "time", "cost", "distance"
        public int Budget { get; set; }

        public UserPreferences(string priority, int budget)
        {
            Priority = priority;
            Budget = budget;
        }
    }

}