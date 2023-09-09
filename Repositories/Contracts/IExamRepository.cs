using Models;

namespace Repositories
{
    public interface IExamRepository
    {
        Task CreateExam(CreateExamDto payload);
        Task Delete(int id);
        Task<Exam?> GetExam(int id);
        Task<List<Exam>> GetExams();
    }
}
