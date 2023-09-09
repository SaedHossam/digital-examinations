using Dapper;
using Data;
using Models;
using System.Data;

namespace Repositories
{
    public class ExamRepository : IExamRepository
    {
        private readonly DigitalExaminationsDbContext _context;

        public ExamRepository(DigitalExaminationsDbContext context)
        {
            _context = context;
        }

        public async Task CreateExam(CreateExamDto payload)
        {
            var createExamQuery = "INSERT INTO Exams (Title) VALUES (@Title)"
                + "SELECT CAST(SCOPE_IDENTITY() as int)";
            var createQuestionQuery = "INSERT INTO Questions (ExamId, QuestionText, QuestionType, Score) VALUES (@ExamId, @QuestionText, @QuestionType, @Score)"
                + "SELECT CAST(SCOPE_IDENTITY() as int)";
            var createAnswerQuery = "INSERT INTO Answers (QuestionId, AnswerText, IsCorrect) VALUES (@QuestionId, @AnswerText, @IsCorrect)";

            var parameters = new DynamicParameters();
            parameters.Add("Title", payload.Title, DbType.String);

            using (var connection = _context.CreateConnection())
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    var createdExamId = await connection.QuerySingleAsync<int>(createExamQuery, parameters, transaction);

                    foreach (var question in payload.Questions)
                    {
                        parameters = new DynamicParameters();
                        parameters.Add("ExamId", createdExamId, DbType.String);
                        parameters.Add("QuestionText", question.QuestionText, DbType.String);
                        parameters.Add("QuestionType", question.QuestionType, DbType.Int32);
                        parameters.Add("Score", question.Score, DbType.Int32);
                        var createdQuestionId = await connection.QuerySingleAsync<int>(createQuestionQuery, parameters, transaction);

                        foreach (var answer in question.Answers)
                        {
                            parameters = new DynamicParameters();
                            parameters.Add("AnswerText", answer.AnswerText, DbType.String);
                            parameters.Add("IsCorrect", answer.IsCorrect, DbType.Int32);
                            parameters.Add("QuestionId", createdQuestionId, DbType.Int32);
                            await connection.ExecuteAsync(createAnswerQuery, parameters, transaction);
                        }
                    }
                    transaction.Commit();
                }
            }
        }

        public async Task Delete(int id)
        {
            var query = "UPDATE Exams SET DeletedAt = @DeletedAt WHERE Id = @Id";
            var parameters = new DynamicParameters();
            parameters.Add("Id", id, DbType.String);
            parameters.Add("DeletedAt", DateTime.UtcNow, DbType.DateTime);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<Exam?> GetExam(int id)
        {
            var query = "SELECT * FROM Exams e LEFT JOIN Questions q ON e.Id = q.ExamId LEFT JOIN Answers a on q.Id = a.QuestionId WHERE e.Id = @Id AND e.DeletedAt is NULL";
            var parameters = new DynamicParameters();
            parameters.Add("Id", id, DbType.String);
            using (var connection = _context.CreateConnection())
            {
                var examDict = new Dictionary<int, Exam>();
                var exams = await connection.QueryAsync<Exam, Question, Answer, Exam>(
                    query, (exam, question, answer) =>
                    {
                        if (!examDict.TryGetValue(exam.Id, out var currentExam))
                        {
                            currentExam = exam;
                            examDict.Add(currentExam.Id, currentExam);
                        }

                        question.Answers.Add(answer);
                        var currentQuestionIndex = currentExam.Questions.FindIndex(q => q.Id == question.Id);
                        if (currentQuestionIndex == -1)
                        {
                            currentExam.Questions.Add(question);
                        }
                        else
                        {
                            currentExam.Questions[currentQuestionIndex].Answers.Add(answer);
                        }
                        return currentExam;
                    }, parameters
                );

                return exams.FirstOrDefault();
            }
        }

        public async Task<List<Exam>> GetExams()
        {
            var query = "SELECT * FROM Exams e LEFT JOIN Questions q ON e.Id = q.ExamId LEFT JOIN Answers a on q.Id = a.QuestionId WHERE e.DeletedAt is NULL";
            using (var connection = _context.CreateConnection())
            {
                var examDict = new Dictionary<int, Exam>();
                var exams = await connection.QueryAsync<Exam, Question, Answer, Exam>(
                    query, (exam, question, answer) =>
                    {
                        if (!examDict.TryGetValue(exam.Id, out var currentExam))
                        {
                            currentExam = exam;
                            examDict.Add(currentExam.Id, currentExam);
                        }

                        question.Answers.Add(answer);
                        var currentQuestionIndex = currentExam.Questions.FindIndex(q => q.Id == question.Id);
                        if (currentQuestionIndex == -1)
                        {
                            currentExam.Questions.Add(question);
                        }
                        else
                        {
                            currentExam.Questions[currentQuestionIndex].Answers.Add(answer);
                        }
                        return currentExam;
                    }
                );
                
                return exams.Distinct().ToList();
            }
        }
    }
}
