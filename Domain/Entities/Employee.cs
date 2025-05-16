using Domain.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("TblEmployees")]
    public class Employee : AuditableEntity
    {
        [Key]
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Position { get; set; }
        public int AgencyId { get; set; }
        public Agency Agency { get; set; } = null!;

        public ICollection<BookingEmployeePerDay> BookingEmployeePerDay { get; set; } = new List<BookingEmployeePerDay>();
        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
    }
}
