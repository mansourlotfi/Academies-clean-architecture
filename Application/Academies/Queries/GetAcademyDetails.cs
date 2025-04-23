using System;
using Application.Core;
using Domain;
using MediatR;
using Persistence;

namespace Application.Academies.Queries;

public class GetAcademyDetails
{
    // public class Query : IRequest<Academy>
    public class Query : IRequest<Result<Academy>>
    {
        public required string Id { get; set; }
    }

    public class Handler(AppDbContext context) : IRequestHandler<Query, Result<Academy>>
    {
      
        public async Task<Result<Academy>> Handle(Query request, CancellationToken cancellationToken)
        {
        var academy = await context.Academies.FindAsync([request.Id],cancellationToken);
        if (academy == null) return Result<Academy>.Failure("Academy not found",404);
        
        return Result<Academy>.Success(academy);        
        }
    }

}
