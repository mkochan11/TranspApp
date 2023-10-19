using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class AppDbContextSeed
    {
        public static async Task SeedAsync(AppDbContext appDbContext)
        {
            try
            {
                if (appDbContext.Database.IsSqlServer())
                {
                    appDbContext.Database.Migrate();
                }

                if(!await appDbContext.VehicleTypes.AnyAsync())
                {
                  
                    await appDbContext.VehicleTypes.AddRangeAsync(
                        GetPreconfiguredVehicleTypes());

                    await appDbContext.SaveChangesAsync();
                }

                if (!await appDbContext.Vehicles.AnyAsync())
                {
                    await appDbContext.Vehicles.AddRangeAsync(
                        GetPreconfiguredVehicles());

                    await appDbContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                await SeedAsync(appDbContext);
            }
        }

        static IEnumerable<VehicleType> GetPreconfiguredVehicleTypes()
        {
            return new List<VehicleType>
            {
                new("Pick-Up", 100),
                new("Van", 200),
                new("Cargo van", 300),
                new("Small truck", 400),
                new("Truck", 500),
                new("Heavy truck", 1000)
            };
        }

        static IEnumerable<Vehicle> GetPreconfiguredVehicles()
        {
            return new List<Vehicle>
            {
                new(3, "Fiat", "Ducato", 2014, "AB12345", 1500),
                new(2, "Volkswagen", "Caddy", 2018, "CD11111", 800),
                new(5, "Renault", "Midlum", 2007, "XYZ123", 6000),
                new(6, "Renault", "GamaT460", 2015, "HT45378", 10000)
            };
        }
    }
}
