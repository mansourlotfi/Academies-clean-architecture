using System;
using AutoMapper;
using Domain;
using MediatR;
using Persistence;

namespace Application.Academies.Commands;

public class EditAcademy
{
    public  class Command : IRequest
    {
        public required Academy Academy { get; set; }
    }

    public class Handler(AppDbContext context, IMapper mapper) : IRequestHandler<Command>
    {
        public async Task Handle(Command request, CancellationToken cancellationToken)
        {
            var academy = await context.Academies.FindAsync([request.Academy.Id],cancellationToken) 
                ?? throw new Exception("Cannot find academy");
            
            // academy.Name = request.Academy.Name;
            mapper.Map(request.Academy,academy);

            await context.SaveChangesAsync(cancellationToken);
        }
    }
}
