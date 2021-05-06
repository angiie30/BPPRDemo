using BPPR_Demo.Models;
using BPPR_Demo.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BPPR_Demo.Controllers
{
    [ApiController]
    [Route("Users")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var response = await _userService.Get();

            if (!response.Success) return BadRequest(response);

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var response = await _userService.Get(id);

            if (!response.Success) return BadRequest(response);

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult> Create(User user)
        {
            var response = await _userService.Create(user);

            if (!response.Success) return BadRequest(response);

            return Ok(response);
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] UserDetail user)
        {
            if (id == 0) return BadRequest(new Response<User>() { Success = false, Message = "User ID is required," });

            var response = await _userService.Update(id, user.Email, user.Phone, user.Active);

            if (!response.Success) return BadRequest(response);

            return Ok(response);
        }
    }
}
