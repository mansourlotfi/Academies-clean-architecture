using System;
using Domain;

namespace Persistence;

public class DbInitializer
{
    public static async Task SeedData(AppDbContext context)
    {
        if(context.Academies.Any()) return;

        var academies = new List<Academy>
        {
            new() 
            { 
            Name ="zabaninoacademy",
            Address="رشت - نامجو",
            ContactInfo="+989117196381",
            CreatedDate=DateTime.Now.AddMonths(-1),
            UpdatedDate=DateTime.Now.AddDays(-2),
            City="Rasht",
            IsActive=true,
            Latitude=64.06453,
            Longitude=-90.28901
            },
             new() 
            { 
            Name ="زبانی نو",
            Address="رشت - فلکه گاز",
            ContactInfo="+989117196381",
            CreatedDate=DateTime.Now.AddMonths(-1),
            UpdatedDate=DateTime.Now.AddDays(-2),
            City="Rasht",
            IsActive=true,
            Latitude=64.06453,
            Longitude=-90.28901
            }
        };
        context.Academies.AddRange(academies);
        //    foreach (var item in academies)
        //     {
        //         context.Academies.Add(item);
        //     }
        await context.SaveChangesAsync();
    }

}
