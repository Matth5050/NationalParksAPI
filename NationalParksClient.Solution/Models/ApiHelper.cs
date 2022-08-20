using System.Threading.Tasks;
using RestSharp;

namespace NationalParkClient.Models
{
  class ApiHelper
  {
    public static async Task<string> GetAll(string requestType)
    {
      RestClient client = new RestClient("http://localhost:5000/api");
      RestRequest request = new RestRequest($"{requestType}", Method.GET);
      var response = await client.ExecuteTaskAsync(request);
      return response.Content;
    }
  }
}
