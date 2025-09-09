using System;
using System.ComponentModel.DataAnnotations;
using Demo.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Demo.ViewModel
{
    public class CourseViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "This Field Is Required")]
        [MinLength(3)]
        [MaxLength(15)]
        [UniqePerDeptValidation]
        public string Name { get; set; }

        [Required(ErrorMessage = "This Field Is Required")]
        [Range(100,120)]
        public decimal Degree { get; set; }
        [Required(ErrorMessage = "This Field Is Required")]
        [Remote(action:"IsValidMinDegree", controller:"Course", AdditionalFields = "Degree", ErrorMessage = "Minimum Degree must be less than the degree you entered")]
        public decimal MinDegree { get; set; }

        public int DeptId { get; set; }
        public List<int> InstructorIds = new List<int>(); //because more than one instructor can instruct the same course
        public List<SelectListItem> Instructors = new List<SelectListItem>();
        public List<Department> Departments = new List<Department>();
    }

}
