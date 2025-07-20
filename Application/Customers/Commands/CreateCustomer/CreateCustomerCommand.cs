using MediatR;
using HRIntegrationService.DTOs;

namespace HRIntegrationService.Application.Commands;

public class CreateCustomerCommand : IRequest<CustomerDto>
{
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string Email { get; set; } = default!;
}
