using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
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

            //Database Location
            //string cs = @"server= 127.0.0.1;userid=root;password=root;database=SampleRestaurantDatabase;port=8889";
            //Output Location
            //string _directory = @"../../output/";﻿﻿

            string outputFolder = @"../../Output/";
            Directory.CreateDirectory(outputFolder);
            

            try
            {
                // Open a connection to MySQL 
                conn = new MySqlConnection(cs);
                conn.Open();

                // Declair MySqlDataReader
                MySqlDataReader rdr = null;

                // Form SQL Statement
                string stm = "select * from restaurantprofiles";

                // Prepare SQL Statement
                MySqlCommand cmd = new MySqlCommand(stm, conn);

                //Execute SQL Statement
                rdr = cmd.ExecuteReader();
                // Execute SQL Statement and Convert Results to a String
                List<string> columnNames = new List<string>();

                for (int i = 0; i < rdr.FieldCount; i++)
                {
                    columnNames.Add(rdr.GetName(i));
                }

                StreamWriter outStream = new StreamWriter(outputFolder + $@"/ResterauntProfiles.txt");
                
                    outStream.WriteLine($"[");
                    
                    while (rdr.Read())
                    {
                    outStream.WriteLine("{");
                    outStream.WriteLine($"\"{columnNames[0]}\" : {NullChecker(rdr, 0)},");
                    outStream.WriteLine($"\"{columnNames[1]}\" : {NullChecker(rdr, 1)},");
                    outStream.WriteLine($"\"{columnNames[2]}\" : {NullChecker(rdr, 2)},");
                    outStream.WriteLine($"\"{columnNames[3]}\" : {NullChecker(rdr, 3)},");
                    outStream.WriteLine($"\"{columnNames[4]}\" : {NullChecker(rdr, 4)},");
                    outStream.WriteLine($"\"{columnNames[5]}\" : {NullChecker(rdr, 5)},");
                    outStream.WriteLine($"\"{columnNames[6]}\" : {NullChecker(rdr, 6)},");
                    outStream.WriteLine($"\"{columnNames[7]}\" : {NullChecker(rdr, 7)},");
                    outStream.WriteLine($"\"{columnNames[8]}\" : {NullChecker(rdr, 8)},");
                    outStream.WriteLine($"\"{columnNames[9]}\" : {NullChecker(rdr, 9)},");
                    outStream.WriteLine($"\"{columnNames[10]}\" : {NullChecker(rdr, 10)},");
                    outStream.WriteLine($"\"{columnNames[11]}\" : {NullChecker(rdr, 11)},");
                    outStream.WriteLine($"\"{columnNames[12]}\" : {NullChecker(rdr, 12)},");
                    outStream.WriteLine($"\"{columnNames[13]}\" : {NullChecker(rdr, 13)},");
                    outStream.WriteLine("},");
                    }

                    outStream.WriteLine($"]");
                
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
            Console.WriteLine(Path.GetFullPath(outputFolder));
            Console.ReadKey();
        }

        
        public static void ConvertToJSON()
        {
            Console.WriteLine("Converted");

            Utility.WaitForKey("Press Enter to return to Main Menu...");
        }

        public static string NullChecker(MySqlDataReader rdr, int columnNumber)
        {
            if(!rdr.IsDBNull(columnNumber))
            {
                return rdr.GetString(columnNumber);
            }
            return "null";
        }
       
    }
}
