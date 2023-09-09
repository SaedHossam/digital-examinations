namespace Models
{
    public class StudentExamAnswer
    {
        public int Id { get; set; }
        public int StudentExamId { get; set; }
        public int? AnswerId { get; set; }
        public string? AnswerText { get; set; }
        public int Score { get; set; } = 0;
    }
}
