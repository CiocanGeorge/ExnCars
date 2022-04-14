using ExnCars.Services.UserServices;
using ExnCars.Services.UserServices.Dto;
using ExnCars.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ExnCars.Web.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserService userService;
        private readonly IHostEnvironment hostEnviroment;


        public UsersController(IUserService userService, IHostEnvironment hostEnviroment)
        {
            this.userService = userService;
            this.hostEnviroment = hostEnviroment;
        }
        [HttpGet]
        public IActionResult Index()
        {
            
            var userDtos = userService.GetUsers() ?? new List<UserDto>();

            var userViewModels = userDtos?.Select(x => new UserViewModel
            {
                ID = x.ID,
                Email = x.Email,
                FirstName = x.FirstName,
                LastName = x.LastName
            }).ToList();

            ViewBag.YourName = "Admin";

            return View(userViewModels);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult Create([FromForm] UserViewModel userViewModel)
        {
            if(userViewModel==null)
            {
                return RedirectToAction("SomethingWentWrong", "Helpers", new { message = "UserViewModel is null" });
            }
            if(!ModelState.IsValid)
            {
                return View(userViewModel);
            }

            var avatarFileName = $"{Guid.NewGuid().ToString("N")}-{userViewModel.Avatar.FileName}";
            var webProjectPath = hostEnviroment.ContentRootPath;
            var avatarPath = Path.Combine(webProjectPath, avatarFileName);

            using(var stream=System.IO.File.Create(avatarPath))
            {
                userViewModel.Avatar.CopyTo(stream);
            }


            var userDto = new UserDto
            {
                FirstName = userViewModel.FirstName,
                LastName = userViewModel.LastName,
                Email = userViewModel.Email
            };
            userService.RegisterUser(userDto);
            return RedirectToAction("Index", "Users");

        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            if(id<1)
            {
                return RedirectToAction("SomethingWentWrong", "Helpers", new { message = "User's ID is negative!" });
            }

            var userDto = userService.GetUserById(id);
            if (userDto == null) 
            {
                return RedirectToAction("NotFound", "Helpers", new { message = "User could not be retrieved!" });
            }

            var userViewModel = new UserViewModel
            {
                ID = userDto.ID,
                LastName = userDto.LastName,
                FirstName = userDto.FirstName,
                Email = userDto.Email
            };

            return View(userViewModel);
        }
        [HttpPost]
        public IActionResult Edit([FromForm] UserViewModel userViewModel)
        {
            if(userViewModel==null)
            {
                return RedirectToAction("SomethingWentWrong", "Helpers", new { message = "UserViewModel is null!" });
            }
            var userDto = new UserDto
            {
                Email = userViewModel.Email,
                FirstName = userViewModel.FirstName,
                ID = userViewModel.ID,
                LastName = userViewModel.LastName
            };
            userService.UpdateUser(userDto);
            return RedirectToAction("Index");

        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            var user = userService.GetUserById(id);
            var userViewModel = new UserViewModel
            {
                ID = user.ID,
                LastName = user.LastName,
                FirstName = user.FirstName,
                Email = user.Email
            };
            return View(userViewModel);
        }
        public IActionResult Delete(int id)
        {
            var user = userService.GetUserById(id);

            userService.Delete(user);
            return RedirectToAction("Index", "Users");
        }
    }
}
