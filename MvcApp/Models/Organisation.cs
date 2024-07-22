namespace MvcApp.Models
{
    public class Organisation
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? INN { get; set; }
        public int TeacherId { get; set; }
        public List<Student> Students { get; set; } = new();
    }
}
