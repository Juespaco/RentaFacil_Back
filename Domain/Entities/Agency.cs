using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("TblAgencies")]
    public class Agency
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }

        public ICollection<Employee> Employees { get; set; } = new List<Employee>();
    }
}