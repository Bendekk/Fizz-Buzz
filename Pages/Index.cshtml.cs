using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FizzBuzzWeb.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using FizzBuzzWeb.Data;
using FizzBuzzWeb.Interfaces;
using FizzBuzzWeb.VievModels;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace FizzBuzzWeb.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IPersonService _personService;
        public ListPersonForListVM Records { get; set; }

        [BindProperty(SupportsGet = true)]
        public String? Name { get; set; }

        [BindProperty]
        public PersonForListVM Person { get; set; }


        public IndexModel(ILogger<IndexModel> logger, IPersonService personService)
        {
            _logger = logger;
            _personService = personService;
        }

        public void OnGet()
        {
            Records = _personService.GetEntriesFromToday();
            if (string.IsNullOrWhiteSpace(Name))
            {
                Name = "User";
            }
        }
        public IActionResult OnPost()
        {
            Records = _personService.GetEntriesFromToday();
            if (ModelState.IsValid)
            {
                _personService.AddEntry(Person);
            }
            return Page();

        }

    }
}