using PTMK.Entities;

namespace PTMK.Repositories
{
    public interface IRepository
    {
        IEnumerable<Person> GetPeople();
        IEnumerable<Person> GetPeopleWithF();
        void AddPerson(Person person);
    }
}
