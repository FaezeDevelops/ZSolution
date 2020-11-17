using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Solution.JsonPlaceHolder.API.Client.Models;

namespace Solution.JsonPlaceHolder.API.Client
{
    public interface IJsonPlaceHolderClient
    {
        Task<IEnumerable<AlbumModel>> GetAlbums(CancellationToken cancellationToken = default);
        Task<IEnumerable<CommentModel>> GetComments(CancellationToken cancellationToken = default);
        Task<IEnumerable<PhotoModel>> GetPhotos(CancellationToken cancellationToken = default);
        Task<IEnumerable<PostModel>> GetPosts(CancellationToken cancellationToken = default);
        Task<IEnumerable<TodoModel>> GetTodos(CancellationToken cancellationToken = default);
        Task<IEnumerable<UserModel>> GetUsers(CancellationToken cancellationToken = default);
    }
}