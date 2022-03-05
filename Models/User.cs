using System.ComponentModel.DataAnnotations;

namespace Tele2Task.Models;

public class User
{
    [Key] public int UserId { get; set; }
    public string? Name { get; set; }
    public Sex Sex { get; set; }
}