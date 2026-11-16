using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EX2.Pages.CityManager
{
    public class CreateCityModel : PageModel
    {

        public string CityName { get; set; } = string.Empty;

        public void OnGet()
        {
        }

        public void OnPost(string cityName)
        {
           if (!string.IsNullOrWhiteSpace(cityName))
            {
                CityName = $"Cidade cadastrada: {cityName}";
            }

        }

    }
}
