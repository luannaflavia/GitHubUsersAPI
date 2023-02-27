using RestSharp;
using System.Threading.Tasks;

namespace GitHubUsersAPI.Interfaces
{
    public interface IUserDetails
    {
        Task<RestResponse> GetUserDetails(string username);        
    }
}
