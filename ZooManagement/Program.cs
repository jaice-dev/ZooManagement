using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ZooManagement.Data;

namespace ZooManagement
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            CreateDbIfNotExists(host);
            host.Run();
        }
        
        private static void CreateDbIfNotExists(IHost host)
        {
            using var scope = host.Services.CreateScope();
            var services = scope.ServiceProvider;

            var context = services.GetRequiredService<ZooManagementDbContext>();
            context.Database.EnsureCreated();

            if (!context.Keepers.Any())
            {
                var keepers = SampleKeepers.GetKeepers();
                context.Keepers.AddRange(keepers);
                context.SaveChanges();
            }
            
            if (!context.AnimalTypes.Any())
            {
                var animalTypes = SampleAnimalTypes.GetAnimalTypes();
                context.AnimalTypes.AddRange(animalTypes);
                context.SaveChanges();
            }
            
            if (!context.Enclosures.Any())
            {
                var enclosures = SampleEnclosures.GetEnclosures();
                context.Enclosures.AddRange(enclosures);
                context.SaveChanges();
            }

            if (!context.Animals.Any())
            {
                var animals = SampleAnimals.GetAnimals();
                context.Animals.AddRange(animals);
                context.SaveChanges();
            }

            if (!context.AnimalRecords.Any())
            {
                var records = SampleAnimalRecords.GetAnimalRecords();
                context.AnimalRecords.AddRange(records);
                context.SaveChanges();
            }
            
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
    }
}