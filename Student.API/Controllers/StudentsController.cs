using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Student.API.Dto;

namespace Student.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {

        [HttpGet("All")]
        public IActionResult GetStudents()
        {
            //List of students
            var allStudents = new List<Student.API.Models.Student>()
            {
                new Student.API.Models.Student()
                {
                    Id = 1,
                    FullName = "First Student",
                    DOB = DateTime.Now.AddYears(-20)
                },
                new Student.API.Models.Student()
                {
                    Id = 2,
                    FullName = "Second Student",
                    DOB = DateTime.Now.AddYears(-20)
                },
            };

            return Ok(allStudents);
        }

        [HttpGet("GetById/{id}")]
        public IActionResult GetStudentById(int id)
        {
            var newStudent = new Models.Student()
            {
                Id = 1,
                FullName = "First Student",
                DOB = DateTime.Now.AddYears(-20)
            };

            return Ok(newStudent);
        }


        [HttpPost]
        public IActionResult AddNewStudent([FromBody] PostStudentDto payload)
        {
            return Ok(payload);
        }


        [HttpPut("{id}")]
        public IActionResult UpdateStudent([FromBody] PutStudentDto payload, int id)
        {
            return Ok(payload);
        }


        [HttpDelete("DeleteById/{id}")]
        public IActionResult DeleteStudent(int id)
        {
            return Ok();
        }

    }
}
