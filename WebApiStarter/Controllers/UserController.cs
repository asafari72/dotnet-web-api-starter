using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApiStarter.Models;
using WebApiStarter.Services;
using WebApiStarter.Util;

namespace WebApiStarter.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UsersService _usersService;
        private readonly Hasher _hasher;

        public UserController(UsersService usersService) {
            _usersService = usersService;
            _hasher = new Hasher();

        }

        [HttpGet]
        public async Task<List<User>> Get() => await _usersService.GetAsync();


        [HttpPost]
        public async Task<IActionResult> Post(User newUser)
        {
            newUser.password = _hasher.hash(newUser.password);
            await _usersService.CreateAsync(newUser);
            return CreatedAtAction(nameof(Get), new { id = newUser.Id }, newUser);
        }

    }
}
