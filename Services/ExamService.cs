using Models;
using Repositories;

namespace Services
{
    public class ExamService : IExamService
    {
        private readonly IExamRepository _examRepository;

        public ExamService(IExamRepository examRepository)
        {
            _examRepository = examRepository;
        }

        public async Task CreateExam(CreateExamDto payload)
        {
            await _examRepository.CreateExam(payload);
        }

        public async Task Delete(int id)
        {
            await _examRepository.Delete(id);
        }

        public async Task<Exam?> GetExam(int id)
        {
            return await _examRepository.GetExam(id);
        }

        public async Task<List<Exam>> GetExams()
        {
            return await _examRepository.GetExams();
        }

        public bool ValidateExamData(CreateExamDto payload)
        {
            if (
                payload == null
                || string.IsNullOrEmpty(payload.Title)
                || !payload.Questions.Any()
                || payload.Questions.Any(q => string.IsNullOrEmpty(q.QuestionText))
                )
                return false;
            return true;
        }
    }
}
