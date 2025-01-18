using EM.Application.CQRS.Employee.Commands.AddEmployee;
using EM.Application.Services.Abstract;
using EM.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EM.Web.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmployeeController : ControllerBase
{
    private readonly IDataProvider<Employee> _dataProvider;
    private readonly IMediator _mediator;

    public EmployeeController(IDataProvider<Employee> dataProvider, IMediator mediator)
    {
        _dataProvider = dataProvider;
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetEmployees()
    {
        var e = await _dataProvider.GetAllAsync();
        return Ok(e);
    }
    
    [HttpPost]
    public async Task<IAsyncResult> AddEmployee([FromBody] string test)
    {
        await _mediator.Send(new AddEmployeeCommand());
        return Task.CompletedTask;
    }
}