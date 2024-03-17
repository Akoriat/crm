using crm.Data;
using crm.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace crm.Controllers
{
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

        public async Task<IActionResult> Index()
        {
            Association lexa = new Association();
            lexa.Students = await _lexa.Student.ToArrayAsync();
            lexa.Groups = await _lexa.Group.ToArrayAsync();
            lexa.Classrooms = await _lexa.Classroom.ToArrayAsync();
            lexa.Subjects = await _lexa.Subject.ToArrayAsync();
            lexa.Teachers = await _lexa.Teacher.ToArrayAsync();
            lexa.Exercises = await _lexa.Exercise.ToArrayAsync();
            return View(lexa);
        }

        public ActionResult GetDataByCellId(string cellId)
        {
            // Здесь добавьте логику для получения данных из класса Association и возврата их
            // Например, можно использовать switch для различения id ячеек
            Association Lexa = new Association();
            //Lexa.Exercise

            string data;
            switch (cellId)
            {
                case "Pon8_20":
                    data = "Данные для ячейки Понедельник 8:20";
                    break;
                // Добавьте другие case для остальных cellId

                default:
                    data = "Нет данных";
                    break;
            }

            return Content(data);
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
