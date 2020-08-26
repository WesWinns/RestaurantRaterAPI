using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RestaurantRaterAPI.Models
{
    public class Rating
    {
        // Primary Key
        [Key]
        public int Id { get; set; }

        // Foreign Key (Restaurant Key)
        [ForeignKey(nameof(Restaurant))]  // ctrl + r r will change all names not just one.
        public int RestaurantId { get; set; }
        
        // ForeignKey Navigation Property
        public virtual Restaurant Restaurant { get; set; }
        
        [Required]
        [Range(0, 10)]
        public double FoodScore { get; set; }

        [Required, Range(0, 10)]
        public double EnvironmentScore { get; set; }

        [Required]
        [Range(0, 10)]
        public double CleanlinessScore { get; set; }

        // Add all scores and get the average out of 10
        public double AverageRating
        {
            get
            {
                var totalScore = FoodScore + EnvironmentScore + CleanlinessScore;
                return totalScore / 3;
            }
        }
    }
}