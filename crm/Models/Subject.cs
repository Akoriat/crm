using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace crm.Models
{
    [Index(nameof(SubjectName), IsUnique = true)]
    public class Subject
    {
        [Key]
        public int SubjectId { get; set; }
        [Required]
        public string SubjectName { get; set; }
        public virtual ICollection<Exercise>? Exercises { get; set; }
    }
}
