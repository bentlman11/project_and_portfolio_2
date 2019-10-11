using System;
using System.Collections.Generic;
using System.Text;

namespace DataConvsersion
{
    class StarCreator
    {
        //Color_red
        //_green
        //_blue

        private static string[] _stars = new string[] { "", "*", "**", "***", "****", "*****" };

        public static string StarCreation(double rating)
        {
            int starCount = Convert.ToInt32(rating);
            return _stars[starCount];
        }
    }
}
