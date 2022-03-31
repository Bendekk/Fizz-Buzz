using System.ComponentModel.DataAnnotations;


namespace FizzBuzzWeb.Models
{
    public class Year
    {
        [Display(Name = "Years")]
        [Required(ErrorMessage = "Podaj liczbę całkowitą"),
         Range(1899, 2022, ErrorMessage = "{0} nie jest z zakresu {1} i {2}.")]
        public int? Years { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "Podaj imie"),
        StringLength(100, ErrorMessage = "{0} nie może przekraczać {1} znaków")]
        public string? Name { get; set; }

        public string CheckYear(int? year)
        {
            if (year % 400 == 0)
                return ". To był rok przestępny";
            else if(year % 100 == 0)
                return ". To nie był rok przestępny";

            if (year % 4 == 0)
                return ". To był rok przestępny";
            return ". To nie był rok przestępny";
        }
    }
}
