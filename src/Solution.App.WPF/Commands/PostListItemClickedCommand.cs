using System;
using System.Linq;
using System.Windows.Input;
using Solution.App.WPF.Models;
using Solution.App.WPF.ViewModels;
using Solution.Domain.Models;

namespace Solution.App.WPF.Commands
{
    public class PostListItemClickedCommand : ICommand
    {
        private readonly PostListingsViewModel _viewModel;

        public event EventHandler CanExecuteChanged;

        public PostListItemClickedCommand(PostListingsViewModel ViewModel)
        {
            _viewModel = ViewModel;
        }

        public bool CanExecute(object parameter) => true;

        public void Execute(object labelName)
        {
            if (labelName.ToString() == nameof(Post.Id))
            {
                _viewModel.PostListItems = _viewModel.PostItems.Select(post
                    => new PostListItem
                    {
                        LabelName = nameof(Post.UserId),
                        LabelValue = post.UserId.ToString()
                    });
            }
            else
            {
                _viewModel.PostListItems = _viewModel.PostItems.Select(post
                   => new PostListItem
                   {
                       LabelName = nameof(Post.Id),
                       LabelValue = post.Id.ToString()
                   });
            }
        }
    }
}
