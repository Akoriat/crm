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
        [DataType(DataType.Time)]
        public DateTime Time { get; set; }

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
                if (value is DateTime time)
                {
                    // Проверяем, что значение соответствует одному из заданных времен
                    return time.TimeOfDay == new TimeSpan(8, 20, 0) ||
                           time.TimeOfDay == new TimeSpan(10, 00, 0) ||
                           time.TimeOfDay == new TimeSpan(12, 05, 0) ||
                           time.TimeOfDay == new TimeSpan(13, 50, 0) ||
                           time.TimeOfDay == new TimeSpan(15, 35, 0);
                }

                return false;
            }
        }
//        8:20 - 9:50 						
//10:00 - 11:35 						
//12:05 - 13:40 						
//13:50 - 15:25 						
//15:35 - 17:10 	
    }
}
