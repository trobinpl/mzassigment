using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gitconnect.Infrastructure.Connector.GitHub.Repository
{
    public class RepositoryResponse
    {
        public string Name { get; set; }

        [JsonProperty(PropertyName = "stargazers_count")]
        public int StargazersCount { get; set; }
    }
}
