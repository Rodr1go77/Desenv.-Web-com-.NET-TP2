/*
12 Validação Customizada com ModelState
Implemente uma regra onde o nome do país e o código devem começar com a mesma letra.
Tarefas:
No OnPost, verifique se o primeiro caractere de CountryName é igual ao de CountryCode.
Caso contrário, adicione erro via ModelState.AddModelError.
Exiba mensagem de erro próxima ao campo correspondente. 
*/

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace EXE12.Pages.CityManager
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

            for (int i = 0; i < Inputs.Count; i++)
            {
                var input = Inputs[i];

                if (!string.IsNullOrWhiteSpace(input.CountryName) && !string.IsNullOrWhiteSpace(input.CountryCode))
                {
                    char primeiraLetraNome = char.ToUpperInvariant(input.CountryName.Trim()[0]);
                    char primeiraLetraCodigo = char.ToUpperInvariant(input.CountryCode.Trim()[0]);

                    if (primeiraLetraNome != primeiraLetraCodigo)
                    {
                        ModelState.AddModelError(
                            $"Inputs[{i}].CountryCode",
                            "O código do país deve começar com a mesma letra do nome."
                        );
                    }
                }
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }

            foreach (var input in Inputs)
            {
                CreatedCountries.Add(new Country
                {
                    CountryName = input.CountryName.Trim(),
                    CountryCode = input.CountryCode.Trim()
                });

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



