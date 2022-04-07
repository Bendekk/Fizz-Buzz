using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FizzBuzzWeb.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using FizzBuzzWeb.Data;

namespace FizzBuzzWeb.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        [BindProperty(SupportsGet = true)]
        public String? Name { get; set; }

        [BindProperty]
        public Person Person { get; set; }

        private readonly PeopleContext _context;
        public IList<Person> People { get; set; }


        public IndexModel(ILogger<IndexModel> logger, PeopleContext context)
        {
            _logger = logger;
            _context = context;
        }

        public void OnGet()
        {
            People = _context.Person.ToList();
            if (string.IsNullOrWhiteSpace(Name))
            {
                Name = "User";
            }
        }
        public IActionResult OnPost()
        {
            People = _context.Person.ToList();
            Person.CheckYear(Person.Years);
            Person.Date = DateTime.Now;
            if (ModelState.IsValid)
            {
                List<String> mylist;
                var Data = HttpContext.Session.GetString("Data");
                if (Data != null)
                    mylist = JsonConvert.DeserializeObject<List<string>>(Data);
                else
                    mylist = new List<String>();
                ViewData["Wynik"] = Person.FirstName + " urodził się w " + Person.Years.ToString() + Person.Loop;
                Console.WriteLine(ViewData["Wynik"].ToString());
                mylist.Add(ViewData["Wynik"].ToString());
                HttpContext.Session.SetString("Data",JsonConvert.SerializeObject(mylist));
                _context.Person.Add(Person);
                _context.SaveChanges();
                return Page();
            }
            Console.WriteLine("halo");
            return Page();

        }

    }
}