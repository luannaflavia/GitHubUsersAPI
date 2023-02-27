using System.Collections.Generic;

namespace GitHubUsersAPI.Entities
{
    public class UsersResponse
    {
        public List<Users> users { get; set; }  
        public string nextPage { get; set; }   
        
    }
}
