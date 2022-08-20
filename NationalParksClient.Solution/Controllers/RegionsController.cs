using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NationalParkClient.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace NationalParkClient.Controllers
{
  public class RegionsController : Controller
  {
    private readonly ILogger<RegionsController> _logger;

    public RegionsController(ILogger<RegionsController> logger)
    {
      _logger = logger;
    }

    public IActionResult Index()
    {
      var allRegions = Region.GetRegions();
      return View(allRegions);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
      return View("Error!");
    }


		// [HttpPost]
    // public IActionResult Index(Region region)
    // {
		// 	Region.Post(region);
		// 	return RedirectToAction("Index");
    // }

	// 	public IActionResult Details(int id)
	// 	{
	// 		var region = Region.GetDetails(id);
	// 		return View(region);
	// 	}

	// 	[HttpPost]
	// 	public IActionResult Details(int id, Region region)
	// 	{
	// 		region.RegionId = id;
	// 		Region.Put(region);
	// 		return RedirectToAction("Details", id);
	// 	}

	// 	public IActionResult Edit(int id)
  //   {
  //     var region = Region.GetDetails(id);
  //     return View(region);
  //   }

  //   [HttpPost]
  //   public IActionResult Edit(Region region)
  //   {     
  //     Region.Put(region);
  //     return RedirectToAction("Index");
  //   }

	// 	public IActionResult Delete(int id)
  //   {
  //     Region.Delete(id);
  //     return RedirectToAction("Index");
  //   }
  // }
}}