using Solution.Domain.Services.Abstractions;

namespace Solution.App.WPF.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        public PostListingsViewModel PostListingsViewModel { get; }

        public HomeViewModel(IPostService postService)
        {
            PostListingsViewModel = new PostListingsViewModel(postService);
        }
    }
}
