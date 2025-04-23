using System;
using Application.Academies.DTOs;
using AutoMapper;
using Domain;
using FluentValidation;
using MediatR;
using Persistence;

namespace Application.Academies.Commands;

public class CreateAcademy
{

public class Command : IRequest<string>
{
    public required CreateAcademyDto AcademyDto { get; set; }
}
    public class Handler(AppDbContext context, IMapper mapper) : IRequestHandler<Command, string>
    {
        public async Task<string> Handle(Command request, CancellationToken cancellationToken)
        {
            var academy = mapper.Map<Academy>(request.AcademyDto);
            context.Academies.Add(academy);
            await context.SaveChangesAsync(cancellationToken);
            return academy.Id;
        }
    }
}
