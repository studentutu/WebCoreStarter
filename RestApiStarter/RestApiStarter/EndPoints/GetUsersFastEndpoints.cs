using FastEndpoints;
using Microsoft.AspNetCore.Authorization;
using RestApiStarter.Domain;
using RestApiStarter.Repositories;

namespace RestApiStarter.EndPoints;

[Serializable]
public class GetAllUsersResponse
{
  public List<UserDto> Users;
}

[HttpGet("api/users"), AllowAnonymous]
public class GetUsersFastEndpoints : EndpointWithoutRequest<GetAllUsersResponse>
{
  private readonly IUserRepository _customerService;

  public GetUsersFastEndpoints(IUserRepository customerService)
  {
    _customerService = customerService;
  }

  public override async Task HandleAsync(CancellationToken ct)
  {
    var customers = await _customerService.GetAllUsers();
    var customersResponse = new GetAllUsersResponse();
    customersResponse.Users = customers.ToList();
    await SendOkAsync(customersResponse, ct);
  }
}
