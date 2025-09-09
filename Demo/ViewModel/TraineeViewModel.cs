using Demo.Models.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Demo.ViewModel
{
    public class TraineeViewModel
    {
        //Trainee
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Image { get; set; }
        public string Address { get; set; } = null!;
        public decimal Grade { get; set; }
        public int DeptId { get; set; }

        //Extra
        public List<Department> departments { get; set; } = new();
        //SelectList departList;
    }
}
