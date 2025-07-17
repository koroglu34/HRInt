using HRIntegrationService.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HRIntegrationService.CQRS.Queries
{
    public class GetAllUsersQuery : IRequest<List<User>> { }

    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, List<User>>
    {
        private readonly AppDbContext _context;
        public GetAllUsersQueryHandler(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<User>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            return await _context.Users.ToListAsync(cancellationToken);
        }
    }
} 