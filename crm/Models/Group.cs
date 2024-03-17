
using System.ComponentModel.DataAnnotations;

namespace crm.Models
{
    public class Group
    {
        [Key]
        public int GroupId { get; set; }
        public string GroupName { get; set; }
        public virtual ICollection<Student>? Students { get; set; }
        public virtual ICollection<Exercise>? Exercises { get; set; }
    }
}
