using GitHubUsersAPI.Interfaces;
using RestSharp;
using System.Threading.Tasks;

namespace GitHubUsersAPI.Service
{
    public class UserDetailsService : IUserDetails
    {
        public async Task<RestResponse> GetUserDetails(string username)
        {
            var client = new RestClient("https://api.github.com/");
            var request = new RestRequest($"users/{username}", Method.Get);
            request.AddHeader("Authorization", "Bearer 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");
            var response = await client.ExecuteGetAsync(request);

            return response;
        }

    }
}
