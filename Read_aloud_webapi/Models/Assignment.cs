namespace Read_aloud_webapi.Models
{
    public class Assignment
    {
        public int Id {get; set;}
        public string? Description {get; set;}
        public DateTime SubmissionDate {get; set;}
        public Member? Member {get; set;}
    }
}