// using Models;
// using Services;
// using DataAccess;
using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace MoodApp.Controllers;

[ApiController]
[Route("[controller]")]

public class UsersController : ControllerBase
{
    private readonly ILogger<UsersController> _logger;
}

