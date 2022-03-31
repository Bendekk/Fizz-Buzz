
using FizzBuzzWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace FizzBuzzWeb.Data
{
    public class PeopleContext : DbContext
    {
        public PeopleContext(DbContextOptions options) : base(options) { }
        public DbSet<Person> Person { get; set; }
    }

}
