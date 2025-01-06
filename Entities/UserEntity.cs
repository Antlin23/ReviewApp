using Microsoft.AspNetCore.Identity;

namespace ReviewApp.Entities {
    public class UserEntity : IdentityUser {
        public int AmountOfFollowers { get; set; }
        public int AmountOfFollows { get; set; }

        public ICollection<ReviewEntity> Reviews { get; } = new HashSet<ReviewEntity>();
    }
}
