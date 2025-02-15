using EM.Core.Enums;
using EM.Core.Models;
using MediatR;

namespace EM.Application.CQRS.Users.Queries.GetAuditLogsQuery;

public class GetAuditLogsQuery : IRequest<IEnumerable<AuditLog>>
{
    public int? EntityId { get; set; }
    public AuditLogType? Type { get; set; }
}