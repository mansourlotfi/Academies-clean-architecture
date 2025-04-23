using System;
using Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Persistence;

public class AppDbContext(DbContextOptions options):IdentityDbContext<User>(options)
{
    public required DbSet<Academy> Academies { get; set; }

}
