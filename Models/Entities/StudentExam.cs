namespace Models
{
    public class StudentExam
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int ExamId { get; set; }
        public int Score { get; set; } = 0;
        public List<StudentExamAnswer> ExamAnswers { get; set; } = new List<StudentExamAnswer>();
    }
}
