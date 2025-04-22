using System;
using Domain;
using MediatR;
using Persistence;

namespace Application.Academies.Commands;

public class CreateAcademy
{

public class Command : IRequest<string>
{
    public required Academy Academy { get; set; }
}
    public class Handler(AppDbContext context) : IRequestHandler<Command, string>
    {
        public async Task<string> Handle(Command request, CancellationToken cancellationToken)
        {
            context.Academies.Add(request.Academy);
            await context.SaveChangesAsync(cancellationToken);
            return request.Academy.Id;
        }
    }
}
