using Newtonsoft.Json;

namespace NationalParkClient.Models
{
  public class AppUser
  {
    public string Name { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string Password { get; set; } = default!;
    public static string Token { get; set; } = default!;

    public static Task<string> Post(AppUser user)
    {
      string jsonUser = JsonConvert.SerializeObject(user);
      var apiCallTask = AuthorizationHelper.Register(jsonUser);
      return apiCallTask;
    }

    public static Task<string> Login(AppUser user)
    {
      string jsonUser = JsonConvert.SerializeObject(user);
      var apiCallTask = AuthorizationHelper.Login(jsonUser);
      return apiCallTask;
    }
  }
}