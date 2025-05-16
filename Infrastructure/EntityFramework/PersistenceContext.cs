using Domain.Entities;
using Domain.Entities.Base;
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

            modelBuilder.Entity<Agency>().HasData(
                new Agency { Id = 1, Name = "Bogota", Address = "Cra 12 #45-67", Phone = "3001234567", CreatedBy = "seed", CreatedAt = DateTime.UtcNow },
                new Agency { Id = 2, Name = "Medellin", Address = "Cra 55 #50-67", Phone = "3001234568", CreatedBy = "seed", CreatedAt = DateTime.UtcNow }
            );

            modelBuilder.Entity<VehicleType>().HasData(
                new VehicleType { Id = 1, Name = "Sedán", CreatedBy = "seed", CreatedAt = DateTime.UtcNow },
                new VehicleType { Id = 2, Name = "SUV", CreatedBy = "seed", CreatedAt = DateTime.UtcNow },
                new VehicleType { Id = 3, Name = "Camioneta", CreatedBy = "seed", CreatedAt = DateTime.UtcNow }
            );

            modelBuilder.Entity<Vehicle>().HasData(
                new Vehicle { Id = 1, PlateNumber = "ABC123", Brand = "Toyota", Model = "Corolla", Year = 2020, VehicleTypeId = 1,BookingValuePerDay = 100000, CreatedBy = "seed", CreatedAt = DateTime.UtcNow },
                new Vehicle { Id = 2, PlateNumber = "XYZ789", Brand = "Mazda", Model = "CX-5", Year = 2022, VehicleTypeId = 2, BookingValuePerDay = 150000, CreatedBy = "seed", CreatedAt = DateTime.UtcNow }
            );

            modelBuilder.Entity<Client>().HasData(
                new Client { Id = 1, FullName = "Carlos Pérez", Email = "carlos@example.com", Phone = "3109876543", CreatedBy = "seed", CreatedAt = DateTime.UtcNow },
                new Client { Id = 2, FullName = "María Fernández", Email = "maria.fernandez@example.com", Phone = "3112345678", CreatedBy = "seed", CreatedAt = DateTime.UtcNow },
                new Client { Id = 3, FullName = "Juan Rodríguez", Email = "juan.rodriguez@example.com", Phone = "3123456789", CreatedBy = "seed", CreatedAt = DateTime.UtcNow },
                new Client { Id = 4, FullName = "Laura Méndez", Email = "laura.mendez@example.com", Phone = "3134567890", CreatedBy = "seed", CreatedAt = DateTime.UtcNow }
            );

            modelBuilder.Entity<Employee>().HasData(
                new Employee { Id = 1, FullName = "Ana Torres", Position = "Asesor", AgencyId = 1, CreatedBy = "seed", CreatedAt = DateTime.UtcNow },
                new Employee { Id = 2, FullName = "David Gómez", Position = "Asesor", AgencyId = 1, CreatedBy = "seed", CreatedAt = DateTime.UtcNow },
                new Employee { Id = 3, FullName = "Santiago Ruiz", Position = "Asesor", AgencyId = 2, CreatedBy = "seed", CreatedAt = DateTime.UtcNow },
                new Employee { Id = 4, FullName = "Camila López", Position = "Asesor", AgencyId = 2, CreatedBy = "seed", CreatedAt = DateTime.UtcNow }
            );

            modelBuilder.Entity<Booking>().HasData(
                new Booking { Id = 1, StartDate = new DateTime(2025, 6, 1), EndDate = new DateTime(2025, 6, 5), ClientId = 1, VehicleId = 1, CreatedBy = "seed", CreatedAt = DateTime.UtcNow },
                new Booking { Id = 2, StartDate = new DateTime(2025, 6, 3), EndDate = new DateTime(2025, 6, 10), ClientId = 2, VehicleId = 2, CreatedBy = "seed", CreatedAt = DateTime.UtcNow },
                new Booking { Id = 3, StartDate = new DateTime(2025, 6, 7), EndDate = new DateTime(2025, 6, 12), ClientId = 3, VehicleId = 1, CreatedBy = "seed", CreatedAt = DateTime.UtcNow },
                new Booking { Id = 4, StartDate = new DateTime(2025, 6, 10), EndDate = new DateTime(2025, 6, 15), ClientId = 4, VehicleId = 2, CreatedBy = "seed", CreatedAt = DateTime.UtcNow },
                new Booking { Id = 5, StartDate = new DateTime(2025, 6, 15), EndDate = new DateTime(2025, 6, 20), ClientId = 1, VehicleId = 1, CreatedBy = "seed", CreatedAt = DateTime.UtcNow },
                new Booking { Id = 6, StartDate = new DateTime(2025, 6, 18), EndDate = new DateTime(2025, 6, 22), ClientId = 2, VehicleId = 2, CreatedBy = "seed", CreatedAt = DateTime.UtcNow },
                new Booking { Id = 7, StartDate = new DateTime(2025, 6, 21), EndDate = new DateTime(2025, 6, 25), ClientId = 3, VehicleId = 1, CreatedBy = "seed", CreatedAt = DateTime.UtcNow },
                new Booking { Id = 8, StartDate = new DateTime(2025, 6, 26), EndDate = new DateTime(2025, 6, 30), ClientId = 4, VehicleId = 2, CreatedBy = "seed", CreatedAt = DateTime.UtcNow }
            );
        }

        public override int SaveChanges()
        {
            ApplyAuditInfo();
            return base.SaveChanges();
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            ApplyAuditInfo();
            return await base.SaveChangesAsync(cancellationToken);
        }

        private void ApplyAuditInfo()
        {
            var entries = ChangeTracker
                .Entries<AuditableEntity>();

            foreach (var entry in entries)
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.CreatedAt = DateTime.UtcNow;
                    entry.Entity.CreatedBy = "system"; 
                }
                else if (entry.State == EntityState.Modified)
                {
                    entry.Entity.ModifiedAt = DateTime.UtcNow;
                    entry.Entity.ModifiedBy = "system"; 
                }
            }
        }
    }
}
