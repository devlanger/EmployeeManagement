using EM.Application.CQRS.Teams.Queries.GetTeamMembersQuery;
using EM.Application.CQRS.Teams.Queries.GetTeamQuery;
using EM.Application.CQRS.Teams.Queries.GetTeamsQuery;
using EM.Application.CQRS.User.Queries.SearchUserQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EM.Web.Controllers;

[ApiController]
[Route("api/[controller]")]
//[Authorize(Roles = $"{IdentityConstants.TEAMS_VIEW_ROLE_NAME}")]
public class TeamController : ControllerBase
{
    private readonly IMediator _mediator;

    public TeamController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var e = await _mediator.Send(new GetTeamsQuery());
        return Ok(e);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var e = await _mediator.Send(new GetTeamQuery(id));
        return Ok(e);
    }
    
    
    [HttpGet("members/{id}")]
    public async Task<IActionResult> GetTeamMembers(int id)
    {
        var e = await _mediator.Send(new GetTeamMembersQuery(id));
        return Ok(e);
    }
    
    [HttpGet("search")]
    public async Task<IActionResult> Search([FromQuery] string query)
    {
        var result = await _mediator.Send(new SearchUserQuery()
        {
            Query = query
        });

        return Ok(result);
    }
}