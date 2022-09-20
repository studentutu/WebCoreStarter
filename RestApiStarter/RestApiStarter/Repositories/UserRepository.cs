using RestApiStarter.Domain;
using RestApiStarter.Services;

namespace RestApiStarter.Repositories;

public class UserRepository : IUserRepository
{
  private readonly IUserService _userService;
  private readonly List<UserDto> _users;

  public UserRepository(IUserService userService)
  {
    _userService = userService;
    _users = new List<UserDto>(40);
  }

  public async Task<IEnumerable<UserDto>> GetAllUsers()
  {
    if (HasActiveUsers())
    {
      return _users;
    }

    _users.Clear();
    var result = await _userService.GetAllUsers();
    _users.AddRange(result);
    return _users;
  }

  public async Task<UserDto?> GetUser(int id)
  {
    await GetAllUsers();
    return _users.Find(x => x.ID == id);
  }

  public async Task<bool> CreateAsync(UserDto customer)
  {
    var user = await GetUser(customer.ID);
    if (user != null)
    {
      return false;
    }

    return await _userService.CreateAsync(customer);
  }

  public async Task<bool> UpdateUser(UserDto user)
  {
    var userInDb = await GetUser(user.ID);
    if (userInDb == null)
    {
      return false;
    }

    return await _userService.UpdateUser(user);
  }

  public async Task<bool> DeleteUser(int id)
  {
    var toRemove = _users.Find(x => x.ID == id);
    var removed = await _userService.DeleteUser(id);
    if (removed)
    {
      _users.Remove(toRemove);
    }

    return removed;
  }

  private bool HasActiveUsers()
  {
    return _users.Any();
  }
}
