using Microsoft.EntityFrameworkCore;
using ReviewApp.Entities;
using System.Collections;

namespace ReviewApp.Services {
    public class ReviewService {
        private readonly AppDbContext _context;

        public ReviewService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ReviewEntity>> GetUserReviewsAsync(string UserId)
        {
            var reviews = await _context.Reviews.Where(x => x.UserId == UserId).ToListAsync();

            return reviews;
        }
    }
}
