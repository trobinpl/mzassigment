using gitconnect.Infrastructure.Connector.GitHub.Repository;
using gitconnect.Infrastructure.Connector.GitHub.User;
using gitconnect.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gitconnect.Infrastructure.GitHubRepository
{
    public class UserRepository : IUserRepository
    {
        private UserApiConnector UserRequest;

        public UserRepository(UserApiConnector userRequest)
        {
            this.UserRequest = userRequest;
        }

        public async Task<User> GetUser(string username)
        {
            UserResponse userResponse = await this.UserRequest.GetUser(username);

            if(userResponse == null)
            {
                return null;
            }

            List<RepositoryResponse> repositoriesResponse = await this.UserRequest.GetUserRepositories(userResponse);

            List<Repository> repositories = new List<Repository>();
            repositoriesResponse.ForEach(r => repositories.Add(new Repository(r.Name, r.StargazersCount)));

            return new User(userResponse.Login, userResponse.Location, userResponse.AvatarUrl, repositories);
        }

        // providing this method just to show, how I would implement gathering data from other endpoints of GitHub API
        public async Task<List<Repository>> GetRepositoriesBelongingTo(User user)
        {
            List<Repository> repositories = new List<Repository>();
            List<RepositoryResponse> repositoriesResponse = await this.UserRequest.GetUserRepositories(user.Username);
            repositoriesResponse.ForEach(r => repositories.Add(new Repository(r.Name, r.StargazersCount)));

            return repositories;
        }
    }
}
