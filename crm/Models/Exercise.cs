using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;


namespace crm.Models
{
    public class Exercise
    {
        [Key]
        public int ExerciseId { get; set; }
        [Required]
        public int SubjectID { get; set; }
        [Required]
        public int TeacherID { get; set; }
        [Required]
        public int ClassroomID { get; set; }
        [Required]
        public int GroupID { get; set; }

        [Required]
        [TimeRange]
        public TimeSpan Time { get; set; }

        [Required]
        public DayOfWeek DayOfWeek { get; set; }

        public virtual Subject? Subject { get; set; }
        public virtual Teacher? Teacher { get; set; }
        public virtual Group? Group { get; set; }

        public virtual Classroom? Classroom { get; set; }

        public class TimeRangeAttribute : ValidationAttribute
        {
            public override bool IsValid(object value)
            {
                if (value is TimeSpan time)
                {
                    // Проверяем, что значение соответствует одному из заданных времен
                    return time == new TimeSpan(8, 20, 0) ||
                           time == new TimeSpan(10, 00, 0) ||
                           time == new TimeSpan(12, 05, 0) ||
                           time == new TimeSpan(13, 50, 0) ||
                           time == new TimeSpan(15, 35, 0);
                }

                return false;
            }
        }
        public override string ToString()
        {
            return $"Предмет: {Subject.SubjectName}\nПреподаватель: {Teacher.TeacherSurname} {Teacher.TeacherFirstName} {Teacher.TeacherPatronymic}\nАудитория: {Classroom.ClassroomName}\nГруппа: {Group.GroupName}";
        }


    }
}
