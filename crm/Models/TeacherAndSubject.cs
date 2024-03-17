namespace crm.Models
{
    public class TeacherAndSubject
    {
        public int TeacherAndSubjectId { get; set; }
        public int TeacherId { get; set; }
        public int SubjectId { get; set; }
        public virtual Teacher? Teacher { get; set; }
        public virtual Subject? Subject { get; set; }

        public virtual IEnumerable<Exercise>? Exercises { get; set; }

    }
}
