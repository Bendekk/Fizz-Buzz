using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using FizzBuzzWeb.Models;
using FizzBuzzWeb.Interfaces;
using FizzBuzzWeb.VievModels;

namespace FizzBuzzWeb.Pages
{
    public class SaveSessionModel : PageModel
    {
        private readonly IPersonService _personService;

        public ListPersonForListVM Results { get; set; }

        public SaveSessionModel(IPersonService personService)
        {
            _personService = personService;
        }
        public void OnGet()
        {
            Results = _personService.GetAllEntries();
        }
    }
}
