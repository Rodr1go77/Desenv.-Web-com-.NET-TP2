/*
9 Criando URLs com Tag Helpers
Adicione links para cada cidade de uma lista usando tag helpers de roteamento.
Tarefas:
Crie uma lista List<string> Cities = ["Rio", "São Paulo", "Brasília"].
Use asp-page e asp-route-cityName para montar os links dinâmicos.
Verifique se os links direcionam corretamente para CityDetails. 
*/


using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EXE10.Pages
{
    public class IndexModel : PageModel
    {

        public List<string> Cities { get; set; } = ["Rio de Janeiro", "Los Angeles", "São Paulo", "Houston", "Brasília" ];
        public void OnGet()
        {
        }
    }
}
