using Microsoft.AspNetCore.Mvc;
using PeopleManager.Dto.Identity;
using PeopleManager.Services;

namespace PeopleManager.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class IdentityController(IdentityService identityService) : ControllerBase
    {
        private readonly IdentityService _identityService = identityService;

        [HttpPost("sign-in")]
        public async Task<ActionResult> SignIn(SignInRequest request)
        {
            var result = await _identityService.SignIn(request);
            return Ok(result);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            var result = await _identityService.Register(request);
            return Ok(result);
        }
    }
}
