using crm.Areas.Admin.Data;
using crm.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;


namespace crm.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {

        //private readonly ILogger<HomeController> _logger;
        //private readonly ILogger<StudentsController> _students;
        //private readonly ILogger<GroupsController> _groups;
        //private readonly ILogger<ExercisesController> _exercises;
        //private readonly ILogger<SubjectsController> _subjects;
        //private readonly ILogger<TeacherAndSubjectsController> _teacherandsubjects;
        //private readonly ILogger<TeachersController> _teachers;
        //private readonly ILogger<ClassroomsController> _classrooms;
        //public HomeController(ILogger<StudentsController> students,
        //                    ILogger<GroupsController> groups,
        //                    ILogger<ExercisesController> exercises,
        //                    ILogger<SubjectsController> subjects,
        //                    ILogger<TeacherAndSubjectsController> teacherandsubjects,
        //                    ILogger<TeachersController> teachers,
        //                    ILogger<ClassroomsController> classrooms)
        //{
        //    _students = students;
        //    _groups = groups;
        //    _exercises = exercises;
        //    _subjects = subjects;
        //    _teacherandsubjects = teacherandsubjects;
        //    _teachers = teachers;
        //    _classrooms = classrooms;
        //}

        private readonly crmContext _lexa;
        public HomeController(crmContext context)
        {
            _lexa = context;
        }

        public ActionResult Index()
        {
            //Association lexa = new Association();
            //lexa.Students = await _lexa.Student.ToArrayAsync();
            //lexa.Groups = await _lexa.Group.ToArrayAsync();
            //lexa.Classrooms = await _lexa.Classroom.ToArrayAsync();
            //lexa.Subjects = await _lexa.Subject.ToArrayAsync();
            //lexa.Teachers = await _lexa.Teacher.ToArrayAsync();
            //lexa.Exercises = await _lexa.Exercise.ToArrayAsync();
            var groups = _lexa.Group.ToList();
            ViewBag.GroupList = new SelectList(groups, "GroupId", "GroupName");
            return View();
        }
        public ActionResult Index2()
        {
            //Association lexa = new Association();
            //lexa.Students = await _lexa.Student.ToArrayAsync();
            //lexa.Groups = await _lexa.Group.ToArrayAsync();
            //lexa.Classrooms = await _lexa.Classroom.ToArrayAsync();
            //lexa.Subjects = await _lexa.Subject.ToArrayAsync();
            //lexa.Teachers = await _lexa.Teacher.ToArrayAsync();
            //lexa.Exercises = await _lexa.Exercise.ToArrayAsync();
            var teachers = _lexa.Teacher.ToList();
            ViewBag.TeacherList = new SelectList(teachers, "TeacherId", "TeacherSurname");
            return View();
        }

        public ActionResult Lexa()
        {
            return View();
        }

        public string Found(IEnumerable<Exercise> exercises, DayOfWeek day, TimeSpan time)
        {
            try
            {
                var tmp = exercises.First(x => x.DayOfWeek == day && x.Time == time);
                return tmp.ToString();
            }
            catch
            {
                return "No data";
            }
        }
        public ActionResult GetGroupData(int groupId)
        {
            var exercisess = _lexa.Exercise
                .Where(x => x.GroupID == groupId)
                .Include(g => g.Group)
                .Include(s => s.Subject)
                .Include(c => c.Classroom)
                .Include(t => t.Teacher).ToList();

            ViewData["p820"] = Found(exercisess, DayOfWeek.Monday, new TimeSpan(8, 20, 0));
            ViewData["p1000"] = Found(exercisess, DayOfWeek.Monday, new TimeSpan(10, 00, 0));
            ViewData["p1205"] = Found(exercisess, DayOfWeek.Monday, new TimeSpan(12, 05, 0));
            ViewData["p1350"] = Found(exercisess, DayOfWeek.Monday, new TimeSpan(13, 50, 0));
            ViewData["p1535"] = Found(exercisess, DayOfWeek.Monday, new TimeSpan(15, 35, 0));

            ViewData["v820"] = Found(exercisess, DayOfWeek.Tuesday, new TimeSpan(8, 20, 0));
            ViewData["v1000"] = Found(exercisess, DayOfWeek.Tuesday, new TimeSpan(10, 00, 0));
            ViewData["v1205"] = Found(exercisess, DayOfWeek.Tuesday, new TimeSpan(12, 05, 0));
            ViewData["v1350"] = Found(exercisess, DayOfWeek.Tuesday, new TimeSpan(13, 50, 0));
            ViewData["v1535"] = Found(exercisess, DayOfWeek.Tuesday, new TimeSpan(15, 35, 0));

            ViewData["s820"] = Found(exercisess, DayOfWeek.Wednesday, new TimeSpan(8, 20, 0));
            ViewData["s1000"] = Found(exercisess, DayOfWeek.Wednesday, new TimeSpan(10, 00, 0));
            ViewData["s1205"] = Found(exercisess, DayOfWeek.Wednesday, new TimeSpan(12, 05, 0));
            ViewData["s1350"] = Found(exercisess, DayOfWeek.Wednesday, new TimeSpan(13, 50, 0));
            ViewData["s1535"] = Found(exercisess, DayOfWeek.Wednesday, new TimeSpan(15, 35, 0));

            ViewData["c820"] = Found(exercisess, DayOfWeek.Thursday, new TimeSpan(8, 20, 0));
            ViewData["c1000"] = Found(exercisess, DayOfWeek.Thursday, new TimeSpan(10, 00, 0));
            ViewData["c1205"] = Found(exercisess, DayOfWeek.Thursday, new TimeSpan(12, 05, 0));
            ViewData["c1350"] = Found(exercisess, DayOfWeek.Thursday, new TimeSpan(13, 50, 0));
            ViewData["c1535"] = Found(exercisess, DayOfWeek.Thursday, new TimeSpan(15, 35, 0));

            ViewData["pt820"] = Found(exercisess, DayOfWeek.Friday, new TimeSpan(8, 20, 0));
            ViewData["pt1000"] = Found(exercisess, DayOfWeek.Friday, new TimeSpan(10, 00, 0));
            ViewData["pt1205"] = Found(exercisess, DayOfWeek.Friday, new TimeSpan(12, 05, 0));
            ViewData["pt1350"] = Found(exercisess, DayOfWeek.Friday, new TimeSpan(13, 50, 0));
            ViewData["pt1535"] = Found(exercisess, DayOfWeek.Friday, new TimeSpan(15, 35, 0));

            ViewData["sb820"] = Found(exercisess, DayOfWeek.Saturday, new TimeSpan(8, 20, 0));
            ViewData["sb1000"] = Found(exercisess, DayOfWeek.Saturday, new TimeSpan(10, 00, 0));
            ViewData["sb1205"] = Found(exercisess, DayOfWeek.Saturday, new TimeSpan(12, 05, 0));
            ViewData["sb1350"] = Found(exercisess, DayOfWeek.Saturday, new TimeSpan(13, 50, 0));
            ViewData["sb1535"] = Found(exercisess, DayOfWeek.Saturday, new TimeSpan(15, 35, 0));
            return PartialView("~/Areas/Admin/Views/PartialView/_TablePartialView.cshtml", exercisess);
        }

        public ActionResult GetTeacherData(int teacherId)
        {
            var exercisess = _lexa.Exercise
                .Where(x => x.GroupID == teacherId)
                .Include(g => g.Group)
                .Include(s => s.Subject)
                .Include(c => c.Classroom)
                .Include(t => t.Teacher).ToList();

            ViewData["p820"] = Found(exercisess, DayOfWeek.Monday, new TimeSpan(8, 20, 0));
            ViewData["p1000"] = Found(exercisess, DayOfWeek.Monday, new TimeSpan(10, 00, 0));
            ViewData["p1205"] = Found(exercisess, DayOfWeek.Monday, new TimeSpan(12, 05, 0));
            ViewData["p1350"] = Found(exercisess, DayOfWeek.Monday, new TimeSpan(13, 50, 0));
            ViewData["p1535"] = Found(exercisess, DayOfWeek.Monday, new TimeSpan(15, 35, 0));

            ViewData["v820"] = Found(exercisess, DayOfWeek.Tuesday, new TimeSpan(8, 20, 0));
            ViewData["v1000"] = Found(exercisess, DayOfWeek.Tuesday, new TimeSpan(10, 00, 0));
            ViewData["v1205"] = Found(exercisess, DayOfWeek.Tuesday, new TimeSpan(12, 05, 0));
            ViewData["v1350"] = Found(exercisess, DayOfWeek.Tuesday, new TimeSpan(13, 50, 0));
            ViewData["v1535"] = Found(exercisess, DayOfWeek.Tuesday, new TimeSpan(15, 35, 0));

            ViewData["s820"] = Found(exercisess, DayOfWeek.Wednesday, new TimeSpan(8, 20, 0));
            ViewData["s1000"] = Found(exercisess, DayOfWeek.Wednesday, new TimeSpan(10, 00, 0));
            ViewData["s1205"] = Found(exercisess, DayOfWeek.Wednesday, new TimeSpan(12, 05, 0));
            ViewData["s1350"] = Found(exercisess, DayOfWeek.Wednesday, new TimeSpan(13, 50, 0));
            ViewData["s1535"] = Found(exercisess, DayOfWeek.Wednesday, new TimeSpan(15, 35, 0));

            ViewData["c820"] = Found(exercisess, DayOfWeek.Thursday, new TimeSpan(8, 20, 0));
            ViewData["c1000"] = Found(exercisess, DayOfWeek.Thursday, new TimeSpan(10, 00, 0));
            ViewData["c1205"] = Found(exercisess, DayOfWeek.Thursday, new TimeSpan(12, 05, 0));
            ViewData["c1350"] = Found(exercisess, DayOfWeek.Thursday, new TimeSpan(13, 50, 0));
            ViewData["c1535"] = Found(exercisess, DayOfWeek.Thursday, new TimeSpan(15, 35, 0));

            ViewData["pt820"] = Found(exercisess, DayOfWeek.Friday, new TimeSpan(8, 20, 0));
            ViewData["pt1000"] = Found(exercisess, DayOfWeek.Friday, new TimeSpan(10, 00, 0));
            ViewData["pt1205"] = Found(exercisess, DayOfWeek.Friday, new TimeSpan(12, 05, 0));
            ViewData["pt1350"] = Found(exercisess, DayOfWeek.Friday, new TimeSpan(13, 50, 0));
            ViewData["pt1535"] = Found(exercisess, DayOfWeek.Friday, new TimeSpan(15, 35, 0));

            ViewData["sb820"] = Found(exercisess, DayOfWeek.Saturday, new TimeSpan(8, 20, 0));
            ViewData["sb1000"] = Found(exercisess, DayOfWeek.Saturday, new TimeSpan(10, 00, 0));
            ViewData["sb1205"] = Found(exercisess, DayOfWeek.Saturday, new TimeSpan(12, 05, 0));
            ViewData["sb1350"] = Found(exercisess, DayOfWeek.Saturday, new TimeSpan(13, 50, 0));
            ViewData["sb1535"] = Found(exercisess, DayOfWeek.Saturday, new TimeSpan(15, 35, 0));
            return PartialView("~/Areas/Admin/Views/PartialView/_TablePartialView.cshtml", exercisess);
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
