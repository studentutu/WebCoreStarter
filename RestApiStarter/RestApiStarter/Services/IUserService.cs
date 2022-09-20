using RestApiStarter.Domain;

namespace RestApiStarter.Services;

public interface IUserService
{
  Task<IEnumerable<UserDto>> GetAllUsers();
  Task<bool> CreateAsync(UserDto customer);
  Task<bool> UpdateUser(UserDto user);
  Task<bool> DeleteUser(int id);
}
