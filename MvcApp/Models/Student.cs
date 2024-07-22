namespace MvcApp.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int OrganisationId { get; set; }
        public string? OrganisationName { get; set; }

        public Organisation? Organisation { get; set; }
    }
}
