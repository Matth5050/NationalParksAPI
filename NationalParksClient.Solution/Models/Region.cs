using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

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
    public static Region GetDetails(int id)
    {
      var apiCallTask = ApiHelper.Get("regions", id);
      var result = apiCallTask.Result;

      JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
      Region region = JsonConvert.DeserializeObject<Region>(jsonResponse.ToString());

      return region;
    }

    public static void Post(Region region)
    {
      string jsonRegion = JsonConvert.SerializeObject(region);
      var apiCallTask = ApiHelper.Post("regions", jsonRegion);
    }

    public static void Put(Region region)
    {
      string jsonRegion = JsonConvert.SerializeObject(region);
      var apiCallTask = ApiHelper.Put("regions", region.RegionId, jsonRegion);
    }

    public static void Delete(int id)
    {
      var apiCallTask = ApiHelper.Delete("regions", id);
    }
  }
}