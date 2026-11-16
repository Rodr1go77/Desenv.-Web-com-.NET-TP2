using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EX1.Pages.CityManager
{
    public class CreateCityModel : PageModel
    {
        [BindProperty]
        public string CityName { get; set; } = string.Empty;

        public void OnGet()
        {
        }

        public void OnPost()
        {
            if (!ModelState.IsValid)
            {
                return;
            }   

        }

    }
}
