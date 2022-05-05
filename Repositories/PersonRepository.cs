using FizzBuzzWeb.Data;
using FizzBuzzWeb.Interfaces;
using FizzBuzzWeb.Models;

namespace FizzBuzzWeb.Repositories
{
    public class PersonRepository: IPersonRepository
    {
        private readonly PeopleContext _context;

        public PersonRepository(PeopleContext context)
        {
            _context = context;
        }
        public IQueryable<Person> GetAllEntries()
        {
            return _context.Person;
        }
        public IQueryable<Person> GetEntriesFromToday()
        {
            return _context.Person.Where(p => p.Date == DateTime.Today);
        }
        public void AddEntry(Person person)
        {
            IList<Person> Person = _context.Person.ToList();
            _context.Person.Add(person);
            _context.SaveChanges();
        }
    }
}
