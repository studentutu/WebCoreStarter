using RestApiStarter.Domain;

namespace RestApiStarter.EndPoints;

public static class TestEndpoints
{
  private const string Users = "/api/Users";

  /// <summary>
  /// Custom Endpoints - no controllers
  /// </summary>
  /// <param name="routes"></param>
  public static void MapUsersEndpoints(this IEndpointRouteBuilder routes)
  {
    routes.MapGet(Users, () =>
      {
        return new[] { new UserDto() };
      })
      .WithName("GetAllUsers")
      .Produces<UserDto[]>(StatusCodes.Status200OK);

    routes.MapGet(Users + "/{id}", (int id) =>
      {
        //return new WeatherForecast { ID = id };
      })
      .WithName("GetUserById")
      .Produces<UserDto>(StatusCodes.Status200OK);

    routes.MapPut(Users + "/{id}", (int id, UserDto input) =>
      {
        return Results.NoContent();
      })
      .WithName("UpdateUser")
      .Produces(StatusCodes.Status204NoContent);

    routes.MapPost(Users, (UserDto model) =>
      {
        //return Results.Created($"/WeatherForecasts/{model.ID}", model);
      })
      .WithName("CreateUser")
      .Produces<UserDto>(StatusCodes.Status201Created);

    routes.MapDelete(Users + "/{id}", (int id) =>
      {
        //return Results.Ok(new WeatherForecast { ID = id });
      })
      .WithName("DeleteUser")
      .Produces<UserDto>(StatusCodes.Status200OK);
  }
}
