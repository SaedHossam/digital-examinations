using Dapper;
using Data;
using Models;

namespace Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly DigitalExaminationsDbContext _context;

        public StudentRepository(DigitalExaminationsDbContext context)
        {
            _context = context;
        }

        public async Task<List<Student>> GetAllStudents(CancellationToken cancellationToken)
        {
            var query = "SELECT * FROM Students";
            using (var connection = _context.CreateConnection())
            {
                var students = await connection.QueryAsync<Student>(query, cancellationToken);
                return students.ToList();
            }
        }
    }
}
