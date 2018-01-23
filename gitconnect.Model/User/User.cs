using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gitconnect.Model
{
    public class User
    {
        public User(string username, string location, string avatarUrl, List<Repository> repositories)
        {
            this.Username = username;
            this.Location = location;
            this.AvatarUrl = avatarUrl;
            this.Repositories = repositories;
        }

        // we don't want anybody to mess with bussines object internal state - it should only change due invoking public methods!
        public string Username { get; private set; }

        public string Location { get; private set; }

        public string AvatarUrl { get; private set; }

        public List<Repository> Repositories { get; private set; }

        // Let's assume, that this is some complicated bussines logic that it's worth encapsulating it this way (this one obviously is not, but hey - let's show off a little bit ;-) )
        public IEnumerable<Repository> GetRepositoriesSortedBy(Func<Repository, int> selector)
        {
            IEnumerable<Repository> sortedRepositories = this.Repositories.OrderByDescending(selector);

            foreach(Repository repository in sortedRepositories)
            {
                yield return repository;
            }
        }

        public override string ToString()
        {
            return $"Username: {this.Username}, Location: {this.Location}, AvatarUrl: {this.AvatarUrl}, No. repositories: {this.Repositories.Count}";
        }
    }
}
