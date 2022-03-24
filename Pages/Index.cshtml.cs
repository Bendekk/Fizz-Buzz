using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FizzBuzzWeb.Models;
using Microsoft.AspNetCore.Http;


namespace FizzBuzzWeb.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        [BindProperty]
        public FizzBuzz FizzBuzz { get; set; }
        [BindProperty(SupportsGet = true)]

        public String Name { get; set; }

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
            if (!ModelState.IsValid)
            {
                ViewData["Wynik"] = FizzBuzz.validationfor3(FizzBuzz.Number);
                return Page();
            }
            return RedirectToPage("./Privacy");
        }

    }
}