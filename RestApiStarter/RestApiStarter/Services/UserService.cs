using Newtonsoft.Json;
using RestApiStarter.Domain;

namespace RestApiStarter.Services;

public class UserService : IUserService
{
  private readonly HttpClient _httpClient = new HttpClient();
  private const string baseApi = "https://gorest.co.in";
  private const string UsersApi = "public/v2/users";
  private const string CRUDApi = "public/v2/users/{0}";

  public async Task<IEnumerable<UserDto>> GetAllUsers()
  {
    var uri = new Uri(baseApi);
    uri = new Uri(uri, UsersApi);
    var response = await _httpClient.GetAsync(uri);
    if (!response.IsSuccessStatusCode)
    {
      return Array.Empty<UserDto>();
    }

    var body = await response.Content.ReadAsStringAsync();
    var result = JsonConvert.DeserializeObject<List<UserDto>>(body);
    return result;
  }

  public Task<bool> CreateAsync(UserDto customer)
  {
    throw new NotImplementedException();
  }

  public Task<bool> UpdateUser(UserDto user)
  {
    throw new NotImplementedException();
  }

  public Task<bool> DeleteUser(int id)
  {
    throw new NotImplementedException();
  }
}
