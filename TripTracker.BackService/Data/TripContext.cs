using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TripTracker.BackService.Models;

namespace TripTracker.BackService.Data
{

    public class TripContext :DbContext
    {
        public TripContext(DbContextOptions<TripContext> options):base (options)
        {

        }
        public TripContext()
        {

        }
        public DbSet<Trip> Trips { get; set; }

        public static void SeedData(IServiceProvider serviceProvider)
        {
            

           using( var serviceScope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<TripContext>();
                context.Database.EnsureCreated();

                context.Trips.AddRange(new Trip[]
                {
                new Trip
                {
                    Id = 1,
                    Name = "Maldivs Tour",
                    StartDate = new DateTime(2018, 10, 5),
                    EndDate = new DateTime(2018, 10, 8)
                },
                new Trip
                {
                    Id = 2,
                    Name = "Dubai Tour",
                    StartDate = new DateTime(2018, 12, 20),
                    EndDate = new DateTime(2018, 12, 26)
                },
                new Trip
                {
                    Id = 3,
                    Name = "Singapore Tour",
                    StartDate = new DateTime(2019, 1, 20),
                    EndDate = new DateTime(2018, 1, 24)
                }
                }
                    );
                context.SaveChanges();
            }
        }
    }
   
}
