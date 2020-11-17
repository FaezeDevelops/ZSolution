using System;

namespace Solution.JsonPlaceHolder.API.Client
{
    public class ClientConfiguration
    {
        public Uri BaseAddress { get; set; }

        public string PostsEndpoint { get; set; }
        public string CommentsEndpoint { get; set; }
        public string AlbumsEndpoint { get; set; }
        public string PhotosEndpoint { get; set; }
        public string TodosEndpoint { get; set; }
        public string UsersEndpoint { get; set; }

        public string BearerToken { get; set; }
    }
}
