using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Solution.App.WPF.Commands;
using Solution.App.WPF.Models;
using Solution.Domain.Models;
using Solution.Domain.Services.Abstractions;

namespace Solution.App.WPF.ViewModels
{
    public class PostListingsViewModel : ViewModelBase, INotifyPropertyChanged
    {
        private IEnumerable<PostListItem> _postListItems;
        public IEnumerable<PostListItem> PostListItems
        {
            get { return _postListItems; }
            set
            {
                _postListItems = value;
                OnPropertyChanged(nameof(PostListItems));
            }
        }

        public ICommand PostListItemClickedCommand { get; set; }

        public IEnumerable<Post> PostItems { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public PostListingsViewModel(IPostService postService)
        {
            PostListItemClickedCommand = new PostListItemClickedCommand(this);
            _ = LoadPostsAsync(postService);
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private async Task LoadPostsAsync(IPostService postService)
        {
            PostItems = await postService.GetPosts(100);
            PostListItems = PostItems.Select(post
            => new PostListItem
            {
                LabelName = nameof(Post.Id),
                LabelValue = post.Id.ToString()
            });
        }
    }
}
