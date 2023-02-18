using Microsoft.EntityFrameworkCore;
using PTMK.Data;
using PTMK.Entities;

namespace PTMK.Repositories
{
    public class Repository : IRepository
    {
        private readonly AppDbContext _context;

        public Repository(AppDbContext context)
        {
            _context = context;
        }

        public void AddPerson(Person person)
        {
            _context.Add(person);
            _context.SaveChanges();
        }

        public  IEnumerable<Person> GetPeople()
        {
            return  _context.People
                .AsNoTracking()
                .OrderBy(p => p.FullName)
                .ToList();
        }

        public IEnumerable<Person> GetPeopleWithF()
        {
            return  _context.People
                .AsNoTracking()
                .Where(x => x.FullName.StartsWith("F"))
                .ToList();
        }
    }
}
