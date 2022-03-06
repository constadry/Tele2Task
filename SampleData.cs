using System.Diagnostics;
using System.Text.Json;
using Tele2Task.Contexts;
using Tele2Task.Models;

namespace Tele2Task;

public class SampleData
{
    public static async Task Initialize(AppDbContext context)
    {
        var httpClient = new HttpClient();
        var response = await httpClient.GetAsync("http://testlodtask20172.azurewebsites.net/task");
        var userContent = await response.Content.ReadAsStringAsync();
        var users = (JsonSerializer.Deserialize<IEnumerable<User>>(userContent) ?? Array.Empty<User>()).ToList();
        Debug.Assert(context.Users != null, "context.Users != null");
        await context.Users.AddRangeAsync(users);
        await context.SaveChangesAsync();
    }
}