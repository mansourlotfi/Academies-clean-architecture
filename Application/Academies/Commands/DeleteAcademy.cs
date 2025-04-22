using System;
using MediatR;
using Persistence;

namespace Application.Academies.Commands;

public class DeleteAcademy
{
      public  class Command : IRequest
    {
        public required string Id { get; set; }
    }

    public class Handler(AppDbContext context) : IRequestHandler<Command>
    {
        public async Task Handle(Command request, CancellationToken cancellationToken)
        {
            var academy = await context.Academies.FindAsync([request.Id],cancellationToken) 
                ?? throw new Exception("Cannot find academy");
            context.Remove(academy);

            await context.SaveChangesAsync(cancellationToken);
        }
    }
}
