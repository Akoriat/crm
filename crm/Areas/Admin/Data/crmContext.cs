using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using crm.Areas.Admin.Models;

namespace crm.Areas.Admin.Data
{
    public class crmContext : DbContext
    {
        public crmContext(DbContextOptions<crmContext> options)
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
