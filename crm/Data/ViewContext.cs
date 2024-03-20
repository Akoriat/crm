using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using crm.Models;

namespace crm.Data
{
    public class ViewContext : DbContext
    {
        public ViewContext(DbContextOptions<ViewContext> options)
            : base(options)
        {
        }

        public DbSet<Classroom> Classroom { get; set; } = default!;
        public DbSet<Exercise> Exercise { get; set; } = default!;
        public DbSet<Group> Group { get; set; } = default!;
        public DbSet<Student> Student { get; set; } = default!;
        public DbSet<Subject> Subject { get; set; } = default!;
        public DbSet<Teacher> Teacher { get; set; } = default!;
    }
}
