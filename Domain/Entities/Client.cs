using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("TblClients")]
    public class Client
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
    }
}
