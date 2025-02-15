using EM.Core.Enums;

namespace EM.Core.Models;

public class AuditLog : BaseEntity
{
    public AuditLogType Type { get; set; }

    public required string Data { get; set; }
    
    public DateTime CreatedDate { get; set; }
}