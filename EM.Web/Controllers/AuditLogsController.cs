using EM.Application.CQRS.Users.Queries.GetAuditLogsQuery;
using EM.Core.Enums;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EM.Web.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuditLogsController(ISender mediator) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Get(AuditLogType? type, int? entityId)
    {
        var e = await mediator.Send(new GetAuditLogsQuery()
        {
            Type = type,
            EntityId = entityId
        });
        return Ok(e);
    }
}