using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Solution.JsonPlaceHolder.API.Client.Exceptions;
using Solution.JsonPlaceHolder.API.Client.Models;

namespace Solution.JsonPlaceHolder.API.Client
{
    public class JsonPlaceHolderClient : IJsonPlaceHolderClient
    {
        private readonly ClientConfiguration _clientConfiguration;

        public JsonPlaceHolderClient(ClientConfiguration clientConfiguration)
        {
            if (clientConfiguration == null)
            {
                throw new ArgumentNullException(nameof(clientConfiguration));
            }

            if (clientConfiguration.BaseAddress == null)
            {
                throw new ArgumentNullException(nameof(clientConfiguration.BaseAddress));
            }

            _clientConfiguration = clientConfiguration;
        }

        public async Task<IEnumerable<PostModel>> GetPosts(CancellationToken cancellationToken = default)
            => await Get<IEnumerable<PostModel>>(_clientConfiguration.PostsEndpoint, cancellationToken);

        public async Task<IEnumerable<CommentModel>> GetComments(CancellationToken cancellationToken = default)
           => await Get<IEnumerable<CommentModel>>(_clientConfiguration.CommentsEndpoint, cancellationToken);

        public async Task<IEnumerable<AlbumModel>> GetAlbums(CancellationToken cancellationToken = default)
           => await Get<IEnumerable<AlbumModel>>(_clientConfiguration.AlbumsEndpoint, cancellationToken);

        public async Task<IEnumerable<PhotoModel>> GetPhotos(CancellationToken cancellationToken = default)
           => await Get<IEnumerable<PhotoModel>>(_clientConfiguration.PhotosEndpoint, cancellationToken);

        public async Task<IEnumerable<TodoModel>> GetTodos(CancellationToken cancellationToken = default)
            => await Get<IEnumerable<TodoModel>>(_clientConfiguration.TodosEndpoint, cancellationToken);

        public async Task<IEnumerable<UserModel>> GetUsers(CancellationToken cancellationToken = default)
            => await Get<IEnumerable<UserModel>>(_clientConfiguration.UsersEndpoint, cancellationToken);

        protected virtual HttpClient CreateHttpClient()
        {
            HttpClient httpClient = new HttpClient()
            {
                BaseAddress = _clientConfiguration.BaseAddress
            };

            if (!string.IsNullOrEmpty(_clientConfiguration.BearerToken))
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _clientConfiguration.BearerToken);
            }

            return httpClient;
        }

        private async Task<T> Get<T>(string path, CancellationToken cancellationToken = default) where T : class
        {
            T result;

            try
            {
                if (string.IsNullOrWhiteSpace(path))
                {
                    throw new ArgumentNullException(nameof(path));
                }

                using (HttpClient client = CreateHttpClient())
                {
                    HttpResponseMessage response = await client.GetAsync(path, cancellationToken);
                    response.EnsureSuccessStatusCode();

                    string responseJson = await response.Content.ReadAsStringAsync();

                    result = JsonConvert.DeserializeObject<T>(responseJson);
                }
            }
            catch (JsonException ex)
            {
                throw new ApiClientException($"Could not deserialize the response body stream as {typeof(T).FullName}", ex);
            }
            catch (Exception ex)
            {
                throw new ApiClientException($"Failed to send the request : '{path}'", ex);
            }

            return result;
        }

    }
}
