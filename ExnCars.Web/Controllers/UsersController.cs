﻿using ExnCars.Services.UserServices;
using ExnCars.Services.UserServices.Dto;
using ExnCars.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace ExnCars.Web.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserService userService;


        public UsersController(IUserService userService)
        {
            this.userService = userService;
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

            return View(userViewModels);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult Create([FromForm] UserViewModel userViewModel)
        {
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

        public IActionResult Edit([FromForm] UserViewModel userViewModel)
        {
            var userDto = new UserDto
            {
                Email = userViewModel.Email,
                FirstName = userViewModel.FirstName,
                ID = userViewModel.ID,
                LastName = userViewModel.LastName
            };
            userService.UpdateUser(userDto);
            return RedirectToAction("Index", "Users");

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
