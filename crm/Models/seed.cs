using crm.Data;
using Microsoft.EntityFrameworkCore;


namespace crm.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new crmContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<crmContext>>()))
        {
            if (context == null || context.Classroom == null)
            {
                throw new ArgumentNullException("Null RazorPagesMovieContext");
            }

            // Look for any movies.
            if (context.Classroom.Any())
            {
                return;   // DB has been seeded
            }

            context.Classroom.AddRange(
                new Classroom
                {
                    ClassroomName = "310"
                },

                new Classroom
                {
                    ClassroomName = "215"
                },

                new Classroom
                {
                    ClassroomName = "216"
                },

                new Classroom
                {
                    ClassroomName = "217"
                }
            );
            context.SaveChanges();
        }
    }
}