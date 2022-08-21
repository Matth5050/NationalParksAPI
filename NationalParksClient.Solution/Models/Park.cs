using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace NationalParkClient.Models
{
  public class Park
  {
    public int ParkId { get; set; }
    public int RegionId { get; set; }
    public string Name { get; set; } = default!;
    public string State { get; set; } = default!;
  
    public static List<Park> GetParks()
    {
      var apiCallTask = ApiHelper.GetAll("parks");
      var result = apiCallTask.Result;

      JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);
      List<Park> parkList = JsonConvert.DeserializeObject<List<Park>>(jsonResponse.ToString());

      return parkList;
    }

    public static Park GetDetails(int id)
    {
      var apiCallTask = ApiHelper.Get("parks", id);
      var result = apiCallTask.Result;

      JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
      Park park = JsonConvert.DeserializeObject<Park>(jsonResponse.ToString());

      return park;
    }

    public static void Post(Park park)
    {
      string jsonPark = JsonConvert.SerializeObject(park);
      var apiCallTask = ApiHelper.Post("parks", jsonPark);
    }

    public static void Put(Park park)
    {
      string jsonPark = JsonConvert.SerializeObject(park);
      var apiCallTask = ApiHelper.Put("parks", park.ParkId, jsonPark);
    }

    public static void Delete(int id)
    {
      var apiCallTask = ApiHelper.Delete("parks", id);
    }
  }
}