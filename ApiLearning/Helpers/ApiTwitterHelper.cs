using System.Collections.Generic;
using ApiLearning.Models;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Serialization.Json;

namespace ApiLearning.Helpers
{
    public class ApiTwitterHelper : ApiHelper
    {
        // Twitter app identification
        private string _token = "SHBSS0FFc05FZXlZallKNjFHR0pLNVV0MTp0ZjNENG9Oemx5bm9wVmFsRW5heERjRGw4NndJUUhVWXhteklHV1Vlb1h2aDQ0MWRlVg==";
        private string _bearer = "";
        private string _baseUrl = "https://api.twitter.com";
        private RestClient _client;

        // Gets the specified user's timeline
        public List<Tweet> GetUserTimeline(string[] parameters)
        {
            PreRequestCheck();

            var request = new RestRequest(BuildResource("/1.1/statuses/user_timeline.json?", parameters), Method.GET);
            BuildHeader(32, _bearer, request);

            // Gets the response from the API request
            IRestResponse response = _client.Execute(request);
            //Parses the Json to a list of Tweet models
            List<Tweet> timelineTweets = JsonConvert.DeserializeObject<List<Tweet>>(response.Content);

            return timelineTweets;
        }

        // Gets the specified user's information
        public List<TwitterUser> GetUserInfo(string[] parameters)
        {
            PreRequestCheck();

            var request = new RestRequest(BuildResource("/1.1/users/lookup.json?", parameters), Method.GET);
            BuildHeader(32, _bearer, request);

            // Gets the response from the API request
            IRestResponse response = _client.Execute(request);
            //Parses the Json to a list of TwitterUser models
            List<TwitterUser> userInfo = JsonConvert.DeserializeObject<List<TwitterUser>>(response.Content);

            return userInfo;
        }

        // Sends Twitter specific request for bearer token
        private void GetBearerToken()
        {
            _client = CheckClient(_client, _baseUrl);

            var request = new RestRequest("/oauth2/token?grant_type=client_credentials", Method.POST);

            request.AddHeader("oauth_nonce", GenerateNonce(32));
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddHeader("Authorization", "Basic " + _token);

            // Here we get the bearer token from the json response
            IRestResponse response = _client.Execute(request);
            var deserialize = new JsonDeserializer();
            var output = deserialize.Deserialize<Dictionary<string, string>>(response);
            _bearer = output["access_token"];
        }

        // Adds the standard Twitter API header attributes to the request
        private void BuildHeader(int bytes, string bearer, RestRequest request)
        {
            request.AddHeader("oauth_nonce", GenerateNonce(bytes));
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("Authorization", "Bearer " + bearer);
        }

        // shortened check function
        private void PreRequestCheck()
        {
            _client = CheckClient(_client, _baseUrl);
            CheckBearer();
        }

        // Makes sure _bearer has a token
        private void CheckBearer()
        {
            if(_bearer == "")
                GetBearerToken();
        }
    }
}