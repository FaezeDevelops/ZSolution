using Solution.Domain.Services.Abstractions;

namespace Solution.App.WPF.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public HomeViewModel HomeViewModel { get; }

        public MainViewModel(IPostService postService)
        {
            HomeViewModel = new HomeViewModel(postService);
        }
    }
}
