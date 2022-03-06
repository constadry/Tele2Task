using System.Diagnostics;
using Newtonsoft.Json;
using Tele2Task.Contexts;
using Tele2Task.Models;

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
        await context.Users.AddRangeAsync(users);
        await context.SaveChangesAsync();
    }
}