namespace ReviewApp.Entities {
    public class ReviewEntity {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string UserId { get; set; } = null!;
        public UserEntity User { get; set; } = null!;

        public Guid ItemId { get; set; }
        public ItemEntity Item { get; set; } = null!;

        public int Rating { get; set; }
        public string? Comment { get; set; }
    }
}
