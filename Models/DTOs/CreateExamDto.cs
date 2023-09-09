namespace Models
{
    public class CreateExamDto
    {
        public string? Title { get; set; }
        public List<QuestionDto> Questions { get; set; } = new List<QuestionDto>();
    }
}
