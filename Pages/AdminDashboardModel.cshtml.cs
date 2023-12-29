using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class AdminDashboardModel : PageModel
{
    public IActionResult OnGet()
    {
        return Page();
    }
}
