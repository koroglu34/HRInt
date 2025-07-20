using HRIntegrationService.Application.Commands;
using HRIntegrationService.CQRS.Queries;
using HRIntegrationService.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HRIntegrationService.Controllers
{
    [ApiController]
[Route("api/[controller]")]
public class CustomersController : ControllerBase
{
    private readonly IMediator _mediator;

    public CustomersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<ActionResult<CustomerDto>> Create([FromBody] CreateCustomerCommand command)
    {
        var result = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var query = new GetCustomerByIdQuery(id);
        var customer = await _mediator.Send(query);

        if (customer == null)
            return NotFound();

        return Ok(customer);
    }
}
} 