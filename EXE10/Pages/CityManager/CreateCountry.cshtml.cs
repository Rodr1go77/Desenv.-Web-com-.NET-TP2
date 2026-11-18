using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace EXE10.Pages.CityManager
{
    public class CreateCountryModel : PageModel
    {
        [BindProperty]
        public List<InputModel> Inputs { get; set; } = [];

        public List<Country> CreatedCountries { get; set; } = [];

        public void OnGet()
        {
            for (int i = 0; i < 5; i++)
            {
                Inputs.Add(new InputModel());
            }

        }

        public IActionResult OnPost()
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }

            foreach (var input in Inputs)
            {
                if (!string.IsNullOrWhiteSpace(input.CountryName) && !string.IsNullOrWhiteSpace(input.CountryCode))
                {
                    CreatedCountries.Add(new Country
                    {
                        CountryName = input.CountryName,
                        CountryCode = input.CountryCode.ToUpperInvariant()
                    });
                }
            }

            return Page();

        }

        public class InputModel
        {
            [Required(ErrorMessage = "O nome do país é obrigatório.")]
            public string CountryName { get; set; } = string.Empty;

            [Required(ErrorMessage = "O código do país é obrigatório.")]
            [StringLength(2, MinimumLength = 2, ErrorMessage = "O código do país deve ter 2 caracteres.")]
            public string CountryCode { get; set; } = string.Empty;
        }
    }
}
