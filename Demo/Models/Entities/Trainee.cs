using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Demo.Models.Entities
{
    public class Trainee
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Image { get; set; }
        public string Address { get; set; } = null!;
        public decimal Grade { get; set; }

        [ForeignKey("Department")]

        [DisplayName("Department")]
        public int DeptId { get; set; }
        public virtual Department Department { get; set; } = null!;
    }
}
