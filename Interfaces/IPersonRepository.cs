using FizzBuzzWeb.Models;

namespace FizzBuzzWeb.Interfaces
{
    public interface IPersonRepository
    {
        void AddEntry(Person person);
        IQueryable<Person> GetAllEntries();
        IQueryable<Person> GetEntriesFromToday();
    }
}
