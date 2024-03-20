using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Text.RegularExpressions;

namespace crm.Models
{
    [Index(nameof(RecordBook), IsUnique = true)]
    public class Student
    {
        [Key]
        public int StudentId { get; set; }
        [Required]
        public string StudentFirstName { get; set; }
        [Required]
        public string StudentSurname { get; set; }
        [Required]
        public string StudentPatronymic { get; set; }
        [Required]
        [StringLength(8, ErrorMessage = "Длина строки должна быть ровно 8 символов")]
        [MinLength(8, ErrorMessage = "Длина строки должна быть ровно 8 символов")]
        public string RecordBook { get; set; }

        [Required]
        public int GroupId { get; set; }
        public virtual Group? Group { get; set; }
    }
}
