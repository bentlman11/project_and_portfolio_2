using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;

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

        public static string NullChecker(MySqlDataReader rdr, int columnNumber)
        {
            if (!rdr.IsDBNull(columnNumber))
            {
                return rdr.GetString(columnNumber).ToLower();
            }
            return "";
        }

        public static int NullCheckerInt(MySqlDataReader rdr, int columnNumber)
        {
            if (!rdr.IsDBNull(columnNumber))
            {
                int temp = 0;

                temp = rdr.GetInt16(columnNumber);

                return temp;
            }

            else
            {

                return 0;
            }
        }

        public static decimal NullCheckerDecimal(MySqlDataReader rdr, int columnNumber)
        {
            if (!rdr.IsDBNull(columnNumber))
            {
                decimal temp = rdr.GetDecimal(columnNumber);
                return temp;
            }

            else
            {
                return 0.0m;
            }
        }

    }
}
