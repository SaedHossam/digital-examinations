namespace Models
{
    public class QuestionDto 
    {
        public string? QuestionText { get; set; }
        public QuestionTypeEnum QuestionType { get; set; }
        public int Score { get; set; } = 0;
        public List<AnswerDto> Answers { get; set; } = new List<AnswerDto>();
    }
}
