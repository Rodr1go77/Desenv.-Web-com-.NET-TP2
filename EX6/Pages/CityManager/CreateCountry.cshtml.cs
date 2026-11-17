using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace EX6.Pages.CityManager
{
    public class CreateCountryModel : PageModel
    {
        [BindProperty]
        public InputModel Input { get; set; } = new();
        public Country? NewCountry { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            NewCountry = new Country
            {
                CountryName = Input.CountryName,
                CountryCode = Input.CountryCode.ToUpperInvariant()
            };

            return Page();

        }

        public class InputModel
        {
            [Required(ErrorMessage = "O nome do país é obrigatório.")]
            public string CountryName { get; set; } = string.Empty;

            [Required(ErrorMessage = "O código do país é obrigatório.")]
            [StringLength(2,MinimumLength = 2, ErrorMessage = "O código do país deve ter 2 caracteres.")]
            public string CountryCode { get; set; } = string.Empty;
        }
    }
}
