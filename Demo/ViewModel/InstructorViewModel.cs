using Demo.Models.Entities;
using Demo.Models.Repository;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Demo.ViewModel
{
    public class InstructorViewModel
    {
        public List<Course> courses;
        public List<Department> departments;
        public List<Course> itemList;

        //instructor
        public int Id { get; set; }

        [Display(Name = "Instructor Name")]
        public string Name { get; set; } = null!;
        public string? Image { get; set; }
        public decimal Salary { get; set; }
        public string Address { get; set; } = null!;


        public int CourseId { get; set; }
        [ForeignKey("Department")]
        public int DeptId { get; set; }

        public virtual Course Course { get; set; } = null!;
        public virtual Department Department { get; set; } = null!;
    }
}
