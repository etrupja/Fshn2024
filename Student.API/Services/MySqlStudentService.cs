using Student.API.Dto;

namespace Student.API.Services
{
    public class MySqlStudentService : IStudentsService
    {
        public Models.Student AddStudent(PostStudentDto student)
        {
            throw new NotImplementedException();
        }

        public void DeleteStudent(int id)
        {
            throw new NotImplementedException();
        }

        public List<Models.Student> GetAllStudents()
        {
            throw new NotImplementedException();
        }

        public Models.Student GetStudentById(int id)
        {
            throw new NotImplementedException();
        }

        public Models.Student UpdateStudent(PutStudentDto studentData, int id)
        {
            throw new NotImplementedException();
        }
    }
}
