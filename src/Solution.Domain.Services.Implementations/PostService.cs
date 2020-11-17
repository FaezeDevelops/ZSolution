using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Solution.Domain.Models;
using Solution.Domain.Services.Abstractions;
using Solution.JsonPlaceHolder.API.Client;
using Solution.JsonPlaceHolder.API.Client.Models;

namespace Solution.Domain.Services.Implementations
{
    public class PostService : IPostService
    {
        private readonly IJsonPlaceHolderClient _apiClient;

        public PostService(IJsonPlaceHolderClient jsonPlaceHolderClient)
        {
            _apiClient = jsonPlaceHolderClient;
        }

        public async Task<IEnumerable<Post>> GetPosts(int top, CancellationToken cancellationToken = default)
        {
            IEnumerable<PostModel> posts = await _apiClient.GetPosts(cancellationToken);

            return posts.Take(top).Select(post => new Post()
            {
                UserId = post.UserId,
                Id = post.Id,
                Title = post.Title,
                Body = post.Body
            });
        }
    }
}
