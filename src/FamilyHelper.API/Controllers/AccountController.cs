using System.Threading.Tasks;
using FamilyHelper.API.Models.DTO;
using FamilyHelper.Entities.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FamilyHelper.API.Controllers
{
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet("register")]
        public IActionResult Register()
        {
            return new OkResult();
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserRegisterDTO registerDto)
        {
            if (ModelState.IsValid)
            {
                var user = new User()
                {
                    UserName = registerDto.UserName,
                    FirstName = registerDto.FirstName,
                    LastName = registerDto.LastName
                };

                var result = await _userManager.CreateAsync(user, registerDto.Password);
                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, false);
                    return new OkResult();
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return new OkResult();
        }
    }
}
