namespace Read_aloud_webapi.Controllers.Resource
{
    public class MemberResource
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Age { get; set; }
        public string? Address { get; set; }
        public string? Job { get; set; }
        public string? PhoneNumber { get; set; }
        public string? EmailId { get; set; }
        public ICollection<AssignmentResource>? Assignments { get; set; }
    }
}