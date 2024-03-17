using System.ComponentModel.DataAnnotations;

namespace crm.Models
{
    public class Teacher
    {
        [Key]
        public int TeacherId { get; set; }
        [Required]
        public string TeacherFirstName { get; set; }
        [Required]
        public string TeacherSurname { get; set; }
        [Required]
        public string TeacherPatronymic { get; set; }
        public virtual ICollection<Exercise>? Exercises { get; set; }
    }
}
