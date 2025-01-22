namespace EM.Application.Models;

public class SalaryStatisticResponseModel
{
    /// <summary>
    /// Minimum amount of salary
    /// </summary>
    public int MinSalary { get; set; }
    
    
    /// <summary>
    /// Maximum amount of salary
    /// </summary>
    public int MaxSalary { get; set; }
    
    /// <summary>
    /// Amount of employees with given salary
    /// </summary>
    public int Amount { get; set; }
}