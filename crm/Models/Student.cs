using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Text.RegularExpressions;

namespace crm.Models
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }
        [Required]
        public string StudentFirstName { get; set;}
        [Required]
        public string StudentSurname { get; set;}
        [Required]
        public string StudentPatronymic { get; set;}
        [Required]
        public string RecordBook { get; set;}

        [Required]
        public int GroupId { get; set; }
        public virtual Group? Group { get; set; }
    }
}
