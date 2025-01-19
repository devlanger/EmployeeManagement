using EM.Application.CQRS.User.Queries.GetUsersQuery;
using EM.Application.CQRS.User.Queries.SearchUserQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EM.Web.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController(ISender mediator) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var e = await mediator.Send(new GetUsersQuery());
        return Ok(e);
    }
    
    [HttpGet("search")]
    public async Task<IActionResult> Search([FromQuery] string query)
    {
        var result = await mediator
            .Send(new SearchUserQuery() { Query = query });

        return Ok(result);
    }
}