using System;
using System.Collections.Generic;
using System.Text;

namespace DataConvsersion
{
    class Validation
    {
        public static int GetInt(int min, int max, string message = "Enter your selection: ")
        {
            int valInt = 0;
            string valString = null;

            do
            {
                Console.WriteLine(message);
                valString = Console.ReadLine();
            }
            while (!Int32.TryParse(valString, out valInt) && (valInt >= min && valInt <= max));

            return valInt;
        }
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
