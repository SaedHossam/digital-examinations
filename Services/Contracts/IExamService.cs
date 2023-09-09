using Models;

namespace Services
{
    public interface IExamService
    {
        Task CreateExam(CreateExamDto payload);
        Task Delete(int id);
        Task<Exam?> GetExam(int id);
        Task<List<Exam>> GetExams();
        bool ValidateExamData(CreateExamDto payload);
    }
}
