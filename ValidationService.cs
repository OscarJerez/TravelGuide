public class ValidationService
{
    public static bool ValidateCity(string cityName, List<City> cities)
    {
        return cities.Exists(c => c.Name == cityName);
    }
}