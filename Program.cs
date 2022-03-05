using Microsoft.EntityFrameworkCore;
using Tele2Task.Contexts;

var builder = WebApplication.CreateBuilder(args);

var connection = builder.Configuration.GetConnectionString("DefaultConnection");
var version = ServerVersion.AutoDetect(connection);
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(connection, version));

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();