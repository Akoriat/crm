namespace crm.Models
{
    public class Association
    {
        public IEnumerable<Student>? Students { get; set; }
        public IEnumerable<Group>? Groups { get; set; }
        public IEnumerable<Teacher>? Teachers { get; set; }
        public IEnumerable<Subject>? Subjects { get; set; }
        public IEnumerable<Exercise>? Exercises { get; set; }
        public IEnumerable<TeacherAndSubject>? TeacherAndSubjects { get; set; }
        public IEnumerable<Classroom>? Classrooms { get; set; }
    }
}
