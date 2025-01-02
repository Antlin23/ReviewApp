using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System.Security.Claims;

namespace ReviewApp.Entities {
    public class CustomClaimsPrincipalFactory : UserClaimsPrincipalFactory<UserEntity> {
        public CustomClaimsPrincipalFactory(UserManager<UserEntity> userManager, IOptions<IdentityOptions> optionsAccessor) : base(userManager, optionsAccessor)
        {

        }

        protected override async Task<ClaimsIdentity> GenerateClaimsAsync(UserEntity user)
        { 
            var claimsIdentity = await base.GenerateClaimsAsync(user);

            claimsIdentity.AddClaim(new Claim("Id", $"{user.Id}"));

            return claimsIdentity;
        }
    }
}
