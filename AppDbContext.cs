using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ReviewApp.Entities;

namespace ReviewApp {
    public class AppDbContext : IdentityDbContext<UserEntity> {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){

        }

        public DbSet<ReviewEntity> Reviews { get; set; }
        public DbSet<ItemEntity> Items { get; set; }
        public DbSet<FollowEntity> Follows { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Id = "9493816a-8694-4b62-a009-946c82e6934a",
                    Name = "User",
                    NormalizedName = "USER",
                    ConcurrencyStamp = "29b4593c-4fce-45bc-bea4-1871a7414176"
                },
                new IdentityRole
                {
                    Id = "dafeb7af-d905-4782-9497-87bfa0355748",
                    Name = "Admin",
                    NormalizedName = "ADMIN",
                    ConcurrencyStamp = "74ac6a09-4b6b-4472-86c8-6f44f1c3967e"
                }
            );

        }
    }
}
