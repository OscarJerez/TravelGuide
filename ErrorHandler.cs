﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelGuide
{
    public class ErrorHandler
    {
        public static void HandleError(Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
