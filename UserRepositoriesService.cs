using GitHubUsersAPI.Entities;
using GitHubUsersAPI.Interfaces;
using RestSharp;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

namespace GitHubUsersAPI.Service
{
    public class UserRepositoriesService : IUserRepositories
    {
        public async Task<RestResponse> GetUserRepositories(string username)
        {
            var client = new RestClient("https://api.github.com/");
            var request = new RestRequest($"users/{username}/repos", Method.Get);
            request.AddHeader("Authorization", "Bearer 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");
            var response = await client.ExecuteGetAsync(request);

            return response;
        }

    }
}