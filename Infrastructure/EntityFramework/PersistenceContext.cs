using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.EntityFramework
{
    public class PersistenceContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public PersistenceContext(DbContextOptions<PersistenceContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }
        public DbSet<Agency> Agencies { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<BookingEmployeePerDay> BookingEmployeesPerDay { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<VehicleType> VehicleTypes { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            if(modelBuilder == null)
            {
                return;
            }
            modelBuilder.HasDefaultSchema(_configuration.GetConnectionString("BaseSchema"));
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PersistenceContext).Assembly);

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Agency)
                .WithMany(a => a.Employees)
                .HasForeignKey(e => e.AgencyId);

            modelBuilder.Entity<Vehicle>()
                .HasOne(v => v.VehicleType)
                .WithMany(t => t.Vehicles)
                .HasForeignKey(v => v.VehicleTypeId);

            modelBuilder.Entity<Booking>()
                .HasOne(b => b.Client)
                .WithMany(c => c.Bookings)
                .HasForeignKey(b => b.ClientId);

            modelBuilder.Entity<Booking>()
                .HasOne(b => b.Vehicle)
                .WithMany(v => v.Bookings)
                .HasForeignKey(b => b.VehicleId);

            modelBuilder.Entity<Booking>()
                .HasOne(b => b.Employee)
                .WithMany(c => c.Bookings)
                .HasForeignKey(b => b.ClientId);

            modelBuilder.Entity<BookingEmployeePerDay>()
                .HasOne(be => be.Employee)
                .WithMany(e => e.BookingEmployeePerDay)
                .HasForeignKey(be => be.EmployeeId);
        }

    }
}
