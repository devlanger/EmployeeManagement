using System.Text.Json.Serialization;

namespace EM.Core.Models;

public class Team : BaseEntity
{
    public string Name { get; set; }
    
    [JsonIgnore]
    public List<ApplicationUser> Members { get; set; }
}