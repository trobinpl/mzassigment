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

        public string Username { get; set; }

        public string Location { get; set; }

        public string AvatarUrl { get; set; }

        public List<Repository> Repositories { get; set; }
    }
}
