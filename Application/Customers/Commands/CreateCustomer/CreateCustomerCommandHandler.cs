using MediatR;
using HRIntegrationService.Entity;
using HRIntegrationService.DTOs;

namespace HRIntegrationService.Application.Commands;

public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, CustomerDto>
{
    private readonly AppDbContext _context;

    public CreateCustomerCommandHandler(AppDbContext context)
    {
        _context = context;
    }

    public async Task<CustomerDto> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer = new Customer
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email
        };

        _context.Customers.Add(customer);
        await _context.SaveChangesAsync(cancellationToken);

        return new CustomerDto
        {
            Id = customer.Id,
            FirstName = customer.FirstName
        };
    }
}
