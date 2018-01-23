using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace gitconnect.Infrastructure.Connector.GitHub
{
    public abstract class GitHubRequest
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

        public GitHubRequest()
        {
            this.HttpClient = new HttpClient();
            this.HttpClient.DefaultRequestHeaders.Add("User-Agent", "GithubConnect");
        }

        public GitHubRequest(Uri endpointUri) : this()
        {
            this.EndpointUri = endpointUri;
        }

        public GitHubRequest(string endpointUri) : this(new Uri(endpointUri, UriKind.Relative))
        {

        }

        protected async Task<T> Get<T>(string endpoint)
        {
            string responseBody = null;

            HttpResponseMessage response = await this.HttpClient.GetAsync(endpoint);

            if (response.IsSuccessStatusCode)
            {
                responseBody = await response.Content.ReadAsStringAsync();
            }

            T result = JsonConvert.DeserializeObject<T>(responseBody);

            return result;
        }
    }
}
