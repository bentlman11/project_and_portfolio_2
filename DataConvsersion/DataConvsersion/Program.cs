using System;

namespace DataConvsersion
{
    class Program
    {
        private static Program _instance;

        static void Main(string[] args)
        {
            //Database Location
            //string cs = @"server= 127.0.0.1;userid=root;password=root;database=SampleRestaurantDatabase;port=8889";
            //Output Location
            //string _directory = @"../../output/";﻿﻿

            _instance = new Program();

            bool programIsRunning = true;

            while(programIsRunning)
            {
                _instance.MainMenu();

                string selection = Validation.GetString("Please enter your selection: ").ToLower();
            }
            
        }

        private void MainMenu()
        {
            Console.Clear();

            Console.WriteLine("Hello Admin, What Would You Like To Do Today?");
            Console.WriteLine("");
            Console.WriteLine("1. Convert The Restaurant Profile Table From SQL To JSON");
            Console.WriteLine("2. Showcase Our 5 Star Rating System");
            Console.WriteLine("3. Showcase Our Animated Bar Graph Review System");
            Console.WriteLine("4. Play A Card Game");
            Console.WriteLine("5. Exit");
            Console.WriteLine("");

        }

        private void WaitForKey()
        {
            Console.WriteLine("Press Enter To Continue");
        }
    }
}
