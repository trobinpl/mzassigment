using gitconnect.Infrastructure.Connector.GitHub.Repository;
using gitconnect.Infrastructure.Connector.GitHub.User;
using gitconnect.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gitconnect.Infrastructure.GitHubRepository
{
    public class UserRepository : IUserRepository
    {
        private UserRequest UserRequest;

        public UserRepository(UserRequest userRequest)
        {
            this.UserRequest = userRequest;
        }

        public async Task<User> GetUser(string username)
        {
            UserResponse userResponse = await this.UserRequest.GetUser(username);
            List<RepositoryResponse> repositoryResponse = await this.UserRequest.GetUserRepositories(userResponse);

            List<Repository> repositories = new List<Repository>();
            repositoryResponse.ForEach(r => repositories.Add(new Repository(r.Name, r.StargazersCount)));

            return new User(userResponse.Login, userResponse.Location, userResponse.AvatarUrl, repositories);
        }
    }
}
