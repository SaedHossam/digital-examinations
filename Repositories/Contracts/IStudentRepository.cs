
using Models;

namespace Repositories
{
    public interface IStudentRepository
    {
        Task CreateStudent(CreateStudentDto payload);
        Task DeleteStudent(int id);
        public Task<List<Student>> GetAllStudents();
        Task<Student> GetStudentDetails(int id);
        Task UpdateStudent(int id, CreateStudentDto payload);
    }
}
