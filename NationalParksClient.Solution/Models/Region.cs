using System.Collections.Generic;
using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace NationalParkClient.Models
{
  public class Region
  {
    public int RegionId { get; set; }
    public string Name { get; set; } = default!;
    public static List<Region> GetRegions()
    {

      var apiCallTask = ApiHelper.GetAll("regions");
      var result = apiCallTask.Result;
      
      JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);
      List<Region> regionList = JsonConvert.DeserializeObject<List<Region>>(jsonResponse.ToString());

      return regionList;
    }
  }
  }