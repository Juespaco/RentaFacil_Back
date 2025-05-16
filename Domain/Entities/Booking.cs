using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("TblBookings")]
    public class Booking
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public int ClientId { get; set; }
        public Client Client { get; set; } = null!;

        public int VehicleId { get; set; }
        public Vehicle Vehicle { get; set; } = null!;

        public int EmployeeId { get; set; }
        public Employee Employee { get; set; } = null!;
    }
}
