using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EX1.Pages
{
    public class CityManagerModel : PageModel
    {
        [BindProperty]
        public string? CityName { get; set; } 

        public void OnGet()
        {
        }
    }
}
