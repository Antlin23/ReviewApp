using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System.Security.Claims;

namespace ReviewApp.Entities {
    public class CustomClaimsPrincipalFactory : UserClaimsPrincipalFactory<UserEntity> {
        private readonly UserManager<UserEntity> userManager;

        public CustomClaimsPrincipalFactory(UserManager<UserEntity> userManager, IOptions<IdentityOptions> optionsAccessor) : base(userManager, optionsAccessor)
        {
            this.userManager = userManager;
        }

        protected override async Task<ClaimsIdentity> GenerateClaimsAsync(UserEntity user)
        { 
            var claimsIdentity = await base.GenerateClaimsAsync(user);

            claimsIdentity.AddClaim(new Claim("Id", $"{user.Id}"));

            var roles = await userManager.GetRolesAsync(user);

            foreach (var role in roles)
            {
                claimsIdentity.AddClaim(new Claim(ClaimTypes.Role, role));
            }

            return claimsIdentity;
        }
    }
}
