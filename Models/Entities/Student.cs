namespace Models
{
    public class Student
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public List<StudentExam> Exams { get; set; } = new List<StudentExam>();
    }
}
