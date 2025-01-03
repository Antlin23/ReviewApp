using ReviewApp.Entities;

namespace ReviewApp.ViewModels {
    public class AddReviewSearchItemViewModel {
        public string SearchString { get; set; } = null!;
        public List<ItemEntity>? SearchHits { get; set; }
    }
}
