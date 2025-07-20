//using MediatR;
//using HRIntegrationService.Entity;

//namespace HRIntegrationService.Application.Customers.Commands.CreateCustomer;
//{
    // public class DeleteUserCommand : IRequest<bool>
    // {
    //     public int Id { get; set; }
    // }

    // public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, bool>
    // {
    //     private readonly AppDbContext _context;
    //     public DeleteUserCommandHandler(AppDbContext context)
    //     {
    //         _context = context;
    //     }
    //     public async Task<bool> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    //     {
    //         var user = await _context.Users.FindAsync(new object[] { request.Id }, cancellationToken);
    //         if (user == null) return false;
    //         _context.Users.Remove(user);
    //         await _context.SaveChangesAsync(cancellationToken);
    //         return true;
    //     }
    // }
//} 