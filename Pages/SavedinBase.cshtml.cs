using FizzBuzzWeb.Data;
using FizzBuzzWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FizzBuzzWeb.Pages
{
    public class SavedinBaseModel : PageModel
    {
        private readonly PeopleContext _context;
        public IList<Person> People { get; set; }

        public SavedinBaseModel(PeopleContext context)
        {
            _context = context;
        }
        public void OnGet()
        {
            People = _context.Person.ToList().OrderByDescending(p => p.Date).Take(20).ToList();
        }
        public IActionResult OnPostDelete(int IdToDelete)
        {
            _context.Remove(_context.Person.Single(p => p.Id == IdToDelete));
            _context.SaveChanges();
            return RedirectToPage("./SavedinBase");
        }
    }
}
