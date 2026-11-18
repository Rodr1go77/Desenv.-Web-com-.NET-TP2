/*8 Roteamento com Parâmetros na URL
Implemente uma página CityDetails.cshtml que recebe o nome da cidade via URL.
Tarefas:
Configure a diretiva @page "{cityName}".
Utilize RouteData.Values ou um parâmetro OnGet(string cityName).
Exiba uma mensagem como "Você está vendo detalhes de: Rio de Janeiro". 
*/

using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EX8.Pages.CityManager
{
    public class CityDetailsModel : PageModel
    {
        public string CityName { get; set; } = string.Empty;
        public void OnGet(string cityName)
        {
            CityName = cityName;
        }
    }
}
