using EM.Core.Enums;

namespace EM.Core.AuditLogs;

public class UpdateUserSalaryAuditLog : AuditLogBase
{
    public override AuditLogType Type => AuditLogType.USER_SALARY_UPDATE;

    public decimal Salary { get; set; }
    
    public int UserId { get; set; }
}