using Microsoft.AspNetCore.Identity;

namespace ReviewApp.Entities {
    public class UserEntity : IdentityUser {
        public ICollection<ReviewEntity> Reviews { get; } = new HashSet<ReviewEntity>();
    }
}
