using EM.Core.Enums;

namespace EM.Core.Models;

public class AuditLog : BaseEntity
{
    public AuditLogType Type { get; set; }

    public int? EntityId { get; set; }
    
    public string Data { get; set; }
    
    public DateTime CreatedDate { get; set; }
}