using EM.Application.Concrete.Services;
using EM.Core.Models;

namespace EM.Application.Abstract.Services;

public interface IAuditLogService
{
    void Log(AuditLogBase auditLog);
}