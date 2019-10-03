using System;
using System.Collections.Generic;
using System.Text;
using MySql;
using MySql.Data.MySqlClient;

namespace DataConvsersion
{
    class ConvertJSON
    {

        public static void ConnectToSQL()
        {
            // MySQL Database Connection String
            string cs = @"server=192.168.201.1;userid=dbremoteuser;password=password;database=samplerestaurantdatabase;port=8889";
            // Declare a MySQL Connection
            MySqlConnection conn = null;

            try
            {

                // Open a connection to MySQL 
                conn = new MySqlConnection(cs);
                conn.Open();

                // Declair MySqlDataReader
                MySqlDataReader rdr = null;

                // Form SQL Statement
                string stm = "select restaurantName from restaurantprofiles";

                // Prepare SQL Statement
                MySqlCommand cmd = new MySqlCommand(stm, conn);

                //Execute SQL Statement
                rdr = cmd.ExecuteReader();
                // Execute SQL Statement and Convert Results to a String
                // -string version = Convert.ToString(cmd.ExecuteScalar());

                //Loop Through rows returned from mysql
                while (rdr.Read())
                {
                    //output the first 3 columns returned
                    Console.WriteLine(rdr.GetString(0));
                }
                // Output Results
                //Console.WriteLine("MySQL version : {0}", version);

            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error: {0}", ex.ToString());
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
            Console.WriteLine("Done");
            Console.ReadKey();
        }

        public static void ConvertToJSON()
        {
            Console.WriteLine("Converted");

            Utility.WaitForKey("Press Enter to return to Main Menu...");
        }
       
    }
}
