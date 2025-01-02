using ReviewApp.Entities;

namespace ReviewApp.ViewModels {
    public class AddReviewViewModel {
        public Guid ItemId { get; set; }
        public string UserId { get; set; } = null!;

        public int Rating { get; set; }
        public string? Comment { get; set; }



        public static implicit operator ReviewEntity(AddReviewViewModel viewModel)
        {
            return new ReviewEntity { 
                Rating = viewModel.Rating,
                Comment = viewModel.Comment,
                ItemId = viewModel.ItemId,
                UserId = viewModel.UserId
            }; 
        }
    }
}
