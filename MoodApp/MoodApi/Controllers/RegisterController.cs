using System;
using System.Text.Json;
// using Models;
// using DataAccess;
using Microsoft.AspNetCore.Mvc;

namespace MoodApp.Controllers;

public class newRegisterController : Controller
{
    private readonly ILogger<newRegisterController> _logger;

    public newRegisterController(ILogger<newRegisterController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View("Register");
    }

    public IActionResult Privacy()
    {
        return View();
    }

//     [HttpPost]
//     public Users? Login([FromBody] JsonElement userLogin)
//     {
//         Users? user = JsonSerializer.Deserialize<Users?>(userLogin.GetRawText());
//         return DBRepo.GetUserbyUsername(user);
//     }
}