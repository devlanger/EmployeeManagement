using EM.Core.Enums;

namespace EM.Core.AuditLogs;

public class UpdateUserAuditLog : AuditLogBase
{
    public override AuditLogType Type => AuditLogType.USER_UPDATE;
    
    public string Email { get; set; }
    
    public string Username { get; set; }

    public string? City { get; set; }

    public decimal Salary { get; set; }
    
    public int UserId { get; set; }
}