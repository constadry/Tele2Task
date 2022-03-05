using Microsoft.EntityFrameworkCore;
using Tele2Task;
using Tele2Task.Contexts;

var builder = WebApplication.CreateBuilder(args);

var connection = builder.Configuration.GetConnectionString("DefaultConnection");
var version = ServerVersion.AutoDetect(connection);
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(connection, version));
builder.Services.AddSwaggerGen();

var app = builder.Build();
var scope = app.Services.CreateScope();
var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

try
{
    await SampleData.Initialize(context);
}
catch (Exception e)
{
    Console.WriteLine(e.Message + "An error occurred seeding the DB.");
    throw;
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/", () => "Hello World!");

app.Run();