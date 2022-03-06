using System.Diagnostics;
using Newtonsoft.Json;
using Tele2Task.Contexts;
using Tele2Task.Models;
using Tele2Task.Tools;

namespace Tele2Task;

public class SampleData
{
    public static async Task Initialize(AppDbContext context)
    {
        Debug.Assert(context.Users != null, "context.Users != null");
        if (context.Users.Any())
            return;
        var httpClient = new HttpClient();
        var response = await httpClient.GetAsync("http://testlodtask20172.azurewebsites.net/task");
        var userContent = await response.Content.ReadAsStringAsync();
        Console.WriteLine("users {" +
                          $"{userContent}" +
                          "}");
        var users = (JsonConvert.DeserializeObject<IEnumerable<User>>(userContent) ?? Array.Empty<User>()).ToList();
        Console.WriteLine("deserialized users: ");
        users.ForEach(u => Console.WriteLine(u.UserId + " " + u.Name + " " + u.Sex));
        users.ForEach(SetAgeAsync);
        await context.Users.AddRangeAsync(users);
        await context.SaveChangesAsync();
    }

    private static async void SetAgeAsync(User u)
    {
        await SetAge(u);
    }

    private static async Task SetAge(User user)
    {
        var httpClient = new HttpClient();
        var response = await httpClient
            .GetAsync($"http://testlodtask20172.azurewebsites.net/task/{user.UserId}");
        var userWithAgeContent = await response.Content.ReadAsStringAsync();
        var userWithAge = JsonConvert.DeserializeObject<User>(userWithAgeContent);
        if (userWithAge is null)
            throw new Tele2Exception("Input data is invalid");
        user.Age = userWithAge.Age;
    }
}