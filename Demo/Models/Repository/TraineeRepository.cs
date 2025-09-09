using Demo.Infrastructure;
using Demo.Models.Entities;
using Demo.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Demo.Models.Repository
{
    public class TraineeRepository : ITraineeRepository
    {
        private AppDbContext _context;

        public TraineeRepository(AppDbContext context)
        {
            _context = context;
        }
        public List<Trainee> Load(bool ordered)
        {
            List<Trainee> trainees = ordered ?
                _context.Trainees.Include(t => t.Department).OrderByDescending(t => t.Grade).ToList() :
                _context.Trainees.Include(t => t.Department).ToList();

            return trainees;
        }

        public Trainee Get(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Trainee trainee)
        {
            _context.Trainees.Add(trainee);
            _context.SaveChanges();
        }

     
        public void Update(Trainee trainee)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
