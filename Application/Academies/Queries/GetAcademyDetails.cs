using System;
using Domain;
using MediatR;
using Persistence;

namespace Application.Academies.Queries;

public class GetAcademyDetails
{
    public class Query : IRequest<Academy>
    {
        public required string Id { get; set; }
    }

    public class Handler(AppDbContext context) : IRequestHandler<Query, Academy>
    {
      
        public async Task<Academy> Handle(Query request, CancellationToken cancellationToken)
        {
        var academy = await context.Academies.FindAsync([request.Id],cancellationToken);
        if (academy == null) throw new Exception("Academy not found");
        return academy;        
        }
    }

}
