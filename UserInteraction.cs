using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelGuide
{
    public class UserInteraction
    {
        public static List<string> GetUserInput()
        {
            Console.WriteLine("Enter cities to visit (comma-separated):");
            var input = Console.ReadLine();
            return input.Split(',').Select(c => c.Trim()).ToList();
        }

        public static void DisplayResults(TripResult result)
        {
            Console.WriteLine(result.Summarize());
        }

        public static void DisplayError(string message)
        {
            Console.WriteLine($"Error: {message}");
        }
    }
}
