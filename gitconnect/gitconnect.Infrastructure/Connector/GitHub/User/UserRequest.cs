using gitconnect.Infrastructure.Connector.GitHub.Repository;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace gitconnect.Infrastructure.Connector.GitHub.User
{
    public class UserRequest : GitHubRequest
    {
        public UserRequest() : base(new Uri("users/", UriKind.Relative))
        {

        }

        public UserRequest(string endpointUri) : base(endpointUri) {

        }


        public async Task<UserResponse> GetUser(string username)
        {
            var completeEndpoint = new Uri(this.RequestUri, new Uri(username, UriKind.Relative));

            UserResponse userInfo = await this.Get<UserResponse>(completeEndpoint.ToString());

            return userInfo;
        }

        public async Task<List<RepositoryResponse>> GetUserRepositories(string username)
        {
            var completeEndpoint = new Uri(this.RequestUri, new Uri($"{username}/repos", UriKind.Relative));

            List<RepositoryResponse> repositoryInfo = await this.Get<List<RepositoryResponse>>(completeEndpoint.ToString());

            return repositoryInfo;
        }

        public async Task<List<RepositoryResponse>> GetUserRepositories(UserResponse user)
        {
            List<RepositoryResponse> repositoryInfo = await this.Get<List<RepositoryResponse>>(user.RepositoriesUrl);
            return repositoryInfo;
        }

    }
}
