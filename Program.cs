using System;
using System.Collections.Generic;
using TravelGuide;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Ladda data från JSON-fil
            var jsonHandler = new JsonDataHandler("JsonData.json");
            List<TravelGuide.City> cities = jsonHandler.LoadData();  // Använd fullständigt namn för TravelGuide.City

            // Skapa användarens preferenser
            UserPreferences preferences = new UserPreferences("cost", 5000);

            // Skapa TripPlanner
            TripPlanner planner = new TripPlanner(cities, preferences);

            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("\n--- Resassistent ---");
                Console.WriteLine("1. Visa alla städer");
                Console.WriteLine("2. Planera en resa");
                Console.WriteLine("3. Ändra preferenser");
                Console.WriteLine("4. Visa resväg");
                Console.WriteLine("5. Avsluta");
                Console.Write("Välj ett alternativ: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        DisplayCities(cities);
                        break;
                    case "2":
                        PlanTrip(planner);
                        break;
                    case "3":
                        ChangePreferences(preferences);
                        break;
                    case "4":
                        DisplayItinerary(planner);
                        break;
                    case "5":
                        Console.WriteLine("Avslutar programmet...");
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Ogiltigt val. Försök igen.");
                        break;
                }
            }
        }
        catch (Exception ex)
        {
            ErrorHandler.HandleError(ex);
        }
    }

    static void DisplayCities(List<TravelGuide.City> cities) // Använd TravelGuide.City här också
    {
        Console.WriteLine("\nTillgängliga städer:");
        foreach (var city in cities)
        {
            Console.WriteLine($"- {city.Name}");
        }
    }

    static void PlanTrip(TripPlanner planner)
    {
        try
        {
            var destinations = UserInteraction.GetUserInput();
            foreach (var destination in destinations)
            {
                if (!ValidationService.ValidateCity(destination, planner.Cities))
                {
                    Console.WriteLine($"Staden {destination} finns inte i systemet.");
                    return;
                }
            }

            planner.PlanTrip(destinations);
            Console.WriteLine("Resan är planerad!");
        }
        catch (Exception ex)
        {
            ErrorHandler.HandleError(ex);
        }
    }

    static void ChangePreferences(UserPreferences preferences)
    {
        Console.WriteLine("\nAnge nya preferenser:");
        Console.WriteLine("1. Tid");
        Console.WriteLine("2. Kostnad");
        Console.WriteLine("3. Avstånd");
        Console.Write("Välj prioritet: ");
        string priorityChoice = Console.ReadLine();

        string priority = priorityChoice switch
        {
            "1" => "time",
            "2" => "cost",
            "3" => "distance",
            _ => "cost"
        };

        Console.Write("Ange budget: ");
        if (int.TryParse(Console.ReadLine(), out int budget))
        {
            preferences.Priority = priority;
            preferences.Budget = budget;
            Console.WriteLine("Preferenser uppdaterade!");
        }
        else
        {
            Console.WriteLine("Ogiltig budget. Förändring avbruten.");
        }
    }

    static void DisplayItinerary(TripPlanner planner)
    {
        string itinerary = planner.GenerateItinerary();
        Console.WriteLine("\nResväg:");
        Console.WriteLine(itinerary);
    }
}
