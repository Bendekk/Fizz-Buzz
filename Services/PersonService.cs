using FizzBuzzWeb.Data;
using FizzBuzzWeb.Interfaces;
using FizzBuzzWeb.Models;
using FizzBuzzWeb.VievModels;

namespace FizzBuzzWeb.Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepo;
        public PersonService(IPersonRepository personRepo)
        {
            _personRepo = personRepo;
        }
        public ListPersonForListVM GetAllEntries()
        {
            var People = _personRepo.GetAllEntries();
            ListPersonForListVM ListOfPeaople = new ListPersonForListVM();

            ListOfPeaople.People = new List<PersonForListVM>();
            foreach (var person in People)
            {
                var p = new PersonForListVM()
                {
                    Id = person.Id,
                    FullName = person.FirstName + (person.LastName != "" ? " " + person.LastName : ""),
                    Years = person.Years,
                    Loop = person.CheckYear(person.Years)
                };
                ListOfPeaople.People.Add(p);
            }

            ListOfPeaople.Count = ListOfPeaople.People.Count;
            return ListOfPeaople;
        }

        public ListPersonForListVM GetEntriesFromToday()
        {
            var People = _personRepo.GetEntriesFromToday();
            ListPersonForListVM ListOfPeaople = new ListPersonForListVM();

            ListOfPeaople.People = new List<PersonForListVM>();
            foreach (var person in People)
            {
                var p = new PersonForListVM()
                {
                    Id = person.Id,
                    FullName = person.FirstName + (person.LastName != "" ? " " + person.LastName : ""),
                    Years = person.Years,
                    Loop = person.CheckYear(person.Years)
                };
                ListOfPeaople.People.Add(p);
            }

            ListOfPeaople.Count = ListOfPeaople.People.Count;
            return ListOfPeaople;
        }

        public void AddEntry(PersonForListVM personForListVM)
        {
            string[] splitName = personForListVM.FullName.Split(' ');
            Person person = new Person()
            {
                FirstName = splitName[0],
                LastName = (splitName.Length > 1 ? splitName[1] : ""),
                Years = personForListVM.Years,
                Date = DateTime.Today,
                Loop = personForListVM.Loop,
            };
            _personRepo.AddEntry(person);
        }
    }
}
