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

            Console.WriteLine("Hello Admin, What Would You Like To Do Today?");

            while (programIsRunning)
            {
                _instance.MainMenu();

                int selection = Validation.GetInt(0,1,"Please enter your selection number: ");

                switch (selection)
                {
                    case 1:
                        {
                            ConvertJSON.ConnectToSQL();
                        }
                        break;
                    case 0:
                        {
                            programIsRunning = false;
                        }
                        break;
                }

                
            }

            Console.WriteLine("");
            Console.WriteLine("Goodbye Admin. ");
            Utility.WaitForKey("Press any key to exit...");
        }

        private void MainMenu()
        {
            Console.WriteLine("");
            Console.WriteLine("1. Convert The Restaurant Profile Table From SQL To JSON");
            Console.WriteLine("2. Showcase Our 5 Star Rating System");
            Console.WriteLine("3. Showcase Our Animated Bar Graph Review System");
            Console.WriteLine("4. Play A Card Game");
            Console.WriteLine("5. Exit");
            Console.WriteLine("");
        }

       
    }
}
