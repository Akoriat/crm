using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using crm.Areas.Admin.Data;
using crm.Areas.Admin.Models;

namespace crm.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ExercisesController : Controller
    {
        private readonly crmContext _context;

        public ExercisesController(crmContext context)
        {
            _context = context;
        }

        // GET: Exercises
        public async Task<IActionResult> Index()
        {
            var crmContext = _context.Exercise.Include(e => e.Classroom).Include(e => e.Group).Include(e => e.Subject).Include(e => e.Teacher);
            return View(await crmContext.ToListAsync());
        }

        // GET: Exercises/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exercise = await _context.Exercise
                .Include(e => e.Classroom)
                .Include(e => e.Group)
                .Include(e => e.Subject)
                .Include(e => e.Teacher)
                .FirstOrDefaultAsync(m => m.ExerciseId == id);
            if (exercise == null)
            {
                return NotFound();
            }

            return View(exercise);
        }

        // GET: Exercises/Create
        public IActionResult Create()
        {
            ViewData["ClassroomID"] = new SelectList(_context.Classroom, "ClassroomId", "ClassroomName");
            ViewData["GroupID"] = new SelectList(_context.Group, "GroupId", "GroupName");
            ViewData["SubjectID"] = new SelectList(_context.Subject, "SubjectId", "SubjectName");
            ViewData["TeacherID"] = new SelectList(_context.Teacher, "TeacherId", "TeacherSurname");
            return View();
        }

        // POST: Exercises/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ExerciseId,SubjectID,TeacherID,ClassroomID,GroupID,Time,DayOfWeek")] Exercise exercise)
        {
            if (ModelState.IsValid)
            {
                var oleg = from p in _context.Exercise
                           where p.GroupID != exercise.GroupID && p.ClassroomID == exercise.ClassroomID && p.DayOfWeek == exercise.DayOfWeek && p.Time == exercise.Time ||
                                 p.GroupID != exercise.GroupID && p.TeacherID == exercise.TeacherID && p.DayOfWeek == exercise.DayOfWeek && p.Time == exercise.Time ||
                                 p.GroupID == exercise.GroupID && p.ClassroomID == exercise.ClassroomID && p.DayOfWeek == exercise.DayOfWeek && p.Time == exercise.Time && p.TeacherID == exercise.TeacherID
                           select p;
                if (oleg.Count() == 0)
                {
                    _context.Add(exercise);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View(exercise);
                }
            }
            ViewData["ClassroomID"] = new SelectList(_context.Classroom, "ClassroomId", "ClassroomName", exercise.ClassroomID);
            ViewData["GroupID"] = new SelectList(_context.Group, "GroupId", "GroupName", exercise.GroupID);
            ViewData["SubjectID"] = new SelectList(_context.Subject, "SubjectId", "SubjectName", exercise.SubjectID);
            ViewData["TeacherID"] = new SelectList(_context.Teacher, "TeacherId", "TeacherSurname", exercise.TeacherID);
            return View(exercise);
        }

        // GET: Exercises/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exercise = await _context.Exercise.FindAsync(id);
            if (exercise == null)
            {
                return NotFound();
            }
            ViewData["ClassroomID"] = new SelectList(_context.Classroom, "ClassroomId", "ClassroomName", exercise.ClassroomID);
            ViewData["GroupID"] = new SelectList(_context.Group, "GroupId", "GroupName", exercise.GroupID);
            ViewData["SubjectID"] = new SelectList(_context.Subject, "SubjectId", "SubjectName", exercise.SubjectID);
            ViewData["TeacherID"] = new SelectList(_context.Teacher, "TeacherId", "TeacherSurname", exercise.TeacherID);
            return View(exercise);
        }

        // POST: Exercises/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ExerciseId,SubjectID,TeacherID,ClassroomID,GroupID,Time,DayOfWeek")] Exercise exercise)
        {
            if (id != exercise.ExerciseId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var oleg = from p in _context.Exercise
                               where p.GroupID != exercise.GroupID && p.ClassroomID == exercise.ClassroomID && p.DayOfWeek == exercise.DayOfWeek && p.Time == exercise.Time ||
                                     p.GroupID != exercise.GroupID && p.TeacherID == exercise.TeacherID && p.DayOfWeek == exercise.DayOfWeek && p.Time == exercise.Time ||
                                     p.GroupID == exercise.GroupID && p.ClassroomID == exercise.ClassroomID && p.DayOfWeek == exercise.DayOfWeek && p.Time == exercise.Time && p.TeacherID == exercise.TeacherID
                               select p;
                    if (oleg.Count() == 0)
                    {
                        _context.Update(exercise);
                        await _context.SaveChangesAsync();
                    }
                    else
                    {
                        return View(exercise);
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExerciseExists(exercise.ExerciseId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClassroomID"] = new SelectList(_context.Classroom, "ClassroomId", "ClassroomName", exercise.ClassroomID);
            ViewData["GroupID"] = new SelectList(_context.Group, "GroupId", "GroupName", exercise.GroupID);
            ViewData["SubjectID"] = new SelectList(_context.Subject, "SubjectId", "SubjectName", exercise.SubjectID);
            ViewData["TeacherID"] = new SelectList(_context.Teacher, "TeacherId", "TeacherSurname", exercise.TeacherID);
            return View(exercise);
        }

        // GET: Exercises/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exercise = await _context.Exercise
                .Include(e => e.Classroom)
                .Include(e => e.Group)
                .Include(e => e.Subject)
                .Include(e => e.Teacher)
                .FirstOrDefaultAsync(m => m.ExerciseId == id);
            if (exercise == null)
            {
                return NotFound();
            }

            return View(exercise);
        }

        // POST: Exercises/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var exercise = await _context.Exercise.FindAsync(id);
            if (exercise != null)
            {
                _context.Exercise.Remove(exercise);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExerciseExists(int id)
        {
            return _context.Exercise.Any(e => e.ExerciseId == id);
        }
    }
}
