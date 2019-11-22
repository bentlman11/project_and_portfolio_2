using System;
using System.Collections.Generic;


namespace DataConvsersion
{
    class Program
    {
        private static Program _instance;
        private static List<Restaurant> restaurants = new List<Restaurant>();
        private static DatabaseConnection DBconnection = new DatabaseConnection();

        static void Main(string[] args)
        {
            
            _instance = new Program();
            
            bool programIsRunning = true;

            Console.WriteLine("Hello Admin, What Would You Like To Do Today?");
            
            while (programIsRunning)
            {
                _instance.MainMenu();

                int selection = Validation.GetInt(0,2,"Please enter your selection number: ");

                switch (selection)
                {
                    case 1:
                        {
                            ConvertJSON.ConvertSQL();
                        }
                        break;
                    case 2:
                        {
                            _instance.RatingSystemMenu();
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
            Console.WriteLine("0. Exit");
            Console.WriteLine("");
        }

        private void RatingSystemMenu()
        {
            bool isRatingMenu = true;

            while(isRatingMenu)
            {
                //Connect to sql
                //n get username
                
                Console.WriteLine("");//HELLO <USER>
                Console.WriteLine("1. List Restaurants Alphabetically.");//show rating next to name
                Console.WriteLine("2. List Restaurants in Reverse Alphabetical.");
                Console.WriteLine("3. Sort Restaurants from Best to worst.");
                Console.WriteLine("4. Sort Restaurants from Worst to best.");
                Console.WriteLine("5. Show only X and up.");
                Console.WriteLine("0. Back");
                Console.WriteLine("");

                int selection = Validation.GetInt(0, 5, "Please enter your selection number: ");

                switch (selection)
                {
                    case 1:
                        {
                            //1. List Restaurants Alphabetically.");//show rating next to name
                            DBconnection.SelectReviews(1, 5);
                        }
                        break;
                    case 2:
                        {
                            //"2. List Restaurants in Reverse Alphabetical."
                            DBconnection.SelectReviews(2,5);
                        }
                        break;
                    case 3:
                        {
                            //"3. Sort Restaurants from Best to worst.
                            DBconnection.SelectReviews(3,5);
                        }
                        break;
                    case 4:
                        {
                            //"4. Sort Restaurants from Worst to best."
                            DBconnection.SelectReviews(4,5);
                        }
                        break;
                    case 5:
                        {
                            RatingSystemByStarsMenu();
                        }
                        break;
                    case 0:
                        {
                            isRatingMenu = false;
                        }
                        break;
                }
            }
            
        }

        private void RatingSystemByStarsMenu()
        {
            bool isRatingByStarsMenu = true;

            while (isRatingByStarsMenu)
            {
                Console.WriteLine("");
                Console.WriteLine("1. Show the best (5 Stars) ");
                Console.WriteLine("2. Show 4 Stars and above. ");
                Console.WriteLine("3. Show 3 Stars and above. ");
                Console.WriteLine("4. Show the Worst (1 Stars). ");
                Console.WriteLine("5. Show Unrated. ");
                Console.WriteLine("0. Back.");
                Console.WriteLine("");

                int selection = Validation.GetInt(0, 5, "Please enter your selection number: ");
                
                switch (selection)
                {
                    case 1:
                        {
                            //1. List Restaurants Alphabetically.");//show rating next to name
                            DBconnection.SelectReviews(1, 0);
                        }
                        break;
                    case 2:
                        {
                            //"2. List Restaurants in Reverse Alphabetical."
                            DBconnection.SelectReviews(2, 0);
                        }
                        break;
                    case 3:
                        {
                            //"3. Sort Restaurants from Best to worst.
                            DBconnection.SelectReviews(3, 0);
                        }
                        break;
                    case 4:
                        {
                            //"4. Sort Restaurants from Worst to best."
                            DBconnection.SelectReviews(4, 0);
                        }
                        break;
                    case 5:
                        {
                            RatingSystemByStarsMenu();
                        }
                        break;
                    case 0:
                        {
                            isRatingByStarsMenu = false;
                            RatingSystemMenu();
                        }
                        break;
                }
            }
        }
    }
}
