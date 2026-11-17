using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EX3.Pages.CityManager
{
    public class CreateCityModel : PageModel
    {

        [BindProperty]
        public InputModel Input { get; set; } = new();
        public string MsgSucesso { get; set; } = string.Empty;

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            MsgSucesso = $"Cidade {Input.CityName} criada com sucesso!";
            return Page();

        }

        public class InputModel
        {
            [Required(ErrorMessage = "O nome da cidade é obrigatório.")]
            [MinLength(3, ErrorMessage = "O nome da cidade deve ter no mínimo 3 caracteres.")]
            public string CityName { get; set; } = string.Empty;

        }

    }
}
