using HRIntegrationService.DTOs;
using HRIntegrationService.Entity;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace HRIntegrationService.CQRS.Queries
{

    public class GetCustomerByIdQuery : IRequest<CustomerDto>
    {
        public int Id { get; set; }

        public GetCustomerByIdQuery(int id)
        {
            Id = id;
        }
    }
} 