using FastEndpoints;
using RestApiStarter.EndPoints;
using RestApiStarter.Repositories;
using RestApiStarter.Services;

namespace RestApiStarter;

public class Program
{
  public static void Main(string[] args)
  {
    var builder = WebApplication.CreateBuilder(args);

    // Add services to the container.

    builder.Services.AddControllers();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    // Custom
    builder.Services.AddSingleton<IUserService, UserService>();
    builder.Services.AddSingleton<IUserRepository, UserRepository>();

    builder.Services.AddFastEndpoints();

    var app = builder.Build();

    // custom endpoints - no controllers
    // app.MapUsersEndpoints();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
      app.UseSwagger();
      app.UseSwaggerUI();
    }

    // app.UseHttpsRedirection();

    app.UseFastEndpoints();

    app.UseAuthorization();


    app.MapControllers();

    app.Run();
  }
}
