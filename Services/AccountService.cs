using Microsoft.EntityFrameworkCore;
using ReviewApp.Entities;
using ReviewApp.ViewModels;

namespace ReviewApp.Services {
    public class AccountService {
        private readonly AppDbContext _context;

        public AccountService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<UserEntity>> SearchUsersAsync(SearchUsersViewModel viewModel)
        {
            return await _context.Users.Where(x => x.UserName.ToUpper().Contains(viewModel.SearchString.ToUpper())).ToListAsync();
        }
    }
}
