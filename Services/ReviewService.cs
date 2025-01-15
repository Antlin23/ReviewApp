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

        public async Task<IEnumerable<ReviewEntity>> GetUserReviewsAsync(string userId)
        {
            return await _context.Reviews.Where(x => x.UserId == userId).ToListAsync();
        }

        public async Task<IEnumerable<ReviewEntity>> GetItemReviewsAsync(Guid itemId)
        {
            return await _context.Reviews.Where(x => x.ItemId == itemId).ToListAsync();
        }

        public async Task RemoveReviewAsync(Guid reviewId)
        {
            _context.Reviews.Remove(await _context.Reviews.FirstAsync(x => x.Id == reviewId));
            await _context.SaveChangesAsync();
        }
    }
}
