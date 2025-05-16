using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("TblVehicleTypes")]
    public class VehicleType
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Vehicle> Vehicles { get; set; } = new List<Vehicle>();
    }
}
