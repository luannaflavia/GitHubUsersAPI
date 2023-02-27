using GitHubUsersAPI.Entities;
using GitHubUsersAPI.Interfaces;
using RestSharp;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace GitHubUsersAPI.Service
{
    public class UsersService : IUsers
    {
        public async Task<UsersResponse> GetUsers(int number)
        {
            RestClient client = new("https://api.github.com/");
            RestRequest request = new($"users?since={number}", Method.Get);
            request.AddHeader("Authorization", "Bearer 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");

            RestResponse response = await client.ExecuteGetAsync(request);
            
            List<Users> users = JsonSerializer.Deserialize<List<Users>>(response.Content);
            UsersResponse ur = new()
            {
                users = users,
                nextPage = GetNextUrl(response)
            };

            return ur;
        }

        private static string GetNextUrl(RestResponse rr)
        {
            string? temp = rr?.Headers.Where(o => o.Name == "Link")!.FirstOrDefault()!.Value.ToString();
            int firstCaracter = temp.IndexOf(">");
            return temp.Substring(1, firstCaracter - 1);
        }

    }
}