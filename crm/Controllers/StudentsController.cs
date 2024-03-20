using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using crm.Data;
using crm.Models;
using ViewContext = crm.Data.ViewContext;

namespace crm.Controllers
{
    public class StudentsController : Controller
    {
        private readonly ViewContext _context;

        public StudentsController(ViewContext context)
        {
            _context = context;
        }

        // GET: Students
        public async Task<IActionResult> Index()
        {
            var crmContext = _context.Student.Include(s => s.Group);
            return View(await crmContext.ToListAsync());
        }

    }
}
