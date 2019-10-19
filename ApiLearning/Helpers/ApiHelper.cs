using System;
using System.Security.Cryptography;
using RestSharp;

namespace ApiLearning.Helpers
{
    public class ApiHelper
    {
        // Creates new RestClient
        protected RestClient InitializeClient(string baseUrl)
        {
            var client = new RestClient(baseUrl);
            return client;
        }

        // Generates nonce for authentication
        protected static string GenerateNonce(int bytes)
        {
            var byteArray = new byte[bytes];
            using (var rnd = RandomNumberGenerator.Create())
            {
                rnd.GetBytes(byteArray);
            }
            return Convert.ToBase64String(byteArray);
        }

        // Adds the given parameters to the base url
        protected string BuildResource(string baseUrl, string[] parameters)
        {
            foreach (var p in parameters)
            {
                if (parameters[0] == p)
                    baseUrl += p;
                else
                    baseUrl += "&" + p;
            }

            return baseUrl;
        }

        // Makes sure _client has a client
        protected RestClient CheckClient(RestClient client, string baseUrl)
        {
            if (client is null)
                client = InitializeClient(baseUrl);

            return client;
        }
    }
}