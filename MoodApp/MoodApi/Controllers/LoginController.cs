using System;
using System.Text.Json;
// using Models;
// using DataAccess;
using Microsoft.AspNetCore.Mvc;

namespace MoodApp.Controllers;

public class newLoginController : Controller
{
    private readonly ILogger<newLoginController> _logger;

    public newLoginController(ILogger<newLoginController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View("Login");
    }

    public IActionResult Privacy()
    {
        return View();
    }

//     [HttpPost]
//     public Users? Login([FromBody] JsonElement userLogin)
//     {
//         Users? users = JsonSerializer.Deserialize<Users?>(userLogin.GetRawText());
//         return DBRepo.GetUserbyUsername(user);
//     }
}