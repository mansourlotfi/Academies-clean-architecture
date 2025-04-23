using System;
using Application.Core;
using MediatR;
using Persistence;

namespace Application.Academies.Commands;

public class DeleteAcademy
{
      public  class Command : IRequest<Result<Unit>>
    {
        public required string Id { get; set; }
    }

    public class Handler(AppDbContext context) : IRequestHandler<Command, Result<Unit>>
    {
        public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
        {
            var academy = await context.Academies.FindAsync([request.Id],cancellationToken);
            if(academy == null) return Result<Unit>.Failure("Academy not found",404);
                
            context.Remove(academy);

           var result =  await context.SaveChangesAsync(cancellationToken) > 0;
           if(!result) return Result<Unit>.Failure("Failed to delete the academy",400);

            return Result<Unit>.Success(Unit.Value);
        }
    }
}
