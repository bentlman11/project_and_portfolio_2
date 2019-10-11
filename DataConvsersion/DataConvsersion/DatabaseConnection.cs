using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using MySql.Data.MySqlClient;

namespace DataConvsersion
{
    class DatabaseConnection
    {
        private MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;

        //private static DatabaseConnection _instance = new DatabaseConnection();

        public DatabaseConnection()
        {
            Initialize();
        }

        //Initialize values
        private void Initialize()
        {
            // MySQL Database Connection String
            string cs = @"server=192.168.201.1;userid=dbremoteuser;password=password;database=samplerestaurantdatabase;port=8889";

            //string cs = @"server= 127.0.0.1;userid=root;password=root;database=SampleRestaurantDatabase;port=8889";
            //Output Location
            //string outputFolder = @"../../output/";﻿﻿

            connection = new MySqlConnection(cs);
        }

        //open connection to database
        private bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {

                switch (ex.Number)
                {
                    case 0:
                        Console.WriteLine("Cannot connect to server.  Contact administrator");
                        break;

                    case 1045:
                        Console.WriteLine("Invalid username/password, please try again");
                        break;
                }
                return false;
            }
        }

        //Close connection
        private bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        //Select statement
        public void SelectReviews(int sortStyle, double viewLimit) 
        {
            OpenConnection();

            MySqlDataReader rdr = null;

            // Prepare SQL Statement
            //string stm = "select restaurantName, reviewScore from restaurantProfiles inner join restaurantReviews on restaurantProfiles.id = restaurantReviews.restaurantId";

            string stm = "select restaurantName, overallRating from restaurantProfiles";

            MySqlCommand cmd = new MySqlCommand(stm, connection);

            //Execute SQL Statement
            using (rdr = cmd.ExecuteReader())
            {
                Dictionary<string, Restaurant> restaurantDic = new Dictionary<string, Restaurant>();

                while (rdr.Read())
                {
                    Restaurant restaurant = new Restaurant(Utility.NullChecker(rdr, 0), Utility.NullCheckerInt(rdr, 1));

                    //restaurant.Ratings.Add(Utility.NullCheckerInt(rdr, 1));

                    restaurantDic.Add(restaurant.Name, restaurant);
                    // Restaurant temp;

                    // if (restaurantDic.TryGetValue(restaurant.Name, out temp))
                    // {
                    //     temp.Ratings.Add(restaurant.Rating);
                    // }
                    // else
                    // {
                    //    restaurantDic.Add(restaurant.Name, restaurant);
                    // }
                }


                //Uses actual reviews from RestaurantReviews table
                //double finalRating;

                List<Restaurant> restaurantList = new List<Restaurant>();

                foreach (KeyValuePair<string, Restaurant> entry in restaurantDic)
                {
                    restaurantList.Add(entry.Value);

                    //finalRating = entry.Value.GetFinalRating(); Averages multiples, dont need it here yet.

                    //Console.WriteLine($"{entry.Key} , {entry.Value.Rating.ToString("0.00")} , {StarCreator.StarCreation(entry.Value.Rating)}.");
                }

                switch (sortStyle)
                {
                    case 1:
                        {
                            Console.Clear();
                            restaurantList.Sort((x, y) => string.Compare(x.Name, y.Name));
                        }
                        break;
                    case 2:
                        {
                            Console.Clear();
                            restaurantList.Sort((x, y) => string.Compare(y.Name, x.Name));
                        }
                        break;
                    case 3:
                        {
                            Console.Clear();
                            restaurantList.Sort(Restaurant.SortRatingDescending());
                        }
                        break;
                    case 4:
                        {
                            Console.Clear();
                            restaurantList.Sort(Restaurant.SortRatingAscending());
                        }
                        break;
                }

                
                foreach (Restaurant entry in restaurantList)
                {
                    if(entry.Rating >= viewLimit)
                    {
                        string tName = entry.Name; string tStars = StarCreator.StarCreation(entry.Rating);
                        Console.Write($"\r\n {tName.PadRight(40, '-')} ");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write($"{tStars} ");//Write and color change insine StarCreator.
                        Console.ResetColor();
                        Console.WriteLine("");
                    }
                    
                }

                CloseConnection();
            }
        }
    }
}
