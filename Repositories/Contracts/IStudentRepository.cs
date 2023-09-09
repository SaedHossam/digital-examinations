
using Models;

namespace Repositories
{
    public interface IStudentRepository
    {
        public Task<List<Student>> GetAllStudents(CancellationToken cancellationToken);
    }
}
