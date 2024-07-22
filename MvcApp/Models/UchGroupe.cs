namespace MvcApp.Models
{
    public class UchGroupe
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Teacher_name { get; set; }
        public int Number_of_students { get; set; }
        public int TeacherId { get; set; }
        public Teacher? Teacher { get; set; }
        public List<Student> Students { get; set; } = new();
        public List<Organisation> Organisations { get; set; } = new();
    }
}