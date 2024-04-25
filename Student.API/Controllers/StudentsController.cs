using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Student.API.Dto;
using Student.API.Services;

namespace Student.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private IStudentsService _service;
        public StudentsController(IStudentsService service) 
        {
            _service = service;
        }

        [HttpGet("All")]
        public IActionResult GetStudents()
        {
            //List of students
            var allStudents = _service.GetAllStudents();

            return Ok(allStudents);
        }

        [HttpGet("GetById/{id}")]
        public IActionResult GetStudentById(int id)
        {
            var newStudent = _service.GetStudentById(id);

            if (newStudent == null)
                return NotFound($"Student with id {id} could not be found.");

            return Ok(newStudent);
        }


        [HttpPost]
        public IActionResult AddNewStudent([FromBody] PostStudentDto payload)
        {
            var newStudent = _service.AddStudent(payload);

            return Ok(newStudent);
        }


        [HttpPut("{id}")]
        public IActionResult UpdateStudent([FromBody] PutStudentDto payload, int id)
        {
            var updatedStudent = _service.UpdateStudent(payload, id);

            return Ok(payload);
        }


        [HttpDelete("DeleteById/{id}")]
        public IActionResult DeleteStudent(int id)
        {
            _service.DeleteStudent(id);

            return Ok();
        }

    }
}
