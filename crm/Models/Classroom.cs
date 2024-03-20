using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace crm.Models
{
    [Index(nameof(ClassroomName), IsUnique = true)]
    public class Classroom
    {
        [Key]
        public int ClassroomId { get; set; }
        [Required]
        [ThreeDigitNumber]
        public string ClassroomName { get; set; }

        public virtual IEnumerable<Exercise>? Exercises { get; set; }
        public class ThreeDigitNumberAttribute : ValidationAttribute
        {
            public override bool IsValid(object value)
            {
                if (value is string groupName)
                {
                    string pattern = @"^\d{3}[а-в]$";
                    if (int.TryParse(groupName, out int number))
                    {
                        return number >= 100 && number <= 999;
                    }
                    else if (Regex.IsMatch(groupName, pattern))
                    {
                        return true;
                    }
                }

                return false;
            }
        }
    }
}
