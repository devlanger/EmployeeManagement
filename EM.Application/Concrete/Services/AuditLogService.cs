using EM.Application.Abstract.Services;
using EM.Core.AuditLogs;
using EM.Core.Models;
using Newtonsoft.Json;

namespace EM.Application.Concrete.Services;

public class AuditLogService(IRepository<AuditLog> auditLogRepository) : IAuditLogService
{
    public void Log(AuditLogBase auditLog)
    {
        var log = new AuditLog();

        switch (auditLog)
        {
            case UpdateUserAuditLog updateUserAuditLog:
                log.EntityId = updateUserAuditLog.UserId;
                break;
            case UpdateUserSalaryAuditLog salaryAuditLog:
                log.EntityId = salaryAuditLog.UserId;
                break;
            default:
                log.EntityId = log.EntityId;
                break;
        }

        log.Type = auditLog.Type;
        log.Data = JsonConvert.SerializeObject(auditLog);
        log.CreatedDate = DateTime.Now;
        
        auditLogRepository.AddAsync(log);
    }
}