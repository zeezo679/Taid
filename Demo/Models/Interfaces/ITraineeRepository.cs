using Demo.Models.Entities;

namespace Demo.Models.Interfaces
{
    public interface ITraineeRepository
    {
        List<Trainee> Load(bool ordered);
        Trainee Get(int id);
        void Insert(Trainee trainee);
        void Update(Trainee trainee);
        void Delete(int id);
    }
}
