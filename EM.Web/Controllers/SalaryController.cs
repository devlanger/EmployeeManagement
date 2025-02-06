using EM.Application.CQRS.Salaries.Commands.GiveSalaryBonus;
using EM.Application.CQRS.Salaries.Queries.GetSalaryStatisticsQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EM.Web.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SalaryController : ControllerBase
{
    private readonly IMediator _mediator;

    public SalaryController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var e = await _mediator.Send(new GetSalaryStatisticsQuery());
        return Ok(e);
    }

    [HttpPost("{employeeId}")]
    public async Task<IActionResult> GiveBonus(string employeeId)
    {
        await _mediator.Send(new GiveSalaryBonusCommand(employeeId));
        return Ok();
    }
}