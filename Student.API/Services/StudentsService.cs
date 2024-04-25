using Student.API.Dto;

namespace Student.API.Services
{
    public class StudentsService : IStudentsService
    {
        private AppDbContext _context;
        public StudentsService(AppDbContext context) 
        {
            _context = context;
        }


        public List<Models.Student> GetAllStudents()
        {
            var allStudents = _context.Students.ToList();
            return allStudents;
        }

        public Models.Student AddStudent(PostStudentDto student)
        {
            var newStudent = new Models.Student()
            {
                FullName = student.FullName,
                DOB = student.DOB,
                Example = student.Example
            };

            _context.Students.Add(newStudent);
            _context.SaveChanges();

            return newStudent;
        }

        public void DeleteStudent(int id)
        {
            var studentDb = _context.Students
                .FirstOrDefault(n => n.Id == id);

            _context.Students.Remove(studentDb);
            _context.SaveChanges();
        }

        

        public Models.Student GetStudentById(int id)
        {
            var newStudent = _context.Students
                .FirstOrDefault(n => n.Id == id);

            return newStudent;
        }

        public Models.Student UpdateStudent(PutStudentDto studentData, int id)
        {
            var studentDb = _context.Students
                .FirstOrDefault(n => n.Id == id);

            studentDb.FullName = studentData.FullName;
            _context.Students.Update(studentDb);

            _context.SaveChanges();

            return studentDb;
        }
    }
}
