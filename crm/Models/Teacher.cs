namespace crm.Models
{
    public class Teacher
    {
        public int TeacherId { get; set; }
        public string TeacherFirstName { get; set; }
        public string TeacherSurname { get; set; }
        public string TeacherPatronymic { get; set; }

        public virtual IEnumerable<TeacherAndSubject> TeacherAndSubjects { get; set; }
    }
}
