using System.Collections.Generic;
using ApiLearning.Models;
using Newtonsoft.Json;
using RestSharp;

namespace ApiLearning.Helpers
{
    public class ApiInstagramHelper : ApiHelper
    {
        private string _accessToken = "21980132011.947bcbd.faa5d84d6efb4345b47f5ab1bd61dc4c";
        private string _baseUrl = "https://api.instagram.com";
        private RestClient _client;

        public InstagramFeed GetFeed()
        {
            _client = CheckClient(_client, _baseUrl);

            var request = new RestRequest("/v1/users/self/media/recent/?access_token=" + _accessToken, Method.GET);
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("Connection", "keep-alive");
            request.AddHeader("Accept-Encoding", "gzip, deflate");
            request.AddHeader("Host", "api.instagram.com");
            request.AddHeader("oauth_nonce", GenerateNonce(32));
            request.AddHeader("Cache-Control", "no-cache");
            request.AddHeader("Accept", "*/*");
            request.AddHeader("User-Agent", "PostmanRuntime/7.18.0");

            IRestResponse response = _client.Execute(request);
            InstagramFeed feed = JsonConvert.DeserializeObject<InstagramFeed>(response.Content);

            return feed;
        }
    }
}