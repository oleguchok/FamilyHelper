using AspNet.Security.OAuth.Introspection;
using FamilyHelper.Service.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FamilyHelper.API.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [Authorize(ActiveAuthenticationSchemes = OAuthIntrospectionDefaults.AuthenticationScheme)]
        [HttpGet]
        public IActionResult Get()
        {
            var users = _userService.GetAll();

            return new OkObjectResult(users);
        }
    }
}
