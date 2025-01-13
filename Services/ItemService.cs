using Microsoft.EntityFrameworkCore;
using ReviewApp.Entities;
using ReviewApp.ViewModels;

namespace ReviewApp.Services {
    public class ItemService {
        private readonly AppDbContext _context;

        public ItemService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<ItemEntity>> SearchItemsAsync(AddReviewSearchItemViewModel viewModel)
        {
            return await _context.Items.Where(x => x.Title.ToUpper().Contains(viewModel.SearchString.ToUpper())).ToListAsync();
        }

        public async Task<ItemEntity> GetItemAsync(Guid itemId)
        {
            return await _context.Items.FirstAsync(x => x.Id == itemId);
        }
    }
}
