using gitconnect.Infrastructure.Connector.GitHub.Repository;
using gitconnect.Infrastructure.Connector.Serialization;
using gitconnect.Infrastructure.Extensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace gitconnect.Infrastructure.Connector.GitHub.User
{
    public class UserApiConnector : GitHubApiConnector
    {
        public UserApiConnector() : base(new Uri("users/", UriKind.Relative))
        {

        }

        public UserApiConnector(string endpointUri) : base(endpointUri) {

        }


        public async Task<UserResponse> GetUser(string username)
        {
            var completeEndpoint = this.RequestUri.Append(username);

            UserResponse userInfo = await this.Get<UserResponse>(completeEndpoint.ToString(), JSONNetSerializationStrategy<UserResponse>.Create());

            return userInfo;
        }

        // we could just create URI for repositories belonging to specific user - we could use this method when we don't want to retrieve user 
        public async Task<List<RepositoryResponse>> GetUserRepositories(string username)
        {
            var completeEndpoint = this.RequestUri.Append($"{username}/repos");

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
