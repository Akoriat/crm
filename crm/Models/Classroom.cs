using System.ComponentModel.DataAnnotations;

namespace crm.Models
{
    public class Classroom
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string ClassroomName { get; set; }

        public virtual IEnumerable<Exercise>? Exercises { get; set; }
    }
}
