using RestApiStarter.Domain;

namespace RestApiStarter.Repositories;

public interface IUserRepository
{
  Task<IEnumerable<UserDto>> GetAllUsers();
  Task<UserDto?> GetUser(int id);

  Task<bool> CreateAsync(UserDto customer);
  Task<bool> UpdateUser(UserDto user);
  Task<bool> DeleteUser(int id);
}
