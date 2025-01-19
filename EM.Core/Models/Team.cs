namespace EM.Core.Models;

public class Team : BaseEntity
{
    public string Name { get; set; }
    
    public List<Employee> Members { get; set; }
}