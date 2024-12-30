using ReviewApp.Entities;

namespace ReviewApp.ViewModels {
    public class AddReviewViewModel {
        public Guid ItemId { get; set; }

        public int Rating { get; set; }
        public string? Comment { get; set; }
    }
}
