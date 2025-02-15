using AutoMapper;
using EM.Application.Abstract.Services;
using EM.Core.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EM.Application.CQRS.Users.Queries.GetAuditLogsQuery;

public class GetAuditLogsQueryHandler(IRepository<AuditLog> auditLogsRepository, IMapper mapper) 
    : IRequestHandler<GetAuditLogsQuery, IEnumerable<AuditLog>>
{
    public async Task<IEnumerable<AuditLog>> Handle(GetAuditLogsQuery request, CancellationToken cancellationToken)
    {
        var auditLogs = auditLogsRepository.Query()
            .AsNoTracking();

        if (request.EntityId is not null)
        {
            auditLogs = auditLogs.Where(x => x.EntityId == request.EntityId);
        }

        if (request.Type is not null)
        {
            auditLogs = auditLogs.Where(x => x.Type == request.Type);
        }
        
        return await auditLogs.ToListAsync(cancellationToken: cancellationToken);
    }
}