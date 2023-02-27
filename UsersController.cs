using GitHubUsersAPI.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GitHubUsersAPI.Controllers
{

    public class UsersController : ControllerBase
    {
        private readonly IUserDetails _userDetails;
        private readonly IUsers _users;
        private readonly IUserRepositories _userRepositories;

        public UsersController(IUserDetails userDetails, IUsers users, IUserRepositories userRepositories)
        {
            _userDetails = userDetails;
            _users = users;
            _userRepositories = userRepositories;
        }

        [HttpGet]
        [Route("api/users/since={number}")]
        [ProducesResponseType(typeof(List<Service.UsersService>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetUsers(int number)
        {

            var response = await _users.GetUsers(number);
            if (response == null)
                return NotFound();
            return Ok(response);
        }

        [HttpGet]
        [Route("api/users/username/details")]
        [ProducesResponseType(typeof(List<Service.UsersService>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetUserDetails(string username)
        {
            var response = await _userDetails.GetUserDetails(username);
            if (response == null)
                return NotFound();
            return Ok(response.Content);
        }

        [HttpGet]
        [Route("api/users/:username/repos")]
        [ProducesResponseType(typeof(List<Service.UsersService>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetUserRepositories(string username)
        {
            var response = await _userRepositories.GetUserRepositories(username);
            if (response == null)
                return NotFound();
            return Ok(response);
        }
    }
}
