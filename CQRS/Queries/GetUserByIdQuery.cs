using HRIntegrationService.Models;
using MediatR;

namespace HRIntegrationService.CQRS.Queries
{
    public class GetUserByIdQuery : IRequest<User?>
    {
        public int Id { get; set; }
    }

    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, User?>
    {
        private readonly AppDbContext _context;
        public GetUserByIdQueryHandler(AppDbContext context)
        {
            _context = context;
        }
        public async Task<User?> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            return await _context.Users.FindAsync(new object[] { request.Id }, cancellationToken);
        }
    }
} 