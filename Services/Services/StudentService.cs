
using Models;
using Repositories;

namespace Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<List<Student>> GetAllStudents(CancellationToken CancellationToken)
        {
            return await _studentRepository.GetAllStudents(CancellationToken);
        }
    }
}
