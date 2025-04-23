using System;
using Application.Academies.DTOs;
using Application.Core;
using AutoMapper;
using Domain;
using FluentValidation;
using MediatR;
using Persistence;

namespace Application.Academies.Commands;

public class CreateAcademy
{

public class Command : IRequest<Result<string>>
{
    public required CreateAcademyDto AcademyDto { get; set; }
}
    public class Handler(AppDbContext context, IMapper mapper) : IRequestHandler<Command, Result<string>>
    {
        public async Task<Result<string>> Handle(Command request, CancellationToken cancellationToken)
        {
            var academy = mapper.Map<Academy>(request.AcademyDto);
            context.Academies.Add(academy);
             var result =  await context.SaveChangesAsync(cancellationToken) > 0;
            if(!result) return Result<string>.Failure("Failed to create the academy",400);

            return Result<string>.Success(academy.Id);
        }
    }
}
