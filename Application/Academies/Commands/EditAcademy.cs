using System;
using Application.Core;
using AutoMapper;
using Domain;
using MediatR;
using Persistence;

namespace Application.Academies.Commands;

public class EditAcademy
{
    public  class Command : IRequest<Result<Unit>>
    {
        public required Academy Academy { get; set; }
    }

    public class Handler(AppDbContext context, IMapper mapper) : IRequestHandler<Command, Result<Unit>>
    {
        public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
        {
            var academy = await context.Academies.FindAsync([request.Academy.Id],cancellationToken);
            if(academy == null) return Result<Unit>.Failure("Academy not found",404);
         

            
            // academy.Name = request.Academy.Name;
            mapper.Map(request.Academy,academy);

            // await context.SaveChangesAsync(cancellationToken);
            var result =  await context.SaveChangesAsync(cancellationToken) > 0;
            if(!result) return Result<Unit>.Failure("Failed to update the academy",400);

            return Result<Unit>.Success(Unit.Value);
        }
    }
}
