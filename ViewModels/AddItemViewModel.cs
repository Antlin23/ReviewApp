using ReviewApp.Entities;

namespace ReviewApp.ViewModels {
    public class AddItemViewModel {
        public string Title { get; set; } = null!;

        public static implicit operator ItemEntity(AddItemViewModel viewModel)
        {
            return new ItemEntity
            {
                Title = viewModel.Title,
            };
        }
    }
}
