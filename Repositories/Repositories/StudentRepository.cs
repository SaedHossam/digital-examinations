using Dapper;
using Data;
using Models;
using System.Data;

namespace Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly DigitalExaminationsDbContext _context;

        public StudentRepository(DigitalExaminationsDbContext context)
        {
            _context = context;
        }

        public async Task CreateStudent(CreateStudentDto payload)
        {
            var query = "INSERT INTO Students (Name) VALUES (@Name)";
            var parameters = new DynamicParameters();
            parameters.Add("Name", payload.Name, DbType.String);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task DeleteStudent(int id)
        {
            var query = "DELETE FROM Students WHERE Id = @Id";
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, new { id });
            }
        }

        public async Task<List<Student>> GetAllStudents()
        {
            var query = "SELECT * FROM Students";
            using (var connection = _context.CreateConnection())
            {
                var students = await connection.QueryAsync<Student>(query);
                return students.ToList();
            }
        }

        public async Task<Student> GetStudentDetails(int id)
        {
            var query = "SELECT * FROM Students WHERE Id = @Id";
            using (var connection = _context.CreateConnection())
            {
                var student = await connection.QuerySingleOrDefaultAsync<Student>(query, new { id });
                return student;
            }
        }

        public async Task UpdateStudent(int id, CreateStudentDto payload)
        {
            var query = "UPDATE Students SET Name = @Name WHERE Id = @Id";
            var parameters = new DynamicParameters();
            parameters.Add("Id", id, DbType.Int32);
            parameters.Add("Name", payload.Name, DbType.String);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
