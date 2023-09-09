
using Models;

namespace Services
{
    public interface IStudentService
    {
        public Task<List<Student>> GetAllStudents(CancellationToken cancellationToken);
    }
}
