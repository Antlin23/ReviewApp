using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReviewApp.Entities {

    public class FollowEntity {

        public Guid Id { get; set; } = Guid.NewGuid();

        public string FollowerId { get; set; } = null!;
        public string FolloweeId { get; set; } = null!;
    }
}
