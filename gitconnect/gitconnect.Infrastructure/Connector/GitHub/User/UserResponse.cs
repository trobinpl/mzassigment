using gitconnect.Infrastructure.Connector.GitHub.Repository;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gitconnect.Infrastructure.Connector.GitHub.User
{
    public class UserResponse
    {
        public string Login { get; set; }

        public string Location { get; set; }

        [JsonProperty(PropertyName = "avatar_url")]
        public string AvatarUrl { get; set; }

        [JsonProperty(PropertyName = "repos_url")]
        public string RepositoriesUrl { get; set; }
    }
}
