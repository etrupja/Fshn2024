using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Student.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {

        [HttpGet("All")]
        public IActionResult GetStudents()
        {
            return Ok();
        }

        [HttpGet("GetById/{id}")]
        public IActionResult GetStudentById(int id)
        {
            return Ok($"Student with id = {id}");
        }


        [HttpPost]
        public IActionResult AddNewStudent([FromBody]object payload)
        {
            return Ok("Student added");
        }


        [HttpPut("{id}")]
        public IActionResult UpdateStudent([FromBody] object payload, int id)
        {
            return Ok("Student added");
        }


        [HttpDelete("DeleteById/{id}")]
        public IActionResult DeleteStudent(int id)
        {
            return Ok();
        }

    }
}
