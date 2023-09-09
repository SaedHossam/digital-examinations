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

        public async Task CreateStudent(CreateStudentDto payload)
        {
            await _studentRepository.CreateStudent(payload);
        }

        public async Task DeleteStudent(int id)
        {
            await _studentRepository.DeleteStudent(id);
        }

        public async Task<List<Student>> GetAllStudents()
        {
            return await _studentRepository.GetAllStudents();
        }

        public async Task<Student> GetStudentDetails(int id)
        {
            return await _studentRepository.GetStudentDetails(id);
        }

        public async Task UpdateStudent(int id, CreateStudentDto payload)
        {
            await _studentRepository.UpdateStudent(id, payload);
        }
    }
}
