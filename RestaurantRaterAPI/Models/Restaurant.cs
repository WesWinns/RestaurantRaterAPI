using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RestaurantRaterAPI.Models
{
    // Restaurant Entity (The c;ass that gets stored in the database)
    public class Restaurant
    {
        // Primary Key
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        
        public double Rating
        {
            get
            {
                //return FoodRating + EnviromentRating + CleanlinessRating / 3;

                // Calculate a total average score based on Ratings
                double totalAverageRating = 0;

                // Add all Ratings together to get total Average Rating
                foreach(var rating in Ratings)
                {
                    totalAverageRating += rating.AverageRating;
                }

                // Return Average of Total if the count is above 0
                return (Ratings.Count > 0) ? Math.Round(totalAverageRating / Ratings.Count, 2) : 0;
            }
        }

        // Average Food Rating
        public double FoodRating
        {
            get
            {
                double totalFoodRating = 0;

                foreach(var rating in Ratings)
                    totalFoodRating += rating.AverageRating;

                return Ratings.Count > 0 ? totalFoodRating / Ratings.Count : 0;
            }
        }


        // Average Environment Rating
        public double EnviromentRating
        {
            get
            {
                IEnumerable<double> scores = Ratings.Select(rating => rating.EnvironmentScore);

                double totalEnvironmentScore = scores.Sum();

                return Ratings.Count > 0 ? totalEnvironmentScore / Ratings.Count : 0;
            }
        }

        // Average Cleanliness Rating
        public double CleanlinessRating
        {
            get
            {
                var totalCleanlinessRating = Ratings.Select(r => r.CleanlinessScore).Sum();
                return Ratings.Count > 0 ? totalCleanlinessRating / Ratings.Count : 0;
            }
        }


        public bool IsRecommended                               ///=> Rating > 3.5;       Another way to write this.
        {
            get
            {
                return Rating > 8;
            }
        }

        // All of the associated Rating objects from the database
        public virtual List<Rating> Ratings { get; set; } = new List<Rating>();
    }
}