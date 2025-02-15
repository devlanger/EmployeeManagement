using System.Text.Json;
using EM.Application.Abstract.Services;
using EM.Core.Enums;
using EM.Core.Models;
using Newtonsoft.Json;

namespace EM.Application.Concrete.Services;

public class AuditLogService(IRepository<AuditLog> auditLogRepository) : IAuditLogService
{
    public void Log(AuditLogBase auditLog)
    {
        var log = new AuditLog();
        
        log.EntityId = auditLog switch
        {
            UpdateUserAuditLog updateUserAuditLog => updateUserAuditLog.UserId,
            _ => log.EntityId
        };

        log.Type = auditLog.Type;
        log.Data = JsonConvert.SerializeObject(auditLog);
        log.CreatedDate = DateTime.Now;
        
        auditLogRepository.AddAsync(log);
    }
}

public abstract class AuditLogBase
{
    public abstract AuditLogType Type { get; }
}

public class UpdateUserAuditLog() : AuditLogBase
{
    public override AuditLogType Type => AuditLogType.USER_UPDATE;
    
    public string Email { get; set; }
    
    public string Username { get; set; }

    public string? City { get; set; }

    public decimal Salary { get; set; }
    
    public int UserId { get; set; }
}