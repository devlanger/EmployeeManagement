using EM.Application.CQRS.Team.Queries.GetTeamsQuery;
using EM.Application.CQRS.User.Queries.SearchUserQuery;
using EM.Application.Services.Abstract;
using EM.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EM.Web.Controllers;

[ApiController]
[Route("api/[controller]")]
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