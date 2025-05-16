using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("TblBookingEmployeePerDays")]
    public class BookingEmployeePerDay
    {
        public int Id { get; set; }
        public DateTime day { get; set; }
        public int BookingsNumber { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; } = null!;
    }
}
