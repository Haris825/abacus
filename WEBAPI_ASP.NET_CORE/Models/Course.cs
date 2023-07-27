namespace  dept.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string courseName { get; set; } = string.Empty;
        public string courseDuration { get; set; } = string.Empty;
        public string courseEnrolled { get; set; } = string.Empty;
        public string courseTiming { get; set; } = string.Empty;
        public string courseDescription { get; set; } = string.Empty;
    }
}
