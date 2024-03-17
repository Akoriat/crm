using System.ComponentModel.DataAnnotations;

namespace crm.Models
{
    public class Subject
    {
        [Key]
        public int SubjectId { get; set; }
        [Required]
        public string SubjectName { get; set; }
        public virtual ICollection<Exercise>? Exercises { get; set; }
    }
}
