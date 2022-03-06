using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tele2Task.Models;

public class User
{
    [Key] public string UserId { get; set; }
    public string? Name { get; set; }
    [Column(TypeName = "nvarchar(24)")] public Sex Sex { get; set; }
}