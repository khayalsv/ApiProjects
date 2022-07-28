using KSApi.Data.Entities;
using KSApi.Helpers;
using KSApi.Repository;
using KSApi.UnitOfWork;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace KSApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    //[Authorize(Roles = "Admin")] admin olanlar prosesler apara bilir
    public class StudentController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public StudentController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        //GetAll
        [HttpGet("all")]
        [Authorize("AdminOnly")]
        public async Task<object> GetAll()
        {
            var user = HttpContext.User;

            var isInAdminRole = user.IsInRole("Admin");

            var list = await _unitOfWork.StudentRepository.GetAllList();

            return list.ToList(); ;
        }


        //Get
        //[AllowAnonymous] guest userlere icaze verir (authorize olunmur)
        [HttpGet("student/{id}")]
        public async Task<IActionResult> GetStudent(int id)
        {

            var student = await _unitOfWork.StudentRepository.Find(id);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }


        //Create
        [HttpPost("create")]
        public async Task<IActionResult> CreateStudent([FromBody] Student student)
        {
            await _unitOfWork.StudentRepository.Add(student);
            await _unitOfWork.Commit();

            return Created($"/api/student/student/{student.Id}", student);
        }


        //Update
        [HttpPut("update")]
        public async Task<Student> UpdateStudent(int id, Student newStudent)
        {
            var student = await _unitOfWork.StudentRepository.Find(id);

            student.Name = newStudent.Name;
            student.Surname = newStudent.Surname;

            await _unitOfWork.StudentRepository.Update(student);
            await _unitOfWork.Commit();

            return student;
        }


        //Delete
        [HttpDelete("delete")]
        public async Task<Student> DeleteStudent(int id)
        {
            var student = await _unitOfWork.StudentRepository.Find(id);

            await _unitOfWork.StudentRepository.Delete(student);
            await _unitOfWork.Commit();

            return student;
        }


        //[HttpGet("studentCourseReport")]
        //public async Task<object> GetReport()  //sql code
        //{
        //    var query = from sc in mycontext.StudentCourses
        //                join s in mycontext.Students on sc.StudentID equals s.ID
        //                join c in mycontext.Courses on sc.CourseID equals c.ID
        //                join g in mycontext.Genders on s.GenderID equals g.ID
        //                select new
        //                {
        //                    s.Name,
        //                    s.Surname,
        //                    s.DateOfBirth,
        //                    GenderName = g.Name,
        //                    CourseName = c.Name,
        //                    sc.StartDate,
        //                    sc.EndDate
        //                };
        //    return await query.ToListAsync();
        //}


        //[HttpGet("genders")]             
        //public async Task<object> GetGender()
        //{
        //    var list = await mycontext.Students.Include(x => x.Gender)
        //        .Select(y => new
        //        {
        //            y.Name,
        //            y.Surname,
        //            y.Salary,
        //            y.DateOfBirth,
        //            GenderName=y.Gender.Name
        //        }).ToListAsync();
        //    return list;
        //}


        //[HttpGet("Guid")]
        //public object GetGuid()
        //{
        //    var scopedOperation1 = (IScopedOperation)serviceProvider.GetService(typeof(IScopedOperation));
        //    var transientOperation1 = (ITransientOperation)serviceProvider.GetService(typeof(ITransientOperation));

        //    var scopedOperation2 = (IScopedOperation)serviceProvider.GetService(typeof(IScopedOperation));
        //    var transientOperation2 = (ITransientOperation)serviceProvider.GetService(typeof(ITransientOperation));


        //    var data = new
        //    {
        //        Singleton = singletonOperation.ID,
        //        Scoped1 = scopedOperation1.ID,
        //        Scoped2 = scopedOperation2.ID,
        //        Transient1 = transientOperation1.ID,
        //        Transient2 = transientOperation2.ID

        //    };

        //    return data;
        //}



        //[HttpGet("configs")]
        //public object GetConfigurations()
        //{
        //    var configurations = new
        //    {
        //        GeneralApiKey = configuration["ApiKey"],
        //        SmsApiKey = configuration["SmsApi:ApiKey"],
        //        FromNumber = configuration["SmsApi:FromNumber"],
        //        PositionOptions = positionOptions
        //    };

        //    return configurations;
        //}
    }
}
