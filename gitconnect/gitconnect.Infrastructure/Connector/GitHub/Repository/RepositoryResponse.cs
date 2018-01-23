using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gitconnect.Infrastructure.Connector.GitHub.Repository
{
    // provided only useful from my point of view properties. Obviously in complete implementation I would add them all.
    public class RepositoryResponse
    {
        public string Name { get; set; }

        [JsonProperty(PropertyName = "stargazers_count")]
        public int StargazersCount { get; set; }
    }
}
