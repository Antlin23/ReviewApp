namespace ReviewApp.Entities {
    public class ItemEntity {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Title { get; set; } = null!;

        public ICollection<ReviewEntity> Reviews { get; } = new HashSet<ReviewEntity>();
    }
}
