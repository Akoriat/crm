using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using crm.Models;

namespace crm.Data
{
    public class crmContext : DbContext
    {
        public crmContext (DbContextOptions<crmContext> options)
            : base(options)
        {
        }

        public DbSet<crm.Models.Classroom> Classroom { get; set; } = default!;
        public DbSet<crm.Models.Exercise> Exercise { get; set; } = default!;
        public DbSet<crm.Models.Group> Group { get; set; } = default!;
        public DbSet<crm.Models.Student> Student { get; set; } = default!;
        public DbSet<crm.Models.Subject> Subject { get; set; } = default!;
        public DbSet<crm.Models.Teacher> Teacher { get; set; } = default!;
    }
}
