using System.ComponentModel.DataAnnotations;
namespace FizzBuzzWeb.Models
{
    public class FizzBuzz
    {
        [Display(Name = "Twój szczęśliwy numerek")]
        [Required (ErrorMessage="Podaj liczbę całkowitą"),
         Range(1, int.MaxValue, ErrorMessage = "Oczekiwana wartość nie jest z zakresu {1} {2}.")]
        public int? Number { get; set; }

        public string validationfor3(int? number)
        {
            if (number % 3 == 0 && number % 5 ==0)
                return "FizzBuzz";
            if (number % 3 == 0)
                return "Fizz";
            if (number % 5 == 0)
                return "Buzz";
            return "Liczba " + number + " nie spełnia kryteriów FizzBuzz";

        }
    }
}
