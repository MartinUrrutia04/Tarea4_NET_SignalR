using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Tarea_4_SignalR.Pages
{
    public class PaginaBienvenidaModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public string Email { get; set; }

        public void OnGet()
        {
        }
    }
}
