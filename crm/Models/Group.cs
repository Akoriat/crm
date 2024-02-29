
namespace crm.Models
{
    public class Group
    {
        public int GroupId { get; set; }
        public string GroupName { get; set; }
        public virtual ICollection<Student> Students { get; set; }
        public virtual ICollection<Exercise> Exercises { get; set; }
    }
}
