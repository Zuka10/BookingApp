using BookingApp.API;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
Startup.ConfigureServices(builder.Services, builder.Configuration);
var app = builder.Build();

Startup.Configure(app, app.Environment);
app.MapControllers();

app.Run();
