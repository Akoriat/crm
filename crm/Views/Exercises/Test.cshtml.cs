using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using crm.Data;
using crm.Models;

namespace crm.Views.Exercises
{
    public class TestModel : PageModel
    {
        private readonly crm.Data.crmContext _context;

        public TestModel(crm.Data.crmContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["ClassroomID"] = new SelectList(_context.Classroom, "Id", "Id");
        ViewData["GroupID"] = new SelectList(_context.Group, "GroupId", "GroupId");
        ViewData["SubjectID"] = new SelectList(_context.Subject, "SubjectId", "SubjectId");
        ViewData["TeacherID"] = new SelectList(_context.Teacher, "TeacherId", "TeacherId");
            return Page();
        }

        [BindProperty]
        public Exercise Exercise { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Exercise.Add(Exercise);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
