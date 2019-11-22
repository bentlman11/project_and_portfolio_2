using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using MySql.Data.MySqlClient;

namespace DataConvsersion
{
    class ConvertJSON
    {
        //NEEDS to have a Dictionary of Int(entry number) and List<string> for reader's entry
        public static void ConvertSQL()
        {
            // MySQL Database Connection String
            string cs = @"server=192.168.201.1;userid=dbremoteuser;password=password;database=samplerestaurantdatabase;port=8889";
            // Declare a MySQL Connection
            MySqlConnection conn = null;

            //Database Location
            //string cs = @"server= 127.0.0.1;userid=root;password=root;database=SampleRestaurantDatabase;port=8889";
            //Output Location
            //string outputFolder = @"../../output/";﻿﻿

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
                using (rdr = cmd.ExecuteReader())
                {

                    List<string> columnNames = new List<string>();

                    //columns
                    for (int i = 0; i < rdr.FieldCount; i++)
                    {
                        columnNames.Add(rdr.GetName(i));
                    }

                    StreamWriter outStream = new StreamWriter(outputFolder + $@"/ResterauntProfiles.JSON");

                    List<string> sqlList = new List<string>();

                    sqlList.Add($"[");

                    while (rdr.Read())
                    {
                        sqlList.Add("{");
                        sqlList.Add($"\"{columnNames[0]}\" : \"{Utility.NullChecker(rdr, 0)}\",");
                        sqlList.Add($"\"{columnNames[1]}\" : \"{Utility.NullChecker(rdr, 1)}\",");
                        sqlList.Add($"\"{columnNames[2]}\" : \"{Utility.NullChecker(rdr, 2)}\",");
                        sqlList.Add($"\"{columnNames[3]}\" : \"{Utility.NullChecker(rdr, 3)}\",");
                        sqlList.Add($"\"{columnNames[4]}\" : \"{Utility.NullChecker(rdr, 4)}\",");
                        sqlList.Add($"\"{columnNames[5]}\" : \"{Utility.NullChecker(rdr, 5)}\",");
                        sqlList.Add($"\"{columnNames[6]}\" : \"{Utility.NullChecker(rdr, 6)}\",");
                        sqlList.Add($"\"{columnNames[7]}\" : \"{Utility.NullChecker(rdr, 7)}\",");
                        sqlList.Add($"\"{columnNames[8]}\" : \"{Utility.NullChecker(rdr, 8)}\",");
                        sqlList.Add($"\"{columnNames[9]}\" : \"{Utility.NullChecker(rdr, 9)}\",");
                        sqlList.Add($"\"{columnNames[10]}\" : \"{Utility.NullChecker(rdr, 10)}\",");
                        sqlList.Add($"\"{columnNames[11]}\" : \"{Utility.NullChecker(rdr, 11)}\",");
                        sqlList.Add($"\"{columnNames[12]}\" : \"{Utility.NullChecker(rdr, 12)}\",");
                        sqlList.Add($"\"{columnNames[13]}\" : \"{Utility.NullChecker(rdr, 13)}\"");
                        sqlList.Add("},");
                    }

                    sqlList.RemoveAt(sqlList.Count - 1);
                    sqlList.Add("}");
                    sqlList.Add($"]");

                    foreach (string row in sqlList)
                    {
                        outStream.WriteLine(row);
                        outStream.Flush();
                    }


                    rdr.Dispose();
                    /////////////////////////////

                    // Form SQL Statement
                    stm = "select * from RestaurantReviewers";

                    // Prepare SQL Statement
                    cmd = new MySqlCommand(stm, conn);

                    //Execute SQL Statement
                    rdr = cmd.ExecuteReader();

                    List<string> columnNamesTwo = new List<string>();

                    //columns
                    for (int i = 0; i < rdr.FieldCount; i++)
                    {
                        columnNamesTwo.Add(rdr.GetName(i));
                    }

                    StreamWriter outStreamTwo = new StreamWriter(outputFolder + $@"/ResterauntReviewers.JSON");

                    List<string> sqlListTwo = new List<string>();

                    sqlListTwo.Add($"[");

                    while (rdr.Read())
                    {
                        sqlListTwo.Add("{");
                        sqlListTwo.Add($"\"{columnNamesTwo[0]}\" : \"{Utility.NullChecker(rdr, 0)}\",");
                        sqlListTwo.Add($"\"{columnNamesTwo[1]}\" : \"{Utility.NullChecker(rdr, 1)}\",");
                        sqlListTwo.Add($"\"{columnNamesTwo[2]}\" : \"{Utility.NullChecker(rdr, 2)}\",");
                        sqlListTwo.Add($"\"{columnNamesTwo[3]}\" : \"{Utility.NullChecker(rdr, 3)}\",");
                        sqlListTwo.Add($"\"{columnNamesTwo[4]}\" : \"{Utility.NullChecker(rdr, 4)}\",");
                        sqlListTwo.Add($"\"{columnNamesTwo[5]}\" : \"{Utility.NullChecker(rdr, 5)}\",");
                        sqlListTwo.Add($"\"{columnNamesTwo[6]}\" : \"{Utility.NullChecker(rdr, 6)}\",");
                        sqlListTwo.Add($"\"{columnNamesTwo[7]}\" : \"{Utility.NullChecker(rdr, 7)}\"");

                        sqlListTwo.Add("},");
                    }

                    sqlListTwo.RemoveAt(sqlListTwo.Count - 1);
                    sqlListTwo.Add("}");
                    sqlListTwo.Add($"]");

                    foreach (string row in sqlListTwo)
                    {
                        outStreamTwo.WriteLine(row);
                        outStreamTwo.Flush();
                    }
                    rdr.Dispose();
                    /////////////////////////////

                    // Form SQL Statement
                    stm = "select * from RestaurantReviews";

                    // Prepare SQL Statement
                    cmd = new MySqlCommand(stm, conn);

                    //Execute SQL Statement
                    rdr = cmd.ExecuteReader();

                    List<string> columnNamesThree = new List<string>();

                    //columns
                    for (int i = 0; i < rdr.FieldCount; i++)
                    {
                        columnNamesThree.Add(rdr.GetName(i));
                    }

                    StreamWriter outStreamThree = new StreamWriter(outputFolder + $@"/ResterauntReviews.JSON");

                    List<string> sqlListThree = new List<string>();

                    sqlListThree.Add($"[");

                    while (rdr.Read())
                    {
                        sqlListThree.Add("{");
                        sqlListThree.Add($"\"{columnNamesThree[0]}\" : \"{Utility.NullChecker(rdr, 0)}\",");
                        sqlListThree.Add($"\"{columnNamesThree[1]}\" : \"{Utility.NullChecker(rdr, 1)}\",");
                        sqlListThree.Add($"\"{columnNamesThree[2]}\" : \"{Utility.NullChecker(rdr, 2)}\",");
                        sqlListThree.Add($"\"{columnNamesThree[3]}\" : \"{Utility.NullChecker(rdr, 3)}\",");
                        sqlListThree.Add($"\"{columnNamesThree[4]}\" : \"{Utility.NullChecker(rdr, 4)}\",");
                        sqlListThree.Add($"\"{columnNamesThree[5]}\" : \"{Utility.NullChecker(rdr, 5)}\"");

                        sqlListThree.Add("},");
                    }

                    sqlListThree.RemoveAt(sqlListThree.Count - 1);
                    sqlListThree.Add("}");
                    sqlListThree.Add($"]");

                    foreach (string row in sqlListThree)
                    {
                        outStreamThree.WriteLine(row);
                        outStreamThree.Flush();
                    }

                    outStreamThree.Close();
                    outStreamTwo.Close();
                    outStream.Close();
                }
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

            
            ConvertToJSON(outputFolder);
        }
        
        private static void ConvertToJSON(string output)
        {
            Console.WriteLine("SQL tables Converted to JSON");
            Console.WriteLine($"JSON files are at: {Path.GetFullPath(output)}");
            Console.WriteLine("");
            Utility.WaitForKey("Press Enter to return to Main Menu...");

            Console.Clear();
        }

        
       
    }
}
