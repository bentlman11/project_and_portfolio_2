using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataConvsersion
{
    class Restaurant : IComparer<Restaurant> 
    { 
        private string _name;
        private double _rating;
        private double _finalRating;
        private List<double> _ratings = new List<double>();


        public string Name { get { return _name; } }
        public double FinalRating { get { return _finalRating; } set { _finalRating = value; } }
        public double Rating { get { return _rating; } }
        public List<double> Ratings { get { return _ratings; } set { _ratings = value; } }

        public Restaurant(string name, double rating)
        {
            _name = name; _rating = rating;
        }

        public double GetFinalRating()
        {
            _finalRating = _ratings.Average() / 20;
            _finalRating = Math.Round(_finalRating, 0, MidpointRounding.AwayFromZero);

            return _finalRating;
        }

        //Helpers
        
        public static IComparer<Restaurant> SortRatingAscending()
        {
            return new SortRatingAscendingHelper();
        }
        public static IComparer<Restaurant> SortRatingDescending()
        {
            return new SortRatingDescendingHelper();
        }

        //Default Comparer Function
        int IComparer<Restaurant>.Compare(Restaurant a, Restaurant b)
        {
            Restaurant r1 = a;
            Restaurant r2 = b;

            if (r1.Rating > r2.Rating)
                return 1;

            if (r1.Rating < r2.Rating)
                return -1;

            else
                return 0;
        }
    }

    
    public class SortRatingAscendingHelper : IComparer<Restaurant>
    {
        int IComparer<Restaurant>.Compare(Restaurant a, Restaurant b)
        {
            Restaurant r1 = a;
            Restaurant r2 = b;

            if (r1.Rating > r2.Rating)
                return 1;

            if (r1.Rating < r2.Rating)
                return -1;

            else
                return 0;
        }
    }

    public class SortRatingDescendingHelper : IComparer<Restaurant>
    {
        int IComparer<Restaurant>.Compare(Restaurant a, Restaurant b)
        {
            Restaurant r1 = a;
            Restaurant r2 = b;

            if (r1.Rating < r2.Rating)
                return 1;

            if (r1.Rating > r2.Rating)
                return -1;

            else
                return 0;
        }
    
    }
}
    

   


