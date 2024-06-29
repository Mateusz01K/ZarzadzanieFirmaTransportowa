using Microsoft.EntityFrameworkCore;
using ZarzadzanieFirmaTransportowa.Models.AssignmentToCar;
using ZarzadzanieFirmaTransportowa.Models.Cars;
using ZarzadzanieFirmaTransportowa.Models.Trailers;
using ZarzadzanieFirmaTransportowa.Models.Users;

namespace ZarzadzanieFirmaTransportowa.Context
{
    public class CarContext : DbContext
    {
        public CarContext(DbContextOptions options) : base(options) { }

        public DbSet<CarModel> Car { get; set; }
        public DbSet<TrailerModel> Trailer { get; set; }
        public DbSet<UserModel> User { get; set; }
        public DbSet<AssignmentCarModel> AssignmentCar { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) { }
    }
}
