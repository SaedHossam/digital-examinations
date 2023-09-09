using Dapper;
using Data;
using Models;

namespace Repositories
{
    public class ExamRepository : IExamRepository
    {
        private readonly DigitalExaminationsDbContext _context;

        public ExamRepository(DigitalExaminationsDbContext context)
        {
            _context = context;
        }
    }
}
