using System;
using System.Collections.Generic;
using System.Text;

namespace DataConvsersion
{
    class Utility
    {
        public static void WaitForKey(string message)
        {
            Console.WriteLine("");
            Console.WriteLine(message);
            Console.ReadKey();
        }
    }
}
