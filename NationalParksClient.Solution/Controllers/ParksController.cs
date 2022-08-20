using System.Reflection.PortableExecutable;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using NationalParkClient.Models;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace NationalParkClient.Controllers
{
  public class ParksController : Controller
  {
    private readonly ILogger<ParksController> _logger;

    public ParksController(ILogger<ParksController> logger)
    {
      _logger = logger;
    }

    public IActionResult Index()
    {
      var allRegions = Region.GetRegions();
      ViewBag.RegionId = new SelectList( allRegions, "RegionId", "Name");
      var allParks = Park.GetParks();
      return View(allParks);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
      return View("Error!");
    }

    // [HttpPost]
    // public IActionResult Index(Park park)
    // {     
    //   Park.Post(park);
    //   return RedirectToAction("Index");
    // }

    // public IActionResult Details(int id)
		// {
		// 	var park = park.GetDetails(id);
    //   ViewBag.Group = Group.GetDetails(park.GroupId);
		// 	return View(park);
		// }

		// [HttpPost]
		// public IActionResult Details(int id, Park park)
		// {
		// 	park.ParkId = id;
		// 	Park.Put(park);
		// 	return RedirectToAction("Details", id);
		// }

		// public IActionResult Edit(int id)
    // {
    //   var allGroups = Group.GetGroups();
    //   ViewBag.GroupId = new SelectList( allGroups, "GroupId", "GroupName");
    //   var park = Park.GetDetails(id);
    //   return View(park);
    // }

		// public IActionResult Delete(int id)
    // {
    //   Park.Delete(id);
    //   return RedirectToAction("Index");
    // }
  }
}