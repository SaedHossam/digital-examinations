namespace Models
{
    public class Exam
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public DateTime DeletedAt { get; set; }
        public List<Question> Questions { get; set; } = new List<Question>();
    }
}
