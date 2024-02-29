using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using crm.Data;
using crm.Models;

namespace crm.Controllers
{
    public class TeacherAndSubjectsController : Controller
    {
        private readonly crmContext _context;

        public TeacherAndSubjectsController(crmContext context)
        {
            _context = context;
        }

        // GET: TeacherAndSubjects
        public async Task<IActionResult> Index()
        {
            var crmContext = _context.TeacherAndSubject.Include(t => t.Subject).Include(t => t.Teacher);
            return View(await crmContext.ToListAsync());
        }

        // GET: TeacherAndSubjects/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teacherAndSubject = await _context.TeacherAndSubject
                .Include(t => t.Subject)
                .Include(t => t.Teacher)
                .FirstOrDefaultAsync(m => m.TeacherAndSubjectId == id);
            if (teacherAndSubject == null)
            {
                return NotFound();
            }

            return View(teacherAndSubject);
        }

        // GET: TeacherAndSubjects/Create
        public IActionResult Create()
        {
            ViewData["SubjectId"] = new SelectList(_context.Subject, "SubjectId", "SubjectId");
            ViewData["TeacherId"] = new SelectList(_context.Teacher, "TeacherId", "TeacherId");
            return View();
        }

        // POST: TeacherAndSubjects/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TeacherAndSubjectId,TeacherId,SubjectId")] TeacherAndSubject teacherAndSubject)
        {
            if (ModelState.IsValid)
            {
                _context.Add(teacherAndSubject);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SubjectId"] = new SelectList(_context.Subject, "SubjectId", "SubjectId", teacherAndSubject.SubjectId);
            ViewData["TeacherId"] = new SelectList(_context.Teacher, "TeacherId", "TeacherId", teacherAndSubject.TeacherId);
            return View(teacherAndSubject);
        }

        // GET: TeacherAndSubjects/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teacherAndSubject = await _context.TeacherAndSubject.FindAsync(id);
            if (teacherAndSubject == null)
            {
                return NotFound();
            }
            ViewData["SubjectId"] = new SelectList(_context.Subject, "SubjectId", "SubjectId", teacherAndSubject.SubjectId);
            ViewData["TeacherId"] = new SelectList(_context.Teacher, "TeacherId", "TeacherId", teacherAndSubject.TeacherId);
            return View(teacherAndSubject);
        }

        // POST: TeacherAndSubjects/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TeacherAndSubjectId,TeacherId,SubjectId")] TeacherAndSubject teacherAndSubject)
        {
            if (id != teacherAndSubject.TeacherAndSubjectId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(teacherAndSubject);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TeacherAndSubjectExists(teacherAndSubject.TeacherAndSubjectId))
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
            ViewData["SubjectId"] = new SelectList(_context.Subject, "SubjectId", "SubjectId", teacherAndSubject.SubjectId);
            ViewData["TeacherId"] = new SelectList(_context.Teacher, "TeacherId", "TeacherId", teacherAndSubject.TeacherId);
            return View(teacherAndSubject);
        }

        // GET: TeacherAndSubjects/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teacherAndSubject = await _context.TeacherAndSubject
                .Include(t => t.Subject)
                .Include(t => t.Teacher)
                .FirstOrDefaultAsync(m => m.TeacherAndSubjectId == id);
            if (teacherAndSubject == null)
            {
                return NotFound();
            }

            return View(teacherAndSubject);
        }

        // POST: TeacherAndSubjects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var teacherAndSubject = await _context.TeacherAndSubject.FindAsync(id);
            if (teacherAndSubject != null)
            {
                _context.TeacherAndSubject.Remove(teacherAndSubject);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TeacherAndSubjectExists(int id)
        {
            return _context.TeacherAndSubject.Any(e => e.TeacherAndSubjectId == id);
        }
    }
}
