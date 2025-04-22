using System;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Academies.Queries;

public class GetAcademyList
{
    public class Query : IRequest<List<Academy>> {}

    public class Handler(AppDbContext context) : IRequestHandler<Query, List<Academy>>
    {
        public async Task<List<Academy>> Handle(Query request, CancellationToken cancellationToken)
        {
            return await context.Academies.ToListAsync(cancellationToken);
        }
    }

}
