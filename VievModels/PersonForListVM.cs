using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FizzBuzzWeb.VievModels
{
    public class PersonForListVM
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        [Column(TypeName = "varchar(100)")]
        public string FullName { get; set; }
        [Required(ErrorMessage = "Podaj liczbę całkowitą"),
         Range(1899, 2022, ErrorMessage = "{0} nie jest z zakresu {1} i {2}.")]
        public int? Years { get; set; }
        public string? Loop { get; set; }
    }
}
