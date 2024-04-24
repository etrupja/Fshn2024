using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Student.API.Dto;

namespace Student.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private AppDbContext _context;
        public StudentsController(AppDbContext context) 
        {
            _context = context;
        }

        [HttpGet("All")]
        public IActionResult GetStudents()
        {
            //List of students
            var allStudents = _context.Students.ToList();

            return Ok(allStudents);
        }

        [HttpGet("GetById/{id}")]
        public IActionResult GetStudentById(int id)
        {
            var newStudent = _context.Students
                .FirstOrDefault(n => n.Id == id);

            if (newStudent == null)
                return NotFound($"Student with id {id} could not be found.");

            return Ok(newStudent);
        }


        [HttpPost]
        public IActionResult AddNewStudent([FromBody] PostStudentDto payload)
        {
            var newStudent = new Models.Student()
            {
                FullName = payload.FullName,
                DOB = payload.DOB,
                Example = payload.Example
            };

            _context.Students.Add(newStudent);
            _context.SaveChanges();

            return Ok(payload);
        }


        [HttpPut("{id}")]
        public IActionResult UpdateStudent([FromBody] PutStudentDto payload, int id)
        {
            var studentDb = _context.Students
                .FirstOrDefault(n => n.Id == id);

            studentDb.FullName = payload.FullName;
            _context.Students.Update(studentDb);

            _context.SaveChanges();

            return Ok(payload);
        }


        [HttpDelete("DeleteById/{id}")]
        public IActionResult DeleteStudent(int id)
        {
            var studentDb = _context.Students
                .FirstOrDefault(n => n.Id == id);

            _context.Students.Remove(studentDb);
            _context.SaveChanges();

            return Ok();
        }

    }
}
