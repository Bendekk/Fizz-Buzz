using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FizzBuzzWeb.Models
{
    public class Person
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        [Column(TypeName = "varchar(100)")]
        public string? FirstName { get; set; }
        [Required]
        [MaxLength(100)]
        public string? LastName { get; set; }
        [Required(ErrorMessage = "Podaj liczbę całkowitą"),
         Range(1899, 2022, ErrorMessage = "{0} nie jest z zakresu {1} i {2}.")]
        public int? Years { get; set; }
        public DateTime Date { get; set; }
        public string? Loop { get; set; }
        public string CheckYear(int? year)
        {
            if (year % 400 == 0)
                return ". To był rok przestępny";
            else if (year % 100 == 0)
                return ". To nie był rok przestępny";

            if (year % 4 == 0)
                return ". To był rok przestępny";
            return ". To nie był rok przestępny";
        }
    }
}
