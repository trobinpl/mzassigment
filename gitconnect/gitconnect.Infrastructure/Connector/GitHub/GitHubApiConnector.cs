using gitconnect.Infrastructure.Connector.Serialization;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace gitconnect.Infrastructure.Connector.GitHub
{
    public abstract class GitHubApiConnector
    {
        protected Uri ApiUri = new Uri("https://api.github.com/");
        protected Uri EndpointUri;

        protected Uri RequestUri
        {
            get
            {
                return new Uri(ApiUri, EndpointUri);
            }
        }

        protected HttpClient HttpClient { get; private set; }

        public GitHubApiConnector()
        {
            this.HttpClient = new HttpClient();
            this.HttpClient.DefaultRequestHeaders.Add("User-Agent", "GithubConnect");
        }

        public GitHubApiConnector(Uri endpointUri) : this()
        {
            this.EndpointUri = endpointUri;
        }

        public GitHubApiConnector(string endpointUri) : this(new Uri(endpointUri, UriKind.Relative))
        {

        }

        // if I won't specify any serialization strategy, let's assume JSON.Net is my default one
        protected async Task<T> Get<T>(string endpoint)
        {
            return await this.Get<T>(endpoint, new JSONNetSerializationStrategy<T>());
        }

        // I do have dependecy in my project on JSON.Net, but who said, that I can't abstract using it, so I could change serializer without having to modify code, that depends on serialization/deserialiation
        protected async Task<T> Get<T>(string endpoint, ISerializationStrategy<T> serializationStrategy)
        {
            string responseBody = null;

            HttpResponseMessage response = await this.HttpClient.GetAsync(endpoint);

            if (response.IsSuccessStatusCode)
            {
                responseBody = await response.Content.ReadAsStringAsync();
                T result = serializationStrategy.Deserialize(responseBody);

                return result;
            }

            return default(T);
        }
    }
}
