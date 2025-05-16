using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("TblVehicles")]
    public class Vehicle
    {
        public int Id { get; set; }
        public string PlateNumber { get; set; } = null!;
        public string Brand { get; set; } = null!;
        public string Model { get; set; } = null!;
        public int Year { get; set; }
        public int VehicleTypeId { get; set; }
        public VehicleType VehicleType { get; set; }

        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
    }
}
