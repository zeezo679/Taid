namespace Demo.Models.Entities
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Manager { get; set; } = null!;
    }
}
