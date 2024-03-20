using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileSystemGlobbing.Internal;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace crm.Models
{
    [Index(nameof(GroupName), IsUnique = true)]
    public class Group
    {
        [Key]
        public int GroupId { get; set; }

        [ThreeDigitNumber]
        public string GroupName { get; set; }
        public virtual ICollection<Student>? Students { get; set; }
        public virtual ICollection<Exercise>? Exercises { get; set; }
        public class ThreeDigitNumberAttribute : ValidationAttribute
        {
            public override bool IsValid(object value)
            {
                if (value is string groupName)
                {
                    if (int.TryParse(groupName, out int number))
                    {
                        return number >= 100 && number <= 999;
                    }
                }

                return false;
            }
        }
    }
}
