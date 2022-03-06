using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Tele2Task.Models;

public class User
{
    [Key][JsonProperty("id")] public string UserId { get; set; }
    public string? Name { get; set; }
    [Column(TypeName = "nvarchar(24)")]
    [JsonConverter(typeof(StringEnumConverter))]
    public Sex Sex { get; set; }
}