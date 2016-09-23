﻿using FamilyHelper.Service.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace FamilyHelper.API.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Get()
        {
            var users = _userService.GetAll();

            return new OkObjectResult(users);
        }
    }
}