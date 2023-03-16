// using System;
// using System.Text.Json;
// // using Services;
// // using Models;
// // using DataAccess;
// using Microsoft.AspNetCore.Mvc;

// namespace MoodApp.Controllers;

// public class newRegisterController : Controller
// {
//     private readonly ILogger<newRegisterController>? _logger;
//     // private readonly UserServices _userService;

//     // public newRegisterController(ILogger<newRegisterController> logger, UserServices userService)
//     // {
//     //     _logger = logger;
//     //     _userService = userService;
//     // }

//     public IActionResult Index()
//     {
//         return View("Register");
//     }

//     public IActionResult Privacy()
//     {
//         return View();
//     }



//     // [HttpPost]
//     // public IActionResult Register([FromBody] Users? newUser)
//     // {
//     //     return _userService.CreateNewUser(newUser);
//     // }
// }