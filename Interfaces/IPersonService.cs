using FizzBuzzWeb.VievModels;
using FizzBuzzWeb.Models;

namespace FizzBuzzWeb.Interfaces
{
    public interface IPersonService
    {
        ListPersonForListVM GetAllEntries();
        ListPersonForListVM GetEntriesFromToday();
        void AddEntry(PersonForListVM personForListVM);
    }
}
