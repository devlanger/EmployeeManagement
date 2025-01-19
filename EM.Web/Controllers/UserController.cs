using EM.Application.CQRS.User.Queries.SearchUserQuery;
using EM.Application.Services.Abstract;
using EM.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EM.Web.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IDataProvider<ApplicationUser> _dataProvider;
    private readonly IMediator _mediator;

    public UserController(IDataProvider<ApplicationUser> dataProvider, IMediator mediator)
    {
        _dataProvider = dataProvider;
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetUsers()
    {
        var e = await _dataProvider.GetAllAsync();
        return Ok(e);
    }
    
    // [HttpPost]
    // public async Task<IAsyncResult> AddEmployee([FromBody] string test)
    // {
    //     await _mediator.Send(new AddEmployeeCommand());
    //     return Task.CompletedTask;
    // }
    
    
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