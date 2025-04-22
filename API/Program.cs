using Microsoft.EntityFrameworkCore;
using Persistence;

var builder = WebApplication.CreateBuilder(args);
// ConfigurationManager configuration = builder.Configuration; // allows both to access and to set up the config
// IWebHostEnvironment environment = builder.Environment;

// Add services to the container.

builder.Services.AddControllers();
// string connString;
// if (environment.IsDevelopment())
//     connString = configuration.GetConnectionString("DefaultConnection");
// else
// {
//     // Use connection string provided at runtime.
//     connString = Environment.GetEnvironmentVariable("DefaultConnection");

// }
builder.Services.AddDbContext<AppDbContext>(opt => 
{
     opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
}
);

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
// builder.Services.AddOpenApi();


var app = builder.Build();

// Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
//     app.MapOpenApi();
// }

// app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;
try
{
    var context = services.GetRequiredService<AppDbContext>();
    await context.Database.MigrateAsync();
    await DbInitializer.SeedData(context);
}
catch (Exception ex)
{
    var logger = services.GetRequiredService<ILogger<Program>>();
    logger.LogError(ex,"An error occured during migration.");
}


app.Run();
