using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FizzBuzzWeb.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;


namespace FizzBuzzWeb.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        [BindProperty]
        public Year Year { get; set; }
        [BindProperty(SupportsGet = true)]

        public String? Name { get; set; }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            if (string.IsNullOrWhiteSpace(Name))
            {
                Name = "User";

            }
        }
        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                List<String> mylist;
                var Data = HttpContext.Session.GetString("Data");
                if (Data != null)
                    mylist = JsonConvert.DeserializeObject<List<string>>(Data);
                else
                    mylist = new List<String>();
                ViewData["Wynik"] = Year.Name + " urodził się w " + Year.Years.ToString() + Year.CheckYear(Year.Years);
                Console.WriteLine(ViewData["Wynik"].ToString());
                mylist.Add(ViewData["Wynik"].ToString());
                HttpContext.Session.SetString("Data",JsonConvert.SerializeObject(mylist));
                return Page();
            }
            return Page();

        }

    }
}