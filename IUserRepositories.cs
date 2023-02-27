using GitHubUsersAPI.Entities;
using RestSharp;
using System.Threading.Tasks;

namespace GitHubUsersAPI.Interfaces
{
    public interface IUserRepositories
    {
        Task<RestResponse> GetUserRepositories(string username);
    }
}
