using ReviewApp.Entities;

namespace ReviewApp.ViewModels {
    public class SearchUsersViewModel {
        public string SearchString { get; set; } = null!;

        public List<UserEntity>? SearchHits { get; set; }
    }
}
