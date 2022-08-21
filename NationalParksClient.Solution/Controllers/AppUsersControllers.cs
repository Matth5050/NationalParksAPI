using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NationalParkClient.Models;
using Json.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace NationalParkClient.Controllers
{
  public class AppUsersController : Controller
  {
    private readonly ILogger<AppUsersController> _logger;

    public AppUsersController(ILogger<AppUsersController> logger)
    {
      _logger = logger;
    }

    public IActionResult Index()
    {
      ViewBag.ResultBody = AppUser.Token;
      return View();
    }

    [HttpPost]
    public async Task<IActionResult> Index(AppUser user)
    {
      var response = await AppUser.Post(user);
      JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(response);
      AppUser.Token = ((string)jsonResponse["token"]); 
      ViewBag.ResultBody = AppUser.Token;     
      return View("Index", "Home");
    }

    public IActionResult Login()
    {
      ViewBag.ResultBody = AppUser.Token;
      return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(AppUser user)
    {
      var response = await AppUser.Login(user);
      JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(response);
      AppUser.Token = ((string)jsonResponse["token"]);   
      ViewBag.ResultBody = AppUser.Token;   
      return View("Index", "Home");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
      return View("Error!");
    }
  }
}