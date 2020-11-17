using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Solution.Domain.Models;

namespace Solution.Domain.Services.Abstractions
{
    public interface IPostService
    {
        Task<IEnumerable<Post>> GetPosts(int top, CancellationToken cancellationToken = default);
    }
}
