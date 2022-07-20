namespace Read_aloud_webapi.Models
{
    public class Member
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Age { get; set; }
        public string? Address { get; set; }
        public string? Job { get; set; }
        public string? PhoneNumber { get; set; }
        public string? EmailId { get; set; }
        public ICollection<Assignment>? Assignments { get; set; }
    }
}