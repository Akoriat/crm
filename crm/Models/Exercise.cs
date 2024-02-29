using System.Text.RegularExpressions;

namespace crm.Models
{
    public class Exercise
    {
        public int ExerciseId { get; set; }
        public int SubjectID { get; set; }
        public int TeacherID { get; set; }
        public int ClassroomID { get; set; }
        public int GroupID { get; set; }

        public DateTime Date { get; set; }

        public virtual Subject Subject { get; set; }
        public virtual Teacher Teacher { get; set; }
        public virtual Group Group { get; set; }

        public virtual Classroom Classroom { get; set; }
    }
}
