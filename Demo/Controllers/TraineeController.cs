using Demo.Models.Entities;
using Demo.Models.Interfaces;
using Demo.Models.Repository;
using Demo.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Controllers
{
    public class TraineeController : Controller
    {
        private ITraineeRepository _traineeRepository;
        private IDepartmentRepository _departmentRepository;
        public TraineeController(ITraineeRepository traineeRepository, IDepartmentRepository departmentRepository) 
        {
            _traineeRepository = traineeRepository;
            _departmentRepository = departmentRepository;
        }


        [HttpGet]
        public IActionResult Index()
        {
            var trainees = _traineeRepository.Load(true);
            
            return View(trainees);
        }

        [HttpGet]
        public IActionResult AddTrainee()
        {
            var departments = _departmentRepository.Load();
            Console.WriteLine("This is the get action");

            var traineeVm = new TraineeViewModel();
            traineeVm.departments = departments;

            return View(traineeVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddTrainee(TraineeViewModel newTrainee)
        {
            Console.WriteLine("This is the POST action");
            if(ModelState.IsValid)
            {
                Department dept = _departmentRepository.Get(newTrainee.DeptId);

                Trainee trainee = new Trainee
                {
                    Name = newTrainee.Name,
                    Image = newTrainee.Image,
                    Address = newTrainee.Address,
                    Grade = newTrainee.Grade,
                    Department = dept,
                };

                _traineeRepository.Insert(trainee);
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("AddTrainee");
            }
                
        }
    }
}
