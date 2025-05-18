using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("TblActivities")]
    public class Activity
    {
        [Key]
        public int Id { get; set; }
        public TimeSpan ScheduledTime { get; set; }
        public bool RunNow { get; set; }
        public DateTime? LastExecuted { get; set; }

    }
}
