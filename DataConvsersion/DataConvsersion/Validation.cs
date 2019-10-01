using System;
using System.Collections.Generic;
using System.Text;

namespace DataConvsersion
{
    class Validation
    {
        public static string GetString(string message = "Enter your selection: ")
        {
            string valString = null;

            do
            {
                Console.WriteLine(message);
                valString = Console.ReadLine();
            }
            while (String.IsNullOrWhiteSpace(valString));

            return valString;
        }
    }
}
