using FamilyHelper.Data.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace FamilyHelper.API.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private IUnitOfWork _unitOfWork;

        public UserController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Get()
        {
            var users = _unitOfWork.UserRepository.GetAll();

            return new OkObjectResult(users);
        }
    }
}
