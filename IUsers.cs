using GitHubUsersAPI.Entities;
using RestSharp;
using System.Net.Http;
using System.Threading.Tasks;

namespace GitHubUsersAPI.Interfaces
{
    public interface IUsers
    {
        Task<UsersResponse> GetUsers(int number);
    }
}
