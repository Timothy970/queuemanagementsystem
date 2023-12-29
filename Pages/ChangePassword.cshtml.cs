using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;


public class ChangePasswordModel : PageModel
{
    private readonly AppDbContext _dbContext;

    [BindProperty]
    public ServiceProvider? ServiceProvider { get; set; }

    [BindProperty]
    [Required(ErrorMessage = "Current password is required.")]
    public string CurrentPassword { get; set; } = string.Empty;

    [BindProperty]
    [Required(ErrorMessage = "New password is required.")]
    [StringLength(255, MinimumLength = 5, ErrorMessage = "New password must be at least 5 characters.")]
    public string NewPassword { get; set; } = string.Empty;


    public ChangePasswordModel(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IActionResult OnGet(string username)
    {
        // Fetch the service provider from the database based on the username
        ServiceProvider = _dbContext.ServiceProviders.SingleOrDefault(u => u.Username == username);

        if (ServiceProvider == null)
        {
            // Handle the case where the user is not found (e.g., redirect to an error page)
            return NotFound();
        }

        return Page();
    }

    public IActionResult OnPost(string username)
    {
        // Fetch the service provider from the database based on the username
        ServiceProvider = _dbContext.ServiceProviders.SingleOrDefault(u => u.Username == username);

        if (ServiceProvider == null || ServiceProvider.Password != CurrentPassword)
        {
            // Incorrect current password
            ModelState.AddModelError("CurrentPassword", "Incorrect current password.");
            return Page();
        }

        // Update the password with the new password
        ServiceProvider.Password = NewPassword;

        // Save changes to the database
        _dbContext.SaveChanges();

        // Redirect to a success page or another appropriate location
        return RedirectToPage("/ConfigureServiceProviders");
    }
}
