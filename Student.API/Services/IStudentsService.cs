using Student.API.Dto;

namespace Student.API.Services
{
    public interface IStudentsService
    {
        List<Models.Student> GetAllStudents();
        Models.Student GetStudentById(int id);
        Models.Student AddStudent(PostStudentDto student);
        Models.Student UpdateStudent(PutStudentDto studentData, int id);
        void DeleteStudent(int id);
    }
}
