﻿using System.ComponentModel.DataAnnotations;

namespace crm.Models
{
    public class Classroom
    {
        public int Id { get; set; }
        public string ClassroomName { get; set; }

        public virtual IEnumerable<Exercise> Exercises { get; set; }
    }
}