using EM.Application.CQRS.User.Queries.SearchUserQuery;
using EM.Application.CQRS.Users.Commands.UpdateUserCommand;
using EM.Application.CQRS.Users.Queries.GetEmployeeMaxSalary;
using EM.Application.CQRS.Users.Queries.GetUserQueryById;
using EM.Application.CQRS.Users.Queries.GetUsersByNameQuery;
using EM.Application.CQRS.Users.Queries.GetUsersQuery;
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
    
    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateUserCommand command)
    {
        await mediator.Send(command);
        return Ok();
    }

    public async Task<IActionResult> GetMaxEmployeeSalary()
    {
        var result = await mediator.Send(new GetEmployeeMaxSalary()
        {
            
        });
        return Ok();
    }
    
    [HttpGet("{userId}")]
    public async Task<IActionResult> GetById(string userId)
    {
        var e = await mediator.Send(new GetUserByIdQuery()
        {
            Id = userId
        });
        
        return Ok(e);
    }
    
    [HttpGet("name/{name}")]
    public async Task<IActionResult> GetByName(string name)
    {
        var e = await mediator.Send(new GetUsersByNameQuery()
        {
            Name = name
        });
        
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