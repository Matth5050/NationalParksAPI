using System.Collections.Generic;
using System;
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
  }
}