using Microsoft.EntityFrameworkCore;
using ZarzadzanieFirmaTransportowa.Context;
using ZarzadzanieFirmaTransportowa.Models.AssignmentToCar;
using ZarzadzanieFirmaTransportowa.Models.Cars;
using ZarzadzanieFirmaTransportowa.Models.Trailers;
using ZarzadzanieFirmaTransportowa.Models.Users;

namespace ZarzadzanieFirmaTransportowa
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new CarContext(serviceProvider.GetRequiredService<DbContextOptions<CarContext>>()))
            {
                if (context.Car.Any())
                {
                    return;
                }
                context.Car.AddRange(
                    new CarModel()
                    {
                        Id = 1,
                        Model = "Volvo",
                        Brand = "Euro 6",
                        Power = 1000,
                        Distance = 10000.0,
                        YearOfProduction = 2020
                    }
                );
                context.SaveChanges();
            }

            using (var context = new CarContext(serviceProvider.GetRequiredService<DbContextOptions<CarContext>>()))
            {
                if (context.Trailer.Any())
                {
                    return;
                }
                context.Trailer.AddRange(
                    new TrailerModel()
                    {
                        Id = 1,
                        Model = "Volvo",
                        Brand = "Volvo",
                        Type = "Tank",
                        MaxLoad = 21000,
                        YearOfProduction = 2024
                    }
                );
                context.SaveChanges();
            }


            using (var context = new CarContext(serviceProvider.GetRequiredService<DbContextOptions<CarContext>>()))
            {
                if (context.User.Any())
                {
                    return;
                }
                context.User.AddRange(
                    new UserModel()
                    {
                        Id = 1,
                        Name = "Jan",
                        LastName = "Kowalski",
                        Email = "jankowalski@test.pl"
                    }
                );
                context.SaveChanges();
            }

            using (var context = new CarContext(serviceProvider.GetRequiredService<DbContextOptions<CarContext>>()))
            {
                if (context.AssignmentCar.Any())
                {
                    return;
                }
                context.AssignmentCar.AddRange(
                    new AssignmentCarModel()
                    {
                        Id = 1,
                        CarId = 1,
                        TrailerId = 1,
                        UserId = 1,
                        AssignmentDate = new DateTime(2024, 06, 01),
                    }
                );
                context.SaveChanges();
            }

        }
    }
}
