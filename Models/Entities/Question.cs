namespace Models
{
    public class Question
    {
        public int Id { get; set; }
        public string? QuestionText { get; set; }
        public QuestionTypeEnum QuestionType { get; set; }
        public int Score { get; set; } = 0;
        public int ExamId { get; set; }
        public List<Answer> Answers { get; set; } = new List<Answer>();
    }
}
