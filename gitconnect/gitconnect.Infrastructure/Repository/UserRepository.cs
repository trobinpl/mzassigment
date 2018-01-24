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
        private UserApiConnector UserApiConnector;

        public UserRepository(UserApiConnector userApiConnector)
        {
            this.UserApiConnector = userApiConnector;
        }

        public async Task<User> GetUser(string username)
        {
            UserResponse userResponse = await this.UserApiConnector.GetUser(username);

            if(userResponse == null)
            {
                return null;
            }

            List<RepositoryResponse> repositoriesResponse = await this.UserApiConnector.GetUserRepositories(userResponse);

            List<Repository> repositories = new List<Repository>();
            repositoriesResponse.ForEach(r => repositories.Add(new Repository(r.Name, r.StargazersCount)));

            return new User(userResponse.Login, userResponse.Location, userResponse.AvatarUrl, repositories);
        }

        // providing this method just to show, how I would implement gathering data from other endpoints of GitHub API
        public async Task<List<Repository>> GetRepositoriesBelongingTo(User user)
        {
            List<Repository> repositories = new List<Repository>();
            List<RepositoryResponse> repositoriesResponse = await this.UserApiConnector.GetUserRepositories(user.Username);

            if(repositoriesResponse == null)
            {
                return null;
            }

            repositoriesResponse.ForEach(r => repositories.Add(new Repository(r.Name, r.StargazersCount)));

            return repositories;
        }
    }
}
