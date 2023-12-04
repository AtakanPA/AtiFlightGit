using AtiFlight.Models;
using Microsoft.EntityFrameworkCore;
 // Bu öznitelik, Context sınıfının bir DbContext olduğunu belirtir
namespace AtiFlight.Context
{
    public class MyContext:DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(@"Server=localhost;Port=5432;Database=AtiFlightDb;User Id=postgres;Password=6436");
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Seat> Seats { get; set; }
        public DbSet<FlyRoute> FlyRoutes { get; set; }
        public DbSet<Flight> Flights{ get; set; }
        public DbSet<AirPlane> AirPlanes { get; set; }
        public DbSet<Iller> Illers { get; set; }



    }
}
