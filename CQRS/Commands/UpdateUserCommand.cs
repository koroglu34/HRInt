using HRIntegrationService.Models;
using MediatR;

namespace HRIntegrationService.CQRS.Commands
{
    public class UpdateUserCommand : IRequest<User?>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string? Phone { get; set; }
    }

    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, User?>
    {
        private readonly AppDbContext _context;
        public UpdateUserCommandHandler(AppDbContext context)
        {
            _context = context;
        }
        public async Task<User?> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.FindAsync(new object[] { request.Id }, cancellationToken);
            if (user == null) return null;
            user.FirstName = request.FirstName;
            user.LastName = request.LastName;
            user.Email = request.Email;
            user.Phone = request.Phone;
            await _context.SaveChangesAsync(cancellationToken);
            return user;
        }
    }
} 