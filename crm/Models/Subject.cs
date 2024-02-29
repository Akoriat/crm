namespace crm.Models
{
    public class Subject
    {
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public virtual IEnumerable<TeacherAndSubject> TeacherAndSubjects { get; set; }
    }
}
