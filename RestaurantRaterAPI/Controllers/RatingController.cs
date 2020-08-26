using RestaurantRaterAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace RestaurantRaterAPI.Controllers
{
    public class RatingController : ApiController
    {
        private readonly RestaurantDbContext _context = new RestaurantDbContext();
        
        // Create new ratings
        [HttpPost]
        public async Task<IHttpActionResult> CreateRating(Rating model)
        {
            // Check to see if the model is NOT valid
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
                
            // Find the targeted restaurant
            var restaurant = await _context.Restaurants.FindAsync(model.RestaurantId);
            if(restaurant == null)
            {
                return BadRequest($"The target restaurant with the ID of {model.RestaurantId} does not exist.");
            }

            // The restaurant isn't null, so we can successfully rate it
            _context.Ratings.Add(model);
            if(await _context.SaveChangesAsync() == 1)
            {
                return Ok($"You rated {restaurant.Name} successfully!");
            }

            return InternalServerError();
        }

        // Get a rating by its ID ?

        // Get ALL Ratings for a specific restaurant y the restaurant ID

        // Update Rating

        // Delete Rating
    }
}
