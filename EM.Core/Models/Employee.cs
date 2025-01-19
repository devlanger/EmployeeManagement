namespace EM.Core.Models;

public class Employee : BaseEntity
{
    public string PersonalIdNumber { get; set; }
    
    public decimal Salary { get; set; }
    
    public int? TeamId { get; set; }
    
    public virtual Team Team { get; set; }
}