using HRIntegrationService.Entity;
using HRIntegrationService.DTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HRIntegrationService.CQRS.Queries
{
   
public class GetCustomerByIdQueryHandler : IRequestHandler<GetCustomerByIdQuery, CustomerDto>
{
    private readonly AppDbContext _context;


    public GetCustomerByIdQueryHandler(AppDbContext context)
    {
        _context = context;
    }

    public async Task<CustomerDto?> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
    {
        var customer = await _context.Customers
            .AsNoTracking()
            .FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);

        if (customer == null)
            return null;

        return new CustomerDto
        {
            Id = customer.Id,
            FirstName = customer.FirstName,
            LastName = customer.LastName
        };
    }
}
} 