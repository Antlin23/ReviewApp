using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ReviewApp.Entities;
using ReviewApp.ViewModels;

namespace ReviewApp.Services {
    public class AccountService {
        private readonly AppDbContext _context;
        private readonly UserManager<UserEntity> _userManager;

        public AccountService(AppDbContext context, UserManager<UserEntity> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<List<UserEntity>> SearchUsersAsync(SearchUsersViewModel viewModel)
        {
            return await _context.Users.Where(x => x.UserName.ToUpper().Contains(viewModel.SearchString.ToUpper())).ToListAsync();
        }

        public async Task FollowUserAsync(string followerId, string followeeId)
        {
            FollowEntity follow = new FollowEntity();

            follow.FollowerId = followerId;
            follow.FolloweeId = followeeId;

            //if user not already follows
            if (!_context.Follows.Any(x => x.FollowerId == followerId && x.FolloweeId == followeeId)) {
                //if the user isent following himself
                if (followerId != followeeId)
                {
                    await _context.Follows.AddAsync(follow);

                    await _context.SaveChangesAsync();
                }
            }
        }


        public async Task UnfollowUserAsync(string followerId, string followeeId)
        {
            //if user not already follows
            var follow = _context.Follows.First(x => x.FollowerId == followerId && x.FolloweeId == followeeId);

            _context.Follows.Remove(follow);

            await _context.SaveChangesAsync();            
        }




        public async Task<List<UserEntity>> GetUserFollowsAsync(string userId) {
            var follows = _context.Follows.Where(x => x.FollowerId == userId).ToList();

            var users = new List<UserEntity>();

            foreach (var follow in follows) {
                var user = await _userManager.FindByIdAsync(follow.FolloweeId);

                users.Add(user);
            }

            return users;
        }

        public async Task<List<UserEntity>> GetUserFollowersAsync(string userId)
        {
            var follows = _context.Follows.Where(x => x.FolloweeId == userId).ToList();

            var users = new List<UserEntity>();

            foreach (var follow in follows)
            {
                var user = await _userManager.FindByIdAsync(follow.FollowerId);

                users.Add(user);
            }

            return users;
        }

        public async Task<bool> UserIsFollowingUserAsync(string followerId, string followeeId)
        {
            return await _context.Follows.Where(x => x.FollowerId == followerId && x.FolloweeId == followeeId).AnyAsync();
        }
    }
}
